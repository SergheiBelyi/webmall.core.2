using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Data.DataTier;
using Data.Config;
using Data.DataTier.DataTypes;
using Data.DataTier.Comparers;

namespace Data.DataTier
{
	/// <summary>
	/// Summary description for DataTier.
	/// </summary>
	public class Field:IComparable
	{
		public object parent;
		#region Поля
		public int instanceid;
		public int fieldid;
		
		public string name;
		public string alias;
		
		public int language;

		public int maxvalues;
		
		public int sourceinstanceid;
		public int sortorder;

		public DataTypes.DataType datatype;
		public string controlname;
		#endregion
		public Children sourcechildren;
		
		public Values values;
		#region Конструкторы

		public Field()
		{
			values = new Values();
			values.parent = this;
		}

		public Field(int iInstanceId, int iFieldId)
		{
			this.instanceid = iInstanceId;
			this.fieldid = iFieldId;
			values = new Values(iInstanceId,iFieldId);	
			values.parent = this;
		}

		public Field(int iInstanceId,int iFieldId,bool GetListFromDb, bool GetValuesFromDb,int Language)
		{
			this.instanceid = iInstanceId;
			this.fieldid = iFieldId;
			this.language = Language;
			values = new Values(iInstanceId,iFieldId,GetListFromDb, GetValuesFromDb,Language);
			values.parent = this;
		}

		public Field(int iInstanceId,int iFieldId,string sName, string sAlias, int iSortOrder, int iMaxValues,bool GetListFromDb, bool GetValuesFromDb,int iLanguage)
		{
			this.instanceid = iInstanceId;
			this.fieldid = iFieldId;
			this.language = iLanguage;
			this.name = sName;
			this.alias = sAlias; 
			
			this.sortorder = iSortOrder;
			values = new Values(iInstanceId,iFieldId,GetListFromDb, GetValuesFromDb,iLanguage);
			values.parent = this;
		}
		public Field(int iInstanceId,int iFieldId,string sName, string sAlias, int iSortOrder, int iSourceInstance, string sControlName, int iMaxValues,bool GetListFromDb, bool GetValuesFromDb,int iLanguage):this(iInstanceId,iFieldId,sName, sAlias, iSortOrder, iMaxValues,GetListFromDb, GetValuesFromDb,iLanguage)
		{
			this.sourceinstanceid = iSourceInstance;
			this.controlname = sControlName;
		}

		#endregion
		public static string fnValue(object field)
		{
			Field fld = field as Field;
			if(fld!=null)
			{
				try
				{
					return fld.values[0].VALUE.ToString();
				}
				catch
				{
					return "";
				}
			}
			return "";
		}
		public void GetListFromDB(int iLanguage)
		{
			Values vl = new Values(this.instanceid, this.fieldid,true,false,iLanguage);
			values = vl;
		}

		public void GetValuesFromDB(int iLanguage)
		{
			this.language = iLanguage;
			Values vl = new Values(this.instanceid, this.fieldid,true,true,iLanguage);
			vl.parent = this;
			values = vl;
		}

		public void PostValuesToDB()
		{
			values.PostToDB();
		}

		#region Методы для Nomenclature полей
		public void GetSourceInstanceChildren(int Language)
		{
			Node nd = new Node();
			nd.parent = this;
			nd.InstanceId = this.sourceinstanceid;
			nd.GetClass();
			nd.GetChildren(false);
			sourcechildren = nd.children;
			nd.GetProperties(Language);
		}

		public Children GetValuesNodes(int Language)
		{
			Children chld = new Children();
			this.GetSourceInstanceChildren(Language);			
			foreach(Node nd in this.sourcechildren)
			{
				foreach(ValueNomenclature valNom in this.values)
				{
					if(nd.InstanceId == (int) valNom.VALUE)	
					{
						chld.Add(nd);
						break;
					}
				}
			}
			return chld;
		}

		#endregion

		#region Поля, методы и свойства для ValueXNomenclature
		public Children cldNodesXValuesAll;
		public Children cldNodesXValuesSelected;

		public void XNodesGetAll(int iLanguage, bool bGetProperties)
		{
			try
			{
				SqlParameter[] arParams = new SqlParameter[2];
				arParams[0] = new SqlParameter("@InstanceId", InstanceId);
				arParams[1] = new SqlParameter("@FieldId", FieldId);
				SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
				con.Open();			
				DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spXValueFindNode", arParams);
				con.Close();
				
				cldNodesXValuesAll = new Children();
				
				for(int i=0;i<ds.Tables[0].Rows.Count;i++)
				{
					try
					{
						int FoundNode = (int) ds.Tables[0].Rows[i][0];
						if(FoundNode>0)
						{
							Node nd = new Node();
							nd.InstanceId = FoundNode;
							nd.GetNodeFields();
							if(bGetProperties)
							{
								nd.GetProperties(iLanguage);
							}
							cldNodesXValuesAll.Add(nd);
						}
					}
					catch
					{
					}
				}
			}
			catch(Exception ex)
			{
				string msg = ex.Message;
			}
		}

		public void XNodesGetSelected(int iLanguage, bool bGetProperties)
		{
			Children cld = new Children();
			foreach(ValueNomenclature vn in this.values)
			{
				int i =(int)vn.VALUE;
				Node ndXValueAll = new Node();
				ndXValueAll.InstanceId = i;
				if(bGetProperties)
				{
					ndXValueAll.GetProperties(iLanguage);
				}
				else
				{
					ndXValueAll.GetNodeFields();
				}

				cld.Add(ndXValueAll);
			}
			this.cldNodesXValuesSelected = cld;
		}
		
		#endregion

		#region Интерфейс для сравнения
		int IComparable.CompareTo(Object o)
		{
			Field fld = (Field) o;
			if(this.sortorder>fld.sortorder)
			{
				return 1;
			}
			else
			{
				if(this.sortorder==fld.sortorder)
				{
					return String.Compare(this.name, fld.name);
				}
				else
				{
					return -1;
				}
			}
		}
		#endregion
		#region Свойства
		public int InstanceId
		{
			get
			{
				return instanceid;
			}
			set
			{
				instanceid = value;
			}
		}

		public int FieldId
		{
			get
			{
				return fieldid;
			}
			set
			{
				fieldid = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public string Alias
		{
			get
			{
				return alias;
			}
			set
			{
				alias = value;
			}
		}

		public int Language
		{
			get
			{
				return language;
			}
			set
			{
				language = value;
			}
		}
		
		public int MaxValues
		{
			get
			{
				return maxvalues;
			}
		}

		public DataTypes.DataType dataType
		{
			get
			{
				return datatype;
			}
			set
			{
				datatype = value;
			}
		}
		
		public string ControlName
		{
			get
			{
				return controlname;
			}
			set
			{
				controlname = value;
			}
		}
		#endregion

		public string ValueString
		{
			get
			{
				try
				{
					return this.values[0].VALUE.ToString();
				}
				catch { return ""; }
			}
		}
		/// <summary>
		/// Получить численное знаечение поля, 0 - по умолчанию
		/// </summary>
		public int ValueInt32
		{
			get
			{
				try
				{
					return Convert.ToInt32(this.values[0].VALUE);
				}
				catch { return 0; }
			}
		}

		public ValueBinary ValueBinary
		{
			get
			{
				try
				{
					return this.values[0].VALUE as ValueBinary;
				}
				catch { return null; }
			}
		}
	}

}

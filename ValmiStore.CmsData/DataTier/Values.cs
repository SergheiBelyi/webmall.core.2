using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Data.Config;


namespace Data.DataTier
{
	/// <summary>
	/// Summary description for Children.
	/// </summary>
	

	public class Values: IEnumerable
	{
		private ArrayList values;
		public object parent;
		protected bool gotlistofvaluesfromdb;
		protected bool gotvaluesfromdb;
		protected int language;

		public Values()
		{
			gotlistofvaluesfromdb = false;
			gotvaluesfromdb = false;
			values = new ArrayList();
		}

		public Values(int iInstanceId,int iFieldId):this()
		{
			instanceid = iInstanceId;
			fieldid = iFieldId;
		}
		public Values(int iInstanceId,int iFieldId,bool GetListFromDb, bool GetValuesFromDb,int Language):this(iInstanceId, iFieldId)
		{		
			this.language = Language;
			if(GetListFromDb)
			{
				GetListOfValuesFromDb(Language);
				
				if(GetValuesFromDb)
				{
					foreach(Value vl in values)
					{
						vl.LanguageId = Language;
						//try
						{
							vl.GetVALUEFromDB();
						}
						//catch
						{
						}
					}
					gotvaluesfromdb = true;
				}
			}
		}


		public void PostToDB()
		{
			foreach(Value vl in values)
			{
				vl.LanguageId = this.language;
				vl.PostVALUEToDB();
			}			
		}
		// Метод для индексатора		
		public Value this[int index]
		{
			get
			{
			    try
			    {
			        if (values?.Count > index)
			            return values[index] as Value;
			    }
			    catch
			    {
			        return null;
			    }
				return null;
			}
			set => values[index]= value;
		}

		public void GetListOfValuesFromDb(int LanguageId)
		{
			if((InstanceId>0)&&(FieldId>0)&&(LanguageId>-1))
			{

				SqlParameter[] arParams = new SqlParameter[3];
				arParams[0] = new SqlParameter("@InstanceId", InstanceId);
				arParams[1] = new SqlParameter("@FieldId", FieldId);
				arParams[2] = new SqlParameter("@LanguageId", LanguageId);
				SqlConnection cn = new SqlConnection(ApplicationSettings.ConnectionString);
				cn.Open();
				SqlDataReader dr =  SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "spValuesGet", arParams);
				string TypeName;
				while(dr.Read())
				{
					TypeName = dr.GetString(4);
					Value vl = Value.CreateByDataType(TypeName);
					vl.Index = dr.GetInt32(3);
					vl.InstanceId = this.InstanceId;
					vl.FieldId = this.FieldId;					
					this.Add(vl);
					
				}
				gotlistofvaluesfromdb = true;
				dr.Close();
				cn.Close();
			}
			else
			{
				throw new Exception("Не хватает данных для чтения значений из БД");
			}

		}
		

		protected int instanceid;
		protected int fieldid;


		public void Add(Value nd)
		{
			nd.parent = this;
			values.Add(nd);
		}

		public void Remove(Value nd)
		{
			values.Remove(nd);
		}
	
		public int Count
		{
			get
			{
				return values.Count;
			}
		}


		public IEnumerator GetEnumerator()
		{
			return values.GetEnumerator();
		}

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

		public void RemoveFromDB(int LanguageId)
		{
			if((this.InstanceId>0)&&(this.FieldId>0))
			{
					SqlParameter[] arParams = new SqlParameter[3];
					arParams[0] = new SqlParameter("@InstanceId", InstanceId);
					arParams[1] = new SqlParameter("@FieldId", FieldId);
					arParams[2] = new SqlParameter("@LanguageId", LanguageId);
				SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
				con.Open();	
				SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValuesRemove", arParams);
				con.Close();

			}
			else
			{
				throw new Exception("Недостаточно параметров для удаления параметров");
			}
		}
		
		
	

	}
}

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Data.Config;
using Data.DataTier.DataTypes;


namespace Data.DataTier
{
	/// <summary>
	/// Summary description for Children.
	/// </summary>
	

	public class Fields: IEnumerator,IEnumerable
	{
		private ArrayList fields;
		public object parent;
		protected bool gotlistoffieldsfromdb;
		protected bool gotvaluesfromdb;
		protected int instanceid;
		protected int classid;
		
		public Fields()
		{
			gotlistoffieldsfromdb = false;
			gotvaluesfromdb = false;
			fields = new ArrayList();			
		}

		public Fields(int iInstanceId, int iClassId):this()
		{
			instanceid = iInstanceId;
			classid = iClassId;
		}
					

		public Fields(int iInstanceId, int iClassId, bool GetListFromDb,  bool GetValuesFromDb,int Language):this(iInstanceId,iClassId)
		{		
			if(GetListFromDb)
			{
				GetListOfFieldsFromDB(true,Language);
				
				if(GetValuesFromDb)
				{
					GetValuesFromDB(Language);
				}
			}
		}
		
		public Field FindByAlias(string alias)
		{
			foreach(Field fld in fields)
			{
				if(fld.Alias==alias)
					return fld;
			}
			return	null;

		}

		
		public Field FindByFieldId(int Id)
		{
			foreach(Field fld in fields)
			{
				if(fld.FieldId==Id)
					return fld;
			}
			return	null;

		}
		// Метод для индексатора
		
		public Field this[string alias]
		{
			get
			{
				return FindByAlias(alias);
			}		

		}

		public Field this[int index]
		{
			get
			{
				return fields[index] as Field;
			}
			set
			{
				fields[index]= value;
			}
		}

		
		// Методы для работы с бд
		public static void  RemoveFieldValuesFromDB(int NodeId, int FieldId, int Language)
		{
			SqlParameter[] arParams = new SqlParameter[3];
			arParams[0] = new SqlParameter("@InstanceId", NodeId);
			arParams[1] = new SqlParameter("@FieldId", FieldId);
			arParams[2] = new SqlParameter("@LanguageId", Language);
			SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();
			SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValuesRemove", arParams);
			con.Close();

		}
		public void GetValuesFromDB(int LanguageId)
		{
			foreach(Field fld in fields)
			{
				fld.parent = this;
				fld.GetValuesFromDB(LanguageId);
			}
			gotvaluesfromdb = true;

		}

		public void GetListOfFieldsFromDB(bool GetValuesFromDB, int Language)
		{
			SqlParameter[] arParams = new SqlParameter[1];
			arParams[0] = new SqlParameter("@ClassId", classid);
			SqlConnection cn = new SqlConnection(ApplicationSettings.ConnectionString);
			cn.Open();
			SqlDataReader dr =  SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "spFieldsGet", arParams);
				
			while(dr.Read())
			{
				int iInstanceId =instanceid;
				int iFieldId = dr.GetInt32(0);
				string sName = dr.GetString(1);
				string sAlias = dr.GetString(2);
				int iSortOrder = dr.GetInt32(3);
				
				int iSourceInstance;
				if(!dr.IsDBNull(5))
				{
					iSourceInstance = dr.GetInt32(5);
				}
				else
				{
					iSourceInstance = -1;
				}
				int iMaxValues = dr.GetInt32(7);				
				string sControlName = dr.GetString(8);
							
				Field fld = new Field(iInstanceId,iFieldId,sName, sAlias, iSortOrder, iSourceInstance, sControlName, iMaxValues, false, false,Language);
				fld.parent = this;
				Object o =  Enum.Parse(typeof(DataType), dr.GetString(9));
				try
				{
					fld.dataType =(DataType) o;
				}
				catch
				{
					throw new InvalidCastException("Видимо определён новый тип данных, которого нет в определении статичного метода fields.GetListOfFieldsFromDB");
				}
				fld.parent = this;
				Add(fld);
					
			}
			dr.Close();
			cn.Close();
			if(GetValuesFromDB)
			{
				foreach(Field fd in this)
				{
					fd.GetValuesFromDB(Language);
				}
			}
			gotlistoffieldsfromdb = true;
		}
		

		
		
		// Методы для реализации функциональнотси коллекции
		public void Add(Field fd)
		{
			fd.parent = this;
			fields.Add(fd);
		}

		public void Remove(Field fd)
		{
			fields.Remove(fd);
		}
	
		public int Count
		{
			get
			{
				return fields.Count;
			}
		}


		// Последующие три метода для реализации интерфейса IEnumerator
		public bool MoveNext()
		{
			IEnumerator itf = fields as IEnumerator;
			if(itf!=null)
			{
				return itf.MoveNext();
			}
			else
			{
				return false;
			}
		}

		public void Reset()
		{
			IEnumerator itf = fields as IEnumerator;
			if(itf!=null)
			{
				itf.Reset();
			}

		}
		public object Current
		{
			get
			{
				IEnumerator itf = fields as IEnumerator;
				return itf.Current;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return fields.GetEnumerator();
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

		public string getFieldString(string FieldName)
		{
			Field obj = this[FieldName] as Field;
			if (obj == null) return "";
			return obj.ValueString;
		}
	}
}

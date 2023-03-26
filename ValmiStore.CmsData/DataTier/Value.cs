using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Data.DataTier.DataTypes;
namespace Data.DataTier
{
	/// <summary>
	/// Summary description for IValue.
	/// </summary>
	public  class  Value: System.Data.SqlTypes.INullable,IComparable
	{
		public static int getInt(object obj, int DefValue)
		{
			try
			{
				return Convert.ToInt32(obj);
			}
			catch { return DefValue; }
		}

		public static int getInt(object obj)
		{
			return getInt(obj, -1);
		}

		public static string getString(object obj, string DefValue)
		{
			try
			{
				return Convert.ToString(obj);
			}
			catch { return DefValue; }
		}

		public static string getString(object obj)
		{
			return getString(obj, "");
		}

		public object parent;
		
		#region Интерфейс IComparable
		
		public virtual int CompareTo(object o)
		{
			return 0;
		}
		#endregion

		public Value()
		{

		}
		public Value(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, bool pReadFromDB)
		{
			instanceid = pInstanceId;
			fieldid = pFieldId;
			languageid = pLanguageId;
			index = pIndex;
		}
		public Value(int pInstanceId, int pFieldId, int pIndex, DataType pType, int pLanguageId, bool pReadFromDB)
		{
			instanceid = pInstanceId;
			fieldid = pFieldId;
			languageid = pLanguageId;
			index = pIndex;
		}
		public Value(int pInstanceId, int pFieldId, int pIndex, DataType pType, int pLanguageId, object pValue)
		{
			instanceid = pInstanceId;
			fieldid = pFieldId;
			languageid = pLanguageId;
			oValue = pValue;
			index = pIndex;
		}
		
		public static Value CreateByDataType(string dt)
		{
			
			Object o =  Enum.Parse(typeof(DataType),dt);
			try
			{
				DataType DT =(DataType) o;
				return CreateByDataType(DT);
			}
			catch
			{
				throw new InvalidCastException("Видимо определён новый тип данных, которого нет в определении статичного метода Value.CreateByDataType(string)");
			}
			/*foreach(DataType DT in Enum.GetValues(DataType))
			{
				if(dt==DT.ToString())
					return CreateByDataType(DT);
			}
			throw new InvalidCastException("Видимо определён новый тип данных, которого нет в определении статичного метода Value.CreateByDataType(string)");
			*/
		}
		
		public static Value CreateByDataType(DataType dt)
		{
			Value vl;
			switch(dt)
			{
				case DataType.ValueBinary:
					vl = new ValueBinary();
					break;
				case DataType.ValueDateTime:
					vl = new ValueDateTime();
					break;
				case DataType.ValueInt32:
					vl = new ValueInt32();
					break;
				case DataType.ValueNomenclature:
					vl = new ValueNomenclature();
					break;
				case DataType.ValueXNomenclature:
					vl = new ValueNomenclature();
					break;
				case DataType.ValueNumeric:
					vl = new ValueNumeric();
					break;
				case DataType.ValueString:
					vl = new ValueString();
					break;
				case DataType.ValueText:
					vl = new ValueText();
					break;
				case DataType.ValueString0:
					vl = new ValueString0();
					break;
				default:
					throw new InvalidCastException("Видимо определён новый тип данных, которого нет в определении статичного метода Value.CreateByDataType(DataType)");
			}
			return vl;
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected object oValue;
		/// <summary>
		/// Data Type that stored in DB
		/// </summary>
		protected DataTypes.DataType Type;
		/// <summary>
		/// 
		/// </summary>
		protected int instanceid;
		/// <summary>
		/// 
		/// </summary>
		protected int fieldid;
		/// <summary>
		/// Language ID
		/// </summary>
		protected int languageid;
		/// <summary>
		/// If true - in DB not exist not one row for this query, otherwise - false
		/// </summary>
		protected bool isnull = true;

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
		public int LanguageId
		{
			get
			{
				return languageid;
			}
			set
			{
				languageid = value;
			}
		}

		public DataTypes.DataType type
		{
			get
			{
				return Type;
			}
			set
			{
				Type = value;
			}
		}

		public object VALUE
		{
			get
			{
				return oValue;
			}
			set
			{
				oValue = value;
			}
		}		

		public virtual void GetVALUEFromDB()
		{
		}
		public virtual void PostVALUEToDB()
		{
		}
		public virtual SqlParameter GetSQLParam(string pName)
		{
			return null;
		}

		public virtual bool IsNull
		{
			get
			{
				return isnull;
			}
		}

		public virtual SqlParameter GetSqlParameterIndex(string pName)
		{
			SqlParameter param = new SqlParameter();
			param.ParameterName = pName;
			param.DbType  = DbType.Int32;
			param.IsNullable = true;
			param.Value = Index;
			return param;

		}
		protected int index;
		protected string CacheName
		{
			get
			{
				return "Value"+InstanceId.ToString()+"_"+FieldId.ToString()+"_"+Index.ToString()+"_"+LanguageId.ToString();
			}
		}
		public int Index
		{
			get
			{
				return index;
			}
			set
			{
				index = value;
			}
		}

		public object GetFromCache()
		{
			
			
			return null;//System.Web.Caching.Cache. ["aa"] as object;
		}
	}
}

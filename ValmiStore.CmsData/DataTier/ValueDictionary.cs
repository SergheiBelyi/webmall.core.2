using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Data.DataTier;
using Data.DataTier.DataTypes;
using Data.Config;


namespace Data.DataTier
{
	/// <summary>
	/// Summary description for ValueInt32.
	/// </summary>
	public class ValueDictionary:Value
	{
		protected object valuename;
		public object VALUENAME
		{
			get
			{
				return valuename;
			}
			set
			{
				valuename = value;
			}
		}
		public ValueDictionary():base()
		{
			type = DataTypes.DataType.ValueString;
		}
		public ValueDictionary(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, bool pReadFromDB)
		{
			instanceid = pInstanceId;
			fieldid = pFieldId;
			languageid = pLanguageId;
			index = pIndex;			
			type = DataTypes.DataType.ValueString;
			GetVALUEFromDB();
		}		
		public ValueDictionary(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, object pValue):base(pInstanceId, pFieldId, pIndex, DataTypes.DataType.ValueString, pLanguageId, pValue)
		{
			type = DataTypes.DataType.ValueString;
		}
		
		
		public override void GetVALUEFromDB()
		{
			SqlParameter[] arParams = new SqlParameter[6];
			arParams[0] = new SqlParameter("@InstanceId", InstanceId);
			arParams[1] = new SqlParameter("@FieldId", FieldId);
			arParams[2] = new SqlParameter("@LanguageId", languageid);
			arParams[3] = new SqlParameter("@Index", Index);
			SqlParameter a = new SqlParameter("@Value1",SqlDbType.NVarChar,2000);
			a.Direction = ParameterDirection.Output;
			arParams[4]=a;
			SqlParameter b = new SqlParameter("@Value2",SqlDbType.NVarChar,2000);
			a.Direction = ParameterDirection.Output;
			arParams[5]=b;
			SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();			
			SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueDictionaryGet", arParams);
			con.Close();
			if(a.Value.GetType()!=typeof(System.DBNull))
			{	
				this.isnull = false;
				this.VALUE = a.Value;
			}
			else
			{
				this.isnull = true;
				this.VALUE = null;
			}
			if(b.Value.GetType()!=typeof(System.DBNull))
			{	
				this.isnull = false;
				this.valuename = b.Value;
			}
			else
			{
				this.isnull = true;
				this.valuename = null;
			}
			
		}
		public override void PostVALUEToDB()
		{
			if((InstanceId>0)&&(FieldId>0)&&(LanguageId>-1))
			{

				SqlParameter[] arParams = new SqlParameter[7];
				arParams[0] = new SqlParameter("@InstanceId", InstanceId);
				arParams[1] = new SqlParameter("@FieldId", FieldId);
				arParams[2] = new SqlParameter("@LanguageId", this.languageid);
				arParams[3] = new SqlParameter("@Index", Index);
				arParams[4] = GetSQLParam("@Value");
				arParams[5] = GetSQLParam1("@ValueName");
				arParams[6] = new SqlParameter("@NewIndex",SqlDbType.Int,4000);
				arParams[6].Direction = ParameterDirection.Output;
				SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
				con.Open();
				SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueStringPost", arParams);
				con.Close();
				this.index = (System.Int32)arParams[5].Value;
							
			}
			else
			{
				throw new Exception("Не хватает данных для подготовки параметра для отправки значения в БД");
			}
		}
		public override SqlParameter GetSQLParam(string pName)
		{
			SqlParameter param = new SqlParameter();
			param.ParameterName = pName;
			param.SqlDbType  = SqlDbType.NVarChar;
			param.Size = 2000;
			param.IsNullable = true;
			
			if(oValue == null)
			{
				param.Value = System.DBNull.Value;
			}
			else		
			{
				try
				{
					param.Value =  oValue;
				}
				catch(InvalidCastException)
				{
					throw new InvalidCastException("В значение ValueString произошла ошибка преобразования типов: oValue не правильного типа его тип: "+oValue.GetType().ToString());
				}
			}			
			return param;
		}

		public  SqlParameter GetSQLParam1(string pName)
		{
			SqlParameter param = new SqlParameter();
			param.ParameterName = pName;
			param.SqlDbType  = SqlDbType.NVarChar;
			param.Size = 2000;
			param.IsNullable = true;
			
			if(valuename == null)
			{
				param.Value = System.DBNull.Value;
			}
			else		
			{
				try
				{
					param.Value =  valuename;
				}
				catch(InvalidCastException)
				{
					throw new InvalidCastException("В значение ValueDictionary произошла ошибка преобразования типов: oValue не правильного типа его тип: "+oValue.GetType().ToString());
				}
			}			
			return param;
		}


		
	}
}

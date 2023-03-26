using System;
using System.Data;
using System.Data.SqlClient;
using Data.DataTier.DataTypes;
using Data.Config;


namespace Data.DataTier
{
	/// <summary>
	/// Summary description for ValueInt32.
	/// </summary>
	public class ValueString:Value
	{
		public ValueString()
		{
			type = DataType.ValueString;
		}
		public ValueString(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, bool pReadFromDB)
		{
			instanceid = pInstanceId;
			fieldid = pFieldId;
			languageid = pLanguageId;
			index = pIndex;			
			type = DataType.ValueString;
			GetVALUEFromDB();
		}		
		public ValueString(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, object pValue):base(pInstanceId, pFieldId, pIndex, DataType.ValueString, pLanguageId, pValue)
		{
			type = DataType.ValueString;
		}
		
		
		public override void GetVALUEFromDB()
		{
			SqlParameter[] arParams = new SqlParameter[5];
			arParams[0] = new SqlParameter("@InstanceId", InstanceId);
			arParams[1] = new SqlParameter("@FieldId", FieldId);
			arParams[2] = new SqlParameter("@LanguageId", languageid);
			arParams[3] = new SqlParameter("@Index", Index);
            SqlParameter a = new SqlParameter("@Value", SqlDbType.NVarChar, -1) {Direction = ParameterDirection.Output};
		    arParams[4]=a;
			
			SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();			
			SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueStringGet", arParams);
			con.Close();
			if(a.Value.GetType()!=typeof(DBNull))
			{	
				isnull = false;
				VALUE = a.Value;
			}
			else
			{
				isnull = true;
				VALUE = null;
			}
			
		}
		public override void PostVALUEToDB()
		{
			if((InstanceId>0)&&(FieldId>0)&&(LanguageId>-1))
			{

				SqlParameter[] arParams = new SqlParameter[6];
				arParams[0] = new SqlParameter("@InstanceId", InstanceId);
				arParams[1] = new SqlParameter("@FieldId", FieldId);
				arParams[2] = new SqlParameter("@LanguageId", languageid);
				arParams[3] = new SqlParameter("@Index", Index);
				arParams[4] = GetSQLParam("@Value");
			    arParams[5] = new SqlParameter("@NewIndex", SqlDbType.Int, -1) {Direction = ParameterDirection.Output};
			    SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
				con.Open();
				SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueStringPost", arParams);
				con.Close();
				index = (Int32)arParams[5].Value;
							
			}
			else
			{
				throw new Exception("Не хватает данных для подготовки параметра для отправки значения в БД");
			}
		}
		public override SqlParameter GetSQLParam(string pName)
		{
		    SqlParameter param = new SqlParameter
		    {
		        ParameterName = pName,
		        SqlDbType = SqlDbType.NVarChar,
		        Size = -1,
		        IsNullable = true
		    };

		    if(oValue == null)
			{
				param.Value = DBNull.Value;
			}
			else		
			{
				try
				{
					param.Value =  oValue;
				}
				catch(InvalidCastException)
				{
					throw new InvalidCastException("В значение ValueString произошла ошибка преобразования типов: oValue не правильного типа его тип: "+oValue.GetType());
				}
			}			
			return param;
		}


		
	}
}

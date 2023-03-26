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
	public class ValueText:Value
	{
		public ValueText():base()
		{
			type = DataTypes.DataType.ValueInt32;
		}
		public ValueText(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, bool pReadFromDB)
		{
			instanceid = pInstanceId;
			fieldid = pFieldId;
			languageid = pLanguageId;
			index = pIndex;			
			type = DataTypes.DataType.ValueText;
			GetVALUEFromDB();
		}		
		public ValueText(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, object pValue):base(pInstanceId, pFieldId, pIndex, DataTypes.DataType.ValueInt32, pLanguageId, pValue)
		{
			type = DataTypes.DataType.ValueText;
		}
		
		
		public override void GetVALUEFromDB()
		{
			SqlParameter[] arParams = new SqlParameter[4];
			arParams[0] = new SqlParameter("@InstanceId", InstanceId);
			arParams[1] = new SqlParameter("@FieldId", FieldId);
			arParams[2] = new SqlParameter("@LanguageId", languageid);
			arParams[3] = new SqlParameter("@Index", Index);
			/*SqlParameter a = new SqlParameter("@Value",SqlDbType.Int);
			a.Direction = ParameterDirection.Output;
			arParams[4]=a;*/
			SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();			
			SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spValueTextGet", arParams);
			if(dr.Read())
			{
				this.isnull = false;
				this.VALUE = dr.GetString(0);

			}
			else
			{
				this.isnull = true;
				this.VALUE = null;
			}
			dr.Close();
			con.Close();
		}
		public override void PostVALUEToDB()
		{
			if((InstanceId>0)&&(FieldId>0)&&(LanguageId>-1))
			{

				SqlParameter[] arParams = new SqlParameter[6];
				arParams[0] = new SqlParameter("@InstanceId", InstanceId);
				arParams[1] = new SqlParameter("@FieldId", FieldId);
				arParams[2] = new SqlParameter("@LanguageId", this.languageid);
				arParams[3] = new SqlParameter("@Index", Index);
				arParams[4] = GetSQLParam("@Value");
				arParams[5] = new SqlParameter("@NewIndex",SqlDbType.Int);
				arParams[5].Direction = ParameterDirection.Output;
				SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
				con.Open();
				SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueTextPost", arParams);
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
			param.SqlDbType  = SqlDbType.NText;
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
					throw new InvalidCastException("В значение ValueText произошла ошибка преобразования типов: oValue не правильного типа его тип: "+oValue.GetType().ToString());
				}
			}			
			return param;
		}


		
	}
}

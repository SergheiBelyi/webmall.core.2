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
	public class ValueDateTime:Value
	{
		public ValueDateTime():base()
		{
			type = DataTypes.DataType.ValueDateTime;
		}
		#region Интерфейс IComparable
		
		public override int CompareTo(object o)
		{
			ValueDateTime param = o as ValueDateTime;
			if(param!=null)
			{
				if(this.VALUE!=null)
				{
					if(param.VALUE!=null)
					{
						try
						{
							DateTime dtThis = (DateTime) this.VALUE;
							DateTime dtParam = (DateTime) param.VALUE;
							return dtThis.CompareTo(dtParam);							
						}
						catch
						{
						}
					}
				}
			}
			return 0;
		}
		#endregion

		public ValueDateTime(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, bool pReadFromDB)
		{
			instanceid = pInstanceId;
			fieldid = pFieldId;
			languageid = pLanguageId;
			index = pIndex;			
			type = DataTypes.DataType.ValueDateTime;
			GetVALUEFromDB();
		}		
		public ValueDateTime(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, object pValue):base(pInstanceId, pFieldId, pIndex, DataTypes.DataType.ValueDateTime, pLanguageId, pValue)
		{
			type = DataTypes.DataType.ValueDateTime;
		}
		
		
		public override void GetVALUEFromDB()
		{
			SqlParameter[] arParams = new SqlParameter[5];
			arParams[0] = new SqlParameter("@InstanceId", InstanceId);
			arParams[1] = new SqlParameter("@FieldId", FieldId);
			arParams[2] = new SqlParameter("@LanguageId", languageid);
			arParams[3] = new SqlParameter("@Index", Index);
			SqlParameter a = new SqlParameter("@Value",SqlDbType.DateTime);
			a.Direction = ParameterDirection.Output;
			arParams[4]=a;
			
			SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();
			SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueDateTimeGet", arParams);
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
				SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueDateTimePost", arParams);
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
			param.DbType  = DbType.DateTime;
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
					throw new InvalidCastException("В значение ValueDateTime произошла ошибка преобразования типов: oValue не правильного типа его тип: "+oValue.GetType().ToString());
				}
			}			
			return param;
		}


		
	}
}

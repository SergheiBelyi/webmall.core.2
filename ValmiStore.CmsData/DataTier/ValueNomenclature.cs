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
	public class ValueNomenclature:Value
	{
		public ValueNomenclature():base()
		{
			type = DataTypes.DataType.ValueNomenclature;
		}
		public ValueNomenclature(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, bool pReadFromDB)
		{
			instanceid = pInstanceId;
			fieldid = pFieldId;
			languageid = pLanguageId;
			index = pIndex;			
			type = DataTypes.DataType.ValueNomenclature;
			GetVALUEFromDB();
		}		
		public ValueNomenclature(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, object pValue):base(pInstanceId, pFieldId, pIndex, DataTypes.DataType.ValueNomenclature, pLanguageId, pValue)
		{
			type = DataTypes.DataType.ValueNomenclature;
		}
		
		
		public override void GetVALUEFromDB()
		{
			SqlParameter[] arParams = new SqlParameter[5];
			arParams[0] = new SqlParameter("@InstanceId", InstanceId);
			arParams[1] = new SqlParameter("@FieldId", FieldId);
			arParams[2] = new SqlParameter("@LanguageId", languageid);
			arParams[3] = new SqlParameter("@Index", Index);
			SqlParameter a = new SqlParameter("@Value",SqlDbType.Int);
			a.Direction = ParameterDirection.Output;
			arParams[4]=a;
			SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();			
			SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueNomenclatureGet", arParams);
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
				SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueNomenclaturePost", arParams);
				con.Close();
				this.index = (System.Int32)arParams[5].Value;
							
			}
			else
			{
				throw new Exception("�� ������� ������ ��� ���������� ��������� ��� �������� �������� � ��");
			}
		}
		public override SqlParameter GetSQLParam(string pName)
		{
			SqlParameter param = new SqlParameter();
			param.ParameterName = pName;
			param.DbType  = DbType.Int32;
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
					throw new InvalidCastException("� �������� ValueNomenclature ��������� ������ �������������� �����: oValue �� ����������� ���� ��� ���: "+oValue.GetType().ToString());
				}
			}			
			return param;
		}


		#region ��������� IComparable
		
		public override int CompareTo(object o)
		{
			ValueNomenclature param = o as ValueNomenclature;
			if(param!=null)
			{
				if(this.VALUE!=null)
				{
					if(param.VALUE!=null)
					{
						try
						{
							int dtThis = (int) this.VALUE;
							int dtParam = (int) param.VALUE;
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
	}
}

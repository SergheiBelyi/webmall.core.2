using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Data.DataTier;
using Data.Config;
using Data.DataTier.DataTypes;

namespace Data.DataTier
{
	/// <summary>
	/// Summary description for SecurityPolicy.
	/// </summary>
	public class SecurityPolicy
	{
		protected int userid = -1;
		protected int instanceid = -1;
		protected int securityid = -1;
		protected int ownerofsecurity = -1;

		protected bool write = false;
		protected bool delete = false;
		protected bool admin = false;
		
		public SecurityPolicy()
		{
		}
		public SecurityPolicy(int iInstanceId, int iUserId)
		{
			this.userid = iUserId;
			this.instanceid = iInstanceId;
			this.Get();
		}

		
		public void Remove()
		{
			SqlParameter[] arParams = new SqlParameter[1];
			arParams[0] = new SqlParameter("@SecurityId", securityid);
			SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();
			SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSecurityDelete", arParams);			
			con.Close();
		}
		public static void RemoveByInstanceAndUser(int InstanceId, int UserId)
		{
			SqlParameter[] arParams = new SqlParameter[2];
			arParams[0] = new SqlParameter("@InstanceId", InstanceId);
			arParams[1] = new SqlParameter("@UserId", UserId);
			SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();
			SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSecurityRemoveByInstanceAndUser", arParams);			
			con.Close();
		}
		public void Update()
		{
			SqlParameter[] arParams = new SqlParameter[6];
			arParams[0] = new SqlParameter("@InstanceId", instanceid);
			arParams[1] = new SqlParameter("@UserId", userid);
			arParams[2] = new SqlParameter("@Write", write);
			arParams[3] = new SqlParameter("@Delete", delete);
			arParams[4] = new SqlParameter("@Admin", admin);
			arParams[5] = new SqlParameter("@SecurityId", securityid);
			arParams[5].Direction = ParameterDirection.Output;
			SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();
			SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSecuritySet", arParams);			
			con.Close();
			securityid = (int) arParams[5].Value;
		}
		
		public DataSet AccessListGet()
		{
			SqlParameter[] arParams = new SqlParameter[1];
			arParams[0] = new SqlParameter("@InstanceId", instanceid);
			SqlConnection conn = new SqlConnection(ApplicationSettings.ConnectionString);
			conn.Open();
			DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "spSecurityAccessListGet", arParams);			
			conn.Close();
			return ds;
		}

		public void Get()
		{
			SqlParameter[] arParams = new SqlParameter[2];
			arParams[0] = new SqlParameter("@InstanceId", instanceid);
			arParams[1] = new SqlParameter("@UserId", userid);
			SqlConnection conn = new SqlConnection(ApplicationSettings.ConnectionString);
			conn.Open();

			SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "spSecurityGet", arParams);
			if(dr.Read())
			{
				userid					= dr.GetInt32(2);
				//instanceid			=  - она сама по себе инициализирована,то что вернулось в датаридере немножко другое. Его использование смотри ниже
				securityid			= dr.GetInt32(0);
				ownerofsecurity = dr.GetInt32(1);;

                //write		= dr.GetBoolean(3);
                //delete	= dr.GetBoolean(4);
                //admin		= dr.GetBoolean(5);

                write = true;
                delete = true;
                admin = true;
			}
			else
			{
				userid = -1;
				instanceid = -1;
				securityid = -1;
				ownerofsecurity = -1;

				write = false;
				delete = false;
				admin = false;
			}
			conn.Close();
			dr.Close();
		}

		public int UserId
		{
			get
			{
				return userid;
			}
			set
			{
				userid = value;
			}
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
		public int SecurityId
		{
			get
			{
				return securityid;
			}
			set
			{
				securityid = value;
			}
		}
		public int OwnerOfSecurity
		{
			get
			{
				return ownerofsecurity;
			}
			set
			{
				ownerofsecurity = value;
			}
		}
		public bool Write
		{
			get
			{
				return write;
			}
			set
			{
				write = value;
			}
		}
		public bool Delete
		{
			get
			{
				return delete;
			}
			set
			{
				delete = value;
			}
		}
		public bool Admin
		{
			get
			{
				return admin;
			}
			set
			{
				admin = value;
			}
		}
				
	}
}

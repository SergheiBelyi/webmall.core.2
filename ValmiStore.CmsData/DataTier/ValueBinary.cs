using System;
using System.Data;
using System.Web;
using System.IO;
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
	/// 
	
	public class ValueBinary:Value
	{
		protected int binarywidth=0;
		protected int binaryheight=0;
		protected long imagesize=0;

		#region Интерфейс IComparable
		
		public override int CompareTo(object o)
		{
			return 0;
		}
		#endregion


		public long ImageSize
		{
			get
			{
				return imagesize;
			}
		}

		public int BinaryWidth 
		{
			get
			{
				return binarywidth;
			}
			set
			{
				binarywidth = value;
			}
		}
		public int BinaryHeight
		{
			get
			{
				return binaryheight;
			}
			set
			{
				binaryheight = value;
			}
		}

		
		protected DataTypes.BinaryContentType contenttype;
		public DataTypes.BinaryContentType ContentType
		{
			get
			{
				return contenttype;
			}
			set
			{
				contenttype = value;
			}
		}
		public ValueBinary():base()
		{
			type = DataTypes.DataType.ValueBinary;
		}
		public ValueBinary(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, bool pReadFromDB)
		{
			instanceid = pInstanceId;
			fieldid = pFieldId;
			languageid = pLanguageId;
			index = pIndex;			
			type = DataTypes.DataType.ValueInt32;
			GetVALUEFromDB();
		}
		public ValueBinary(int pInstanceId, int pFieldId, int pIndex, int pLanguageId, object pValue)
			: base(pInstanceId, pFieldId, pIndex, DataTypes.DataType.ValueBinary, pLanguageId, pValue)
		{
			GetVALUEFromDB();
			type = DataTypes.DataType.ValueBinary;
		}
		
		public void GetBinaryValueFromDB()
		{
			#region Получаем значения из бд
			SqlParameter[] arParams = new SqlParameter[4];
			arParams[0] = new SqlParameter("@InstanceId", InstanceId);
			arParams[1] = new SqlParameter("@FieldId", FieldId);
			arParams[2] = new SqlParameter("@LanguageId", languageid);
			arParams[3] = new SqlParameter("@Index", Index);
			SqlConnection con= new SqlConnection(ApplicationSettings.ConnectionString);
			con.Open();
			SqlCommand cmd = new SqlCommand("spValueItselfBinaryGet",con);
			cmd.CommandType  = CommandType.StoredProcedure;			
			cmd.Parameters.Add(arParams[0]);
			cmd.Parameters.Add(arParams[1]);
			cmd.Parameters.Add(arParams[2]);
			cmd.Parameters.Add(arParams[3]);
			SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
			
			//SqlDataReader dr = SqlHelper.ExecuteReader(ApplicationSettings.Connection,CommandType.StoredProcedure,"spValueBinaryGet",arParams);
			if(dr.Read())
			{
				
					// Этот код закоментировал чтобы облегчить обмен данными (чтобы не каждый раз получать бинарное содержимое из бд)
					long byteSize = dr.GetBytes(0,0,null,0,0);
					this.imagesize = byteSize;
					byte[] imageData = new byte[byteSize];
					long bytesRead = 0;
                    long curpos = 0;
                    long chunkSize = 512;
					while(bytesRead<byteSize)
					{
                        if (chunkSize > byteSize - curpos) chunkSize = byteSize - curpos;
						bytesRead += dr.GetBytes(0, (int) curpos,imageData,(int) curpos, (int) chunkSize);
						curpos += chunkSize;
					}
					dr.NextResult();
					oValue = imageData;
					// тут нужно сделать чтение из второго селекта встроенной процедуры
					isnull = false;
			}
			else
			{
				oValue = null;
				isnull = true;
			}
			dr.Close();
			con.Close();
			#endregion

		}

		public override void GetVALUEFromDB()
		{
			/*object FromCache = this.GetFromCache();
			if(FromCache !=null)
			{
				this.oValue = FromCache;
			}
			else
			{*/
			#region Получаем значения из бд
				SqlParameter[] arParams = new SqlParameter[4];
				arParams[0] = new SqlParameter("@InstanceId", InstanceId);
				arParams[1] = new SqlParameter("@FieldId", FieldId);
				arParams[2] = new SqlParameter("@LanguageId", languageid);
				arParams[3] = new SqlParameter("@Index", Index);
				//SqlParameter a = new SqlParameter("@Value",SqlDbType.Image);
				//a.Direction = ParameterDirection.Output;
				//arParams[4]=a;
				SqlConnection con= new SqlConnection(ApplicationSettings.ConnectionString);
				con.Open();
				SqlCommand cmd = new SqlCommand("spValueBinaryGet",con);
				cmd.CommandType  = CommandType.StoredProcedure;			
				cmd.Parameters.Add(arParams[0]);
				cmd.Parameters.Add(arParams[1]);
				cmd.Parameters.Add(arParams[2]);
				cmd.Parameters.Add(arParams[3]);
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
			
				//SqlDataReader dr = SqlHelper.ExecuteReader(ApplicationSettings.Connection,CommandType.StoredProcedure,"spValueBinaryGet",arParams);
				if(dr.Read())
				{
					/*
					// Этот код закоментировал чтобы облегчить обмен данными (чтобы не каждый раз получать бинарное содержимое из бд)
					long byteSize = dr.GetBytes(0,0,null,0,0);
					this.imagesize = byteSize;
					byte[] imageData = new byte[byteSize];
					long bytesRead = 0;
					int curpos = 0;
					int chunkSize = 512;
					while(bytesRead<byteSize)
					{
						bytesRead += dr.GetBytes(0,curpos,imageData,curpos,chunkSize);
						curpos +=chunkSize;
					}
					dr.NextResult();
					oValue = imageData;
					// тут нужно сделать чтение из второго селекта встроенной процедуры
					dr.Read();*/
					//con.Close();
					ContentType = (DataTier.DataTypes.BinaryContentType) dr.GetInt32(0);
					binarywidth = dr.GetInt32(1);
					binaryheight = dr.GetInt32(2);
					isnull = false;
				}
				else
				{
					oValue = null;
					isnull = true;
				}
				dr.Close();
				con.Close();
			#endregion
			//Cache.Insert(this.CacheName,this.oValue,null,System.DateTime.Now.AddHours(ApplicationSettings.CacheTimeHours),System.TimeSpan.Zero);
			//}
		}
		public void LoadFromFile(string sPath, DataTypes.BinaryContentType Content)
		{
			FileStream fs = new FileStream (sPath, FileMode.Open, FileAccess.Read);
			byte[] ImageData = new byte[fs.Length];
			fs.Read(ImageData,0,(int)fs.Length);
			oValue = ImageData;
			ContentType = Content;
			fs.Close();
		}
		public void LoadFromStream(Stream Data, DataTypes.BinaryContentType Content)
		{
			byte[] ImageData = new byte[Data.Length];
			Data.Seek(0, SeekOrigin.Begin);
			Data.Read(ImageData, 0, (int) Data.Length);
			oValue = ImageData;
			ContentType = Content;
		}
		public override void PostVALUEToDB()
		{
			if((InstanceId>0)&&(FieldId>0)&&(LanguageId>-1))
			{

				SqlParameter[] arParams = new SqlParameter[9];
				arParams[0] = new SqlParameter("@InstanceId", InstanceId);
				arParams[1] = new SqlParameter("@FieldId", FieldId);
				arParams[2] = new SqlParameter("@LanguageId", this.languageid);
				arParams[3] = new SqlParameter("@Index", Index);
				arParams[4] = GetSQLParam("@Value");
				int j =(int) ContentType;
        
				arParams[5] = new SqlParameter("@ContentType", j);
				arParams[6] = new SqlParameter("@NewIndex",SqlDbType.Int);
				arParams[6].Direction = ParameterDirection.Output;
				arParams[7] = new SqlParameter("@Width", binarywidth);
				arParams[8] = new SqlParameter("@Height", binaryheight);
				SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
				con.Open();
				SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spValueBinaryPost", arParams);
				con.Close();
				this.index = (System.Int32)arParams[6].Value;
							
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
			param.SqlDbType  = SqlDbType.Image;
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
					throw new InvalidCastException("В значение ValueInt32 произошла ошибка преобразования типов: oValue не правильного типа его тип: "+oValue.GetType().ToString());
				}
			}			
			return param;
		}


		
	}
}

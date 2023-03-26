using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Data.Config;
using Data.DataTier.DataTypes;

namespace Data.DataTier
{
    /// <summary>
    /// Summary description for DataTier.
    /// </summary>

    public class Node
    {
        #region Поля
        protected	int tag;
        protected	int classid=0;
        protected string classname;
        protected string actionpage;
        protected int instanceid;
        protected string name;
        protected string alias;
        protected bool visible;
        protected int ordernumber;
        public object parent;
        protected int instancepid;
        public Fields fields;
        public Children children;
        public SecurityPolicy security;
        protected string customneeds;
        #endregion

        #region Конструкторы
                
        public Node()
        {

        }
        public Node (int iInstanceId)
        {
            InstanceId = iInstanceId;
            GetNodeFields();
        }
        public Node(int iInstanceId, int iInstancePid):this()
        {			
            instanceid  = iInstanceId;
            instancepid = iInstancePid;
            GetNodeFields();
        }
        public Node(int iInstanceId, int iInstancePid, bool GetFields):this()
        {			
            instanceid  = iInstanceId;
            instancepid = iInstancePid;
            if(GetFields)
                GetNodeFields();
        }

        public Node(int ClassId, string ClassName):this()
        {
            var arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ClassId", classid);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ClassName", classname);
            arParams[1].Direction = ParameterDirection.InputOutput;
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spNodeClassGet", arParams);
            con.Close();
            classid = (Int32) arParams[0].Value;
            classname = arParams[1].Value.ToString();
        }

        
        #endregion
        
        #region Свойства
        public string CustomNeeds
        {
            get
            {
                return customneeds;
            }
            set
            {
                customneeds = value;
            }
        }
        public int Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }
        public int ClassId
        {
            get
            {
                return classid;
            }
            set
            {
                classid = value;
            }
        }

        public string ActionPage
        {
            get
            {
                return actionpage;
            }
            set
            {
                actionpage = value;
            }
        }

        public string ClassName
        {
            get
            {
                return classname;
            }
            set
            {
                classname = value;
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

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name=value;
            }
        }

        public string Alias
        {
            get
            {
                return alias;
            }
            set
            {
                alias = value;
            }
        }

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
            }
        }

        public int OrderNumber
        {
            get
            {
                return ordernumber;
            }
            set
            {
                ordernumber = value;
            }
        }

        public int InstancePid
        {
            get
            {
                return instancepid;
            }
            set
            {
                instancepid = value;
            }
        }
        #endregion

        #region Методы

        public int Clone()
        {
            var arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InstanceId",InstanceId);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[1] = new SqlParameter("@NewNodeId", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.Output;
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spNodeClone", arParams);		
            con.Close();
            try
            {
                return Convert.ToInt32(arParams[1].Value);
            }
            catch { return 0; }
        }

        public ArrayList AvailableChildClasses()
        {
            var arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@InstanceId",InstanceId);
            arParams[0].Direction = ParameterDirection.Input;
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            var dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spNodeChildrenClass", arParams);		
            var al = new ArrayList();
            while(dr.Read())
            {
                al.Add(new beClass(dr.GetInt32(0),dr.GetString(1)));
            }
            dr.Close();
            con.Close();
            return al;
        }
        
        public static Node Add(Node nd)
        {
            return Add(nd.instanceid,nd.classid,nd.name,nd.alias,nd.visible,nd.ordernumber);
             
        }
        public static Node Add(int iInstancePid, int iClassId, string Name, string Alias, bool Visible, int OrderNumber)
        {
            var arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@InstanceId",SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Output;
            arParams[1] = new SqlParameter("@Name", Name);
            arParams[2] = new SqlParameter("@InstancePid", iInstancePid);
            arParams[3] = new SqlParameter("@ClassId", iClassId);
            arParams[4] = new SqlParameter("@Alias", Alias);
            arParams[5] = new SqlParameter("@Visible", Visible);
            arParams[6] = new SqlParameter("@OrderNumber", OrderNumber);
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spNodeAdd", arParams);		
            con.Close();
            var InstanceId = (Int32) arParams[0].Value;
            var nd = new Node(InstanceId, iInstancePid);
            nd.GetNodeFields();
            return nd;
        }
        
        public static void Delete(Node nd, bool DeleteRecursive)
        {
            var arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InstanceId", nd.instanceid);
            arParams[1] = new SqlParameter("@DeleteRecursive", DeleteRecursive);
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spNodeDelete", arParams);
            con.Close();
        }

        public static void Delete(int NodeId, bool DeleteRecursive)
        {
            var arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InstanceId", NodeId);
            arParams[1] = new SqlParameter("@DeleteRecursive", DeleteRecursive);
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spNodeDelete", arParams);
            con.Close();
        }

        public void GetClass()
        {
            var arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@InstanceId", instanceid);
            arParams[1] = new SqlParameter("@ClassId", classid);
            arParams[1].Direction = ParameterDirection.Output;
            arParams[2] = new SqlParameter("@ClassName", classname);
            arParams[2].Size = 150;
            arParams[2].Direction = ParameterDirection.Output;
            var cn = new SqlConnection(ApplicationSettings.ConnectionString);
            cn.Open();

            SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "spNodeClassGet", arParams);
            classid = (Int32) arParams[1].Value;
            classname = arParams[2].Value.ToString();
            cn.Close();
        }

        public static Children GetFromDBbyAlias(string alias)
        {
            var chldr = new Children();
            var arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Alias", alias);
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            var dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spNodeGetByAlias", arParams);
            while(dr.Read())
            {
                var nd = new Node(dr.GetInt32(0),dr.GetInt32(1));
                chldr.Add(nd);
            }
            dr.Close();
            con.Close();
            return chldr;

        }
        
        public static Children GetFromDBbyClass(string ClassName)
        {
            var chldr = new Children();
            var arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ClassName",SqlDbType.NVarChar,150) {Value = ClassName};
            var conn = new SqlConnection(ApplicationSettings.ConnectionString);
            conn.Open();
            var dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "spNodeGetByClassName", arParams);
            while(dr.Read())
            {
                var nd = new Node(dr.GetInt32(0),dr.GetInt32(1),false);
                chldr.Add(nd);
            }
            dr.Close();
            conn.Close();
            foreach(Node nd in chldr)
            {
                nd.GetNodeFields();
            }
            return chldr;

        }

        public static Children GetFromDBbyClass(string ClassName,int Language)
        {
            var chldr = new Children();
            var arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ClassName",SqlDbType.NVarChar,150);
            arParams[0].Value = ClassName;
            arParams[1] = new SqlParameter("@LanguageId",SqlDbType.Int);
            arParams[1].Value = Language;
            var conn = new SqlConnection(ApplicationSettings.ConnectionString);
            conn.Open();
            var ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "spNodeGetByClassNameAndProps", arParams);
            
            conn.Close();
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var tblInstances = ds.Tables[0];

            foreach(DataRow drInstance in tblInstances.Rows)
            {
                
                var tblFields = ds.Tables[1];
                var tblValueBinary = ds.Tables[2].Select("InstanceId="+drInstance[0].ToString());
                var tblValueDateTime = ds.Tables[3].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueDictionary = ds.Tables[4].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueInt32 = ds.Tables[5].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueNomenclature = ds.Tables[6].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueNumeric = ds.Tables[7].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueString = ds.Tables[8].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueText = ds.Tables[9].Select("InstanceId="+drInstance[0].ToString());;
                
                var ndInstance = new Node();
                ndInstance.InstanceId = (int) drInstance[0];
                if(drInstance[1]!=DBNull.Value)
                {
                    ndInstance.InstancePid = (int) drInstance[1];
                }
                ndInstance.classid =  (int) drInstance[2];
                ndInstance.classname = (string) drInstance[3];
                ndInstance.name = (string) drInstance[4];
                ndInstance.alias = (string) drInstance[5];
                ndInstance.visible = (bool)drInstance[6];
                ndInstance.ordernumber = (int)drInstance[7];
                chldr.Add(ndInstance);
                //----------Создаём филды-------------
                
                #region Fields

                var flds = new Fields();
                flds.InstanceId = ndInstance.InstanceId;
                flds.parent = ndInstance;
                ndInstance.fields = flds;
                foreach(DataRow dr in tblFields.Rows)
                {
                    var fd = new Field();
                    fd.instanceid = ndInstance.InstanceId;
                    fd.fieldid = (int) dr[0];
                    fd.name = (string) dr[2];
                    fd.alias = (string) dr[3];
                    fd.language = Language;
                    fd.maxvalues = (int) dr[8];
                    try
                    {
                        fd.sourceinstanceid = (int) dr[6];
                    }
                    catch
                    {
                    }
                    fd.sortorder = (int) dr[4];
                    fd.controlname = (string) dr[10];
                
                    var o =  Enum.Parse(typeof(DataType),(string) dr[11]);
                    try
                    {
                        fd.dataType =(DataType) o;
                    }
                    catch
                    {
                    }
                    flds.Add(fd);
                    var vls = new Values();
                    vls.FieldId = fd.fieldid;
                    vls.InstanceId = fd.instanceid;
                    vls.Language = fd.language;
                    fd.values = vls;
                    switch(fd.dataType)
                    {
                        case DataType.ValueBinary:
                            //
                            foreach(var drv in tblValueBinary)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vb = new ValueBinary(fd.instanceid,fd.fieldid,(int)drv[5],fd.language,null);
                                    vb.BinaryWidth = (int) drv[6];
                                    vb.BinaryHeight = (int) drv[7];
                                    if((int)drv[4]==1)
                                    {
                                        vb.ContentType = BinaryContentType.Flash;
                                    }
                                    else
                                    {
                                        vb.ContentType = BinaryContentType.Image;
                                    }
                                    vls.Add(vb);
                                }
                            }
                            break;
                        case DataType.ValueDateTime:
                            foreach(var drv in tblValueDateTime)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueDateTime(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueDictionary:

                            break;
                        case DataType.ValueInt32:
                            foreach(var drv in tblValueInt32)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueInt32(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueNomenclature:
                            foreach(var drv in tblValueNomenclature)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueNomenclature(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueNumeric:
                            foreach(var drv in tblValueNumeric)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueNumeric(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueString:
                            foreach(var drv in tblValueString)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueString(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueString0:
                            foreach(var drv in tblValueString)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd0 = new ValueString0(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                    vls.Add(vd0);
                                }
                            }
                            break;
                        case DataType.ValueText:
                            foreach(var drv in tblValueText)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueText(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueXNomenclature:
                            foreach(var drv in tblValueNomenclature)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueNomenclature(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;


                    }
                }
                #endregion
            }
        
            return chldr;

        }

        public static Children GetFromDBbyClass(int ClassId)
        {
            var chldr = new Children();
            var arParams = new SqlParameter[1];
            arParams[1] = new SqlParameter("@ClassId", ClassId);
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            var dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spNodeGetByClassId", arParams);
            while(dr.Read())
            {
                var nd = new Node(dr.GetInt32(0),dr.GetInt32(1));
                chldr.Add(nd);
            }
            dr.Close();
            con.Close();
            return chldr;
        }

        public  Children GetAllChildrenFromDBbyClass(string ClassName)
        {
            var chldr = new Children();
            var arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InstanceId",SqlDbType.Int,4);
            arParams[0].Value = instanceid;
            arParams[1] = new SqlParameter("@ClassName",SqlDbType.NVarChar,500);
            arParams[1].Value = ClassName;
            var conn = new SqlConnection(ApplicationSettings.ConnectionString);
            conn.Open();
            var dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "spNodeGetAllChildrenByClass", arParams);
            while(dr.Read())
            {
                var nd = new Node(dr.GetInt32(0),dr.GetInt32(1),false);
                chldr.Add(nd);
            }
            dr.Close();
            conn.Close();
            foreach(Node nd in chldr)
            {
                nd.GetNodeFields();
            }
            return chldr;

        }

        public void GetNodeFields()
        {
            var arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@InstanceId", instanceid);
            arParams[1] = new SqlParameter("@Name", name);
            arParams[1].Size = 150;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[2] = new SqlParameter("@InstancePid", instancepid);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[3] = new SqlParameter("@ClassId", classid);
            arParams[3].Direction = ParameterDirection.InputOutput;
            arParams[4] = new SqlParameter("@Alias", alias);
            arParams[4].Size = 150;
            arParams[4].Direction = ParameterDirection.InputOutput;
            arParams[5] = new SqlParameter("@Visible", visible);
            arParams[5].Direction = ParameterDirection.InputOutput;
            arParams[6] = new SqlParameter("@OrderNumber", ordernumber);
            arParams[6].Direction = ParameterDirection.InputOutput;
            arParams[7] = new SqlParameter("@ActionPage", actionpage);
            arParams[7].Direction = ParameterDirection.InputOutput;
            arParams[7].Size = 100;
            var cn1 = new SqlConnection(ApplicationSettings.ConnectionString);
            cn1.Open();
            SqlHelper.ExecuteNonQuery(cn1, CommandType.StoredProcedure, "spNodeFieldsGet", arParams);
            if(arParams[1].Value != DBNull.Value)
            name        = (String) arParams[1].Value;
            if(arParams[2].Value != DBNull.Value)
                instancepid = (Int32) arParams[2].Value;
            else
                instancepid = -1;
            try
            {
                classid     = (Int32) arParams[3].Value;
                alias       = (String) arParams[4].Value;
                visible     = (bool) arParams[5].Value;
                ordernumber = (Int32) arParams[6].Value;

                if (arParams[7].Value != DBNull.Value) actionpage  = (string) arParams[7].Value;

                GetClass();
            }
            catch
            {
            }
            cn1.Close();
        }
        
        public void UpdateFieldsToDB()
        {
            var arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@InstanceId", instanceid);
            arParams[1] = new SqlParameter("@Name", name);
            arParams[2] = new SqlParameter("@InstancePid", instancepid);
            arParams[3] = new SqlParameter("@ClassId", classid);
            arParams[4] = new SqlParameter("@Alias", alias);
            arParams[5] = new SqlParameter("@Visible", visible);
            arParams[6] = new SqlParameter("@OrderNumber", ordernumber);
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spNodeFieldsSet", arParams);
            con.Close();
        }

        public void UpdateField(Field fd, int languageId, object value)
        {
            if (fd == null) return;
            var vl = Value.CreateByDataType(fd.dataType);
            vl.InstanceId = InstanceId;
            vl.FieldId = fd.FieldId;
            vl.Index = -1;
            vl.LanguageId = languageId;
            vl.VALUE = value;
            fd.values = new Values(InstanceId, fd.FieldId) {Language = languageId};
            fd.values.RemoveFromDB(languageId);
            fd.values.Add(vl);
            fd.values.PostToDB();
        }

        public Node GetParent()
        {
            var parent = new Node {instanceid = instancepid};
            parent.GetNodeFields();
            return parent;
        }

        public void GetChildren(bool LoadRecursive)
        {
            if (children != null) return;
            var ch = new Children();
            var arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@InstanceId", instanceid);
            var cn1 = new SqlConnection(ApplicationSettings.ConnectionString);
            cn1.Open();
            var dr = SqlHelper.ExecuteReader(cn1, CommandType.StoredProcedure, "spNodeChildrenGetRecursive", arParams);
            while (dr.Read())
            {
                var nd = new Node(dr.GetInt32(0),dr.GetInt32(1));
                nd.ClassId = dr.GetInt32(2);
                nd.ClassName = dr.GetString(3);
                nd.Name = dr.GetString(4);
                nd.Alias = dr.GetString(5);
                nd.Visible =dr.GetBoolean(6);
                nd.OrderNumber = dr.GetInt32(7);
                if(nd.InstancePid == InstanceId)
                {
                    ch.Add(nd);
                }
                else
                {
                    var ndParent = ch.FindByInstanceId(nd.InstancePid);
                    if(ndParent != null)
                    {
                        if(ndParent.children==null)
                        {
                            var c = new Children();
                            ndParent.children = c;
                        }
                        ndParent.children.Add(nd);
                    }
                }
                if (LoadRecursive) nd.GetChildren(LoadRecursive);
            }
            dr.Close();
            cn1.Close();
            children = ch;
        }

        public void GetChildren(bool LoadRecursive, int Language)
        {
            if (children != null) return;
            var ch = new Children();
            var arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InstanceId", instanceid);
            arParams[1] = new SqlParameter("@LanguageId", Language);
            var cn1 = new SqlConnection(ApplicationSettings.ConnectionString);
            cn1.Open();			
            var ds = SqlHelper.ExecuteDataset(cn1, CommandType.StoredProcedure, "spNodeChildrenGetRecursiveProps", arParams);
            cn1.Close();
            var tblInstances = ds.Tables[0];
            foreach(DataRow drInstance in tblInstances.Rows)
            {
                
                var ndInstance = new Node();
                ndInstance.InstanceId = (int) drInstance[0];
                ndInstance.InstancePid = (int) drInstance[1];
                ndInstance.classid =  (int) drInstance[2];
                ndInstance.classname = (string) drInstance[3];
                ndInstance.name = (string) drInstance[4];
                ndInstance.alias = (string) drInstance[5];
                ndInstance.visible = (bool)drInstance[6];
                ndInstance.ordernumber = (int)drInstance[7];

                //nd.GetProperties(Language);
                if(ndInstance.InstancePid == InstanceId)
                {
                    ch.Add(ndInstance);
                }
                else
                {
                    var ndParent = ch.FindByInstanceId(ndInstance.InstancePid);
                    if(ndParent != null)
                    {
                        if(ndParent.children==null)
                        {
                            var c = new Children();
                            ndParent.children = c;
                        }
                        ndParent.children.Add(ndInstance);
                    }
                }
            
                var tblFields = ds.Tables[1].Select("ClassId="+ndInstance.classid.ToString());
                var tblValueBinary = ds.Tables[2].Select("InstanceId="+drInstance[0].ToString());
                var tblValueDateTime = ds.Tables[3].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueDictionary = ds.Tables[4].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueInt32 = ds.Tables[5].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueNomenclature = ds.Tables[6].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueNumeric = ds.Tables[7].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueString = ds.Tables[8].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueText = ds.Tables[9].Select("InstanceId="+drInstance[0].ToString());;
                //----------Создаём филды-------------				
                #region Fields

                var flds = new Fields();
                flds.InstanceId = ndInstance.InstanceId;
                flds.parent = ndInstance;
                ndInstance.fields = flds;
                foreach(var dr in tblFields)
                {
                    var fd = new Field();
                    fd.instanceid = ndInstance.InstanceId;
                    fd.fieldid = (int) dr[0];
                    fd.name = (string) dr[2];
                    fd.alias = (string) dr[3];
                    fd.language = Language;
                    fd.maxvalues = (int) dr[8];
                    try
                    {
                        fd.sourceinstanceid = dr[6] != DBNull.Value ? (int) dr[6] : 0;
                    }
                    catch
                    {
                    }
                    fd.sortorder = (int) dr[4];
                    fd.controlname = (string) dr[10];
                
                    var o =  Enum.Parse(typeof(DataType),(string) dr[11]);
                    try
                    {
                        fd.dataType =(DataType) o;
                    }
                    catch
                    {
                    }
                    flds.Add(fd);
                    var vls = new Values();
                    vls.FieldId = fd.fieldid;
                    vls.InstanceId = fd.instanceid;
                    vls.Language = fd.language;
                    fd.values = vls;
                    switch(fd.dataType)
                    {
                        case DataType.ValueBinary:
                            //
                            foreach(var drv in tblValueBinary)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vb = new ValueBinary(fd.instanceid,fd.fieldid,(int)drv[5],fd.language,null);
                                    vb.BinaryWidth = (int) drv[6];
                                    vb.BinaryHeight = (int) drv[7];
                                    vls.Add(vb);
                                }
                            }
                            break;
                        case DataType.ValueDateTime:
                            foreach(var drv in tblValueDateTime)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueDateTime(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueDictionary:

                            break;
                        case DataType.ValueInt32:
                            foreach(var drv in tblValueInt32)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueInt32(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueNomenclature:
                            foreach(var drv in tblValueNomenclature)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueNomenclature(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueNumeric:
                            foreach(var drv in tblValueNumeric)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueNumeric(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueString:
                            foreach(var drv in tblValueString)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueString(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueString0:
                            foreach(var drv in tblValueString)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd0 = new ValueString0(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                    vls.Add(vd0);
                                }
                            }
                            break;
                        case DataType.ValueText:
                            foreach(var drv in tblValueText)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueText(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueXNomenclature:
                            foreach(var drv in tblValueNomenclature)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueNomenclature(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;


                    }
                }
                #endregion
            }
            children = ch;

        }

        public void GetChildren(int Depth)
        {
            if (children != null) return;
            var ch = new Children();
            var arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InstanceId", instanceid);
            arParams[1] = new SqlParameter("@Depth", Depth);
            var cn1 = new SqlConnection(ApplicationSettings.ConnectionString);
            cn1.Open();
            var dr = SqlHelper.ExecuteReader(cn1, CommandType.StoredProcedure, "spNodeChildrenGetDepth", arParams);
            while(dr.Read())
            {
                var nd = new Node(dr.GetInt32(0),dr.GetInt32(1));
                nd.ClassId = dr.GetInt32(2);
                nd.ClassName = dr.GetString(3);
                nd.Name = dr.GetString(4);
                nd.Alias = dr.GetString(5);
                nd.Visible =dr.GetBoolean(6);
                nd.OrderNumber = dr.GetInt32(7);
                if(nd.InstancePid == InstanceId)
                {
                    ch.Add(nd);
                }
                else
                {
                    var ndParent = ch.FindByInstanceId(nd.InstancePid);
                    if(ndParent != null)
                    {
                        if(ndParent.children==null)
                        {
                            var c = new Children();
                            ndParent.children = c;
                        }
                        ndParent.children.Add(nd);
                    }
                }
                /*	if(LoadRecursive)
                        nd.GetChildren(LoadRecursive);*/
            }
            dr.Close();
            cn1.Close();
            children = ch;
        }
        public void GetChildren(int Depth, int Language)
        {
            if (children != null) return;
            var ch = new Children();
            var arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@InstanceId", instanceid);
            arParams[1] = new SqlParameter("@Depth", Depth);
            arParams[2] = new SqlParameter("@LanguageId", Language);
            var cn1 = new SqlConnection(ApplicationSettings.ConnectionString);
            cn1.Open();
            var ds = SqlHelper.ExecuteDataset(cn1, CommandType.StoredProcedure, "spNodeChildrenGetDepthProps", arParams);
            cn1.Close();
            var tblInstances = ds.Tables[0];

            foreach(DataRow drInstance in tblInstances.Rows)
            {
                
                var ndInstance = new Node();
                ndInstance.InstanceId = (int) drInstance[0];
                ndInstance.InstancePid = (int) drInstance[1];
                ndInstance.classid =  (int) drInstance[2];
                ndInstance.classname = (string) drInstance[3];
                ndInstance.name = (string) drInstance[4];
                ndInstance.alias = (string) drInstance[5];
                ndInstance.visible = (bool)drInstance[6];
                ndInstance.ordernumber = (int)drInstance[7];

                //nd.GetProperties(Language);
                if(ndInstance.InstancePid == InstanceId)
                {
                    ch.Add(ndInstance);
                }
                else
                {
                    var ndParent = ch.FindByInstanceId(ndInstance.InstancePid);
                    if(ndParent != null)
                    {
                        if(ndParent.children==null)
                        {
                            var c = new Children();
                            ndParent.children = c;
                        }
                        ndParent.children.Add(ndInstance);
                    }
                }
            
                var tblFields = ds.Tables[1].Select("ClassId="+ndInstance.classid.ToString());
                var tblValueBinary = ds.Tables[2].Select("InstanceId="+drInstance[0].ToString());
                var tblValueDateTime = ds.Tables[3].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueDictionary = ds.Tables[4].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueInt32 = ds.Tables[5].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueNomenclature = ds.Tables[6].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueNumeric = ds.Tables[7].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueString = ds.Tables[8].Select("InstanceId="+drInstance[0].ToString());;
                var tblValueText = ds.Tables[9].Select("InstanceId="+drInstance[0].ToString());;
                //----------Создаём филды-------------				
                #region Fields

                var flds = new Fields();
                flds.InstanceId = ndInstance.InstanceId;
                flds.parent = ndInstance;
                ndInstance.fields = flds;
                foreach(var dr in tblFields)
                {
                    var fd = new Field();
                    fd.instanceid = ndInstance.InstanceId;
                    fd.fieldid = (int) dr[0];
                    fd.name = (string) dr[2];
                    fd.alias = (string) dr[3];
                    fd.language = Language;
                    fd.maxvalues = (int) dr[8];
                    try
                    {
                        fd.sourceinstanceid = (int) dr[6];
                    }
                    catch
                    {
                    }
                    fd.sortorder = (int) dr[4];
                    fd.controlname = (string) dr[10];
                
                    var o =  Enum.Parse(typeof(DataType),(string) dr[11]);
                    try
                    {
                        fd.dataType =(DataType) o;
                    }
                    catch
                    {
                    }
                    flds.Add(fd);
                    var vls = new Values();
                    vls.FieldId = fd.fieldid;
                    vls.InstanceId = fd.instanceid;
                    vls.Language = fd.language;
                    fd.values = vls;
                    switch(fd.dataType)
                    {
                        case DataType.ValueBinary:
                            //
                            foreach(var drv in tblValueBinary)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vb = new ValueBinary(fd.instanceid,fd.fieldid,(int)drv[5],fd.language,null);
                                    vb.BinaryWidth = (int) drv[6];
                                    vb.BinaryHeight = (int) drv[7];
                                    vls.Add(vb);
                                }
                            }
                            break;
                        case DataType.ValueDateTime:
                            foreach(var drv in tblValueDateTime)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueDateTime(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueDictionary:

                            break;
                        case DataType.ValueInt32:
                            foreach(var drv in tblValueInt32)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueInt32(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueNomenclature:
                            foreach(var drv in tblValueNomenclature)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueNomenclature(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueNumeric:
                            foreach(var drv in tblValueNumeric)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueNumeric(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueString:
                            foreach(var drv in tblValueString)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueString(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueString0:
                            foreach(var drv in tblValueString)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd0 = new ValueString0(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                    vls.Add(vd0);
                                }
                            }
                            break;
                        case DataType.ValueText:
                            foreach(var drv in tblValueText)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueText(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;
                        case DataType.ValueXNomenclature:
                            foreach(var drv in tblValueNomenclature)
                            {
                                if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                                {
                                    var vd = new ValueNomenclature(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                    vls.Add(vd);
                                }
                            }
                            break;


                    }
                }
                #endregion
            }
            children = ch;
        }
        public void GetPropertiesOld(int Language)
        {
            if(ClassId<1)
            {
                GetNodeFields();
            }
            fields = new Fields(instanceid, classid, true,true,Language);
        }

        public void GetProperties(int Language)
        {
            if (fields != null) return;
            var arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InstanceId", instanceid);
            arParams[1] = new SqlParameter("@LanguageId", Language);
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            var ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spNodeGetProperties", arParams);
            con.Close();
            var tblFields = ds.Tables[0];
            var tblValueBinary = ds.Tables[1];
            var tblValueDateTime = ds.Tables[2];
            var tblValueDictionary = ds.Tables[3];
            var tblValueInt32 = ds.Tables[4];
            var tblValueNomenclature = ds.Tables[5];
            var tblValueNumeric = ds.Tables[6];
            var tblValueString = ds.Tables[7];
            var tblValueText = ds.Tables[8];
            //----------Создаём филды-------------
            var flds = new Fields();
            flds.InstanceId = InstanceId;
            flds.parent = this;
            fields = flds;
            foreach(DataRow dr in tblFields.Rows)
            {
                var fd = new Field();
                fd.instanceid = InstanceId;
                fd.fieldid = (int) dr[0];
                fd.name = (string) dr[2];
                fd.alias = (string) dr[3];
                fd.language = Language;
                fd.maxvalues = (int) dr[8];

                if (dr[6] != DBNull.Value) fd.sourceinstanceid = (int) dr[6];

                fd.sortorder = (int) dr[4];
                fd.controlname = (string) dr[10];
                
                var o =  Enum.Parse(typeof(DataType),(string) dr[11]);
                try
                {
                    fd.dataType =(DataType) o;
                }
                catch
                {
                }
                flds.Add(fd);
                var vls = new Values();
                vls.FieldId = fd.fieldid;
                vls.InstanceId = fd.instanceid;
                vls.Language = fd.language;
                fd.values = vls;
                switch(fd.dataType)
                {
                    case DataType.ValueBinary:
                        //
                        foreach(DataRow drv in tblValueBinary.Rows)
                        {
                            if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                            {
                                var vb = new ValueBinary(fd.instanceid,fd.fieldid,(int)drv[5],fd.language,null);
                                vb.BinaryWidth = (int) drv[6];
                                vb.BinaryHeight = (int) drv[7];
                                vls.Add(vb);
                            }
                        }
                        break;
                    case DataType.ValueDateTime:
                        foreach(DataRow drv in tblValueDateTime.Rows)
                        {
                            if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                            {
                                var vd = new ValueDateTime(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                vls.Add(vd);
                            }
                        }
                        break;
                    case DataType.ValueDictionary:

                        break;
                    case DataType.ValueInt32:
                        foreach(DataRow drv in tblValueInt32.Rows)
                        {
                            if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                            {
                                var vd = new ValueInt32(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                vls.Add(vd);
                            }
                        }
                        break;
                    case DataType.ValueNomenclature:
                        foreach(DataRow drv in tblValueNomenclature.Rows)
                        {
                            if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                            {
                                var vd = new ValueNomenclature(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                vls.Add(vd);
                            }
                        }
                        break;
                    case DataType.ValueNumeric:
                        foreach(DataRow drv in tblValueNumeric.Rows)
                        {
                            if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                            {
                                var vd = new ValueNumeric(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                vls.Add(vd);
                            }
                        }
                        break;
                    case DataType.ValueString:
                        foreach(DataRow drv in tblValueString.Rows)
                        {
                            if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                            {
                                var vd = new ValueString(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                vls.Add(vd);
                            }
                        }
                        break;
                    case DataType.ValueString0:
                        foreach(DataRow drv in tblValueString.Rows)
                        {
                            if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                            {
                                var vd0 = new ValueString0(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                vls.Add(vd0);
                            }
                        }
                        break;
                    case DataType.ValueText:
                        foreach(DataRow drv in tblValueText.Rows)
                        {
                            if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                            {
                                var vd = new ValueText(fd.instanceid,fd.fieldid,(int)drv[4],fd.language,drv[2]);
                                vls.Add(vd);
                            }
                        }
                        break;
                    case DataType.ValueXNomenclature:
                        foreach(DataRow drv in tblValueNomenclature.Rows)
                        {
                            if((fd.instanceid==(int)drv[0])&&(fd.fieldid==(int)drv[1]))
                            {
                                var vd = new ValueNomenclature(fd.instanceid,fd.fieldid,(int)drv[3],fd.language,drv[2]);
                                vls.Add(vd);
                            }
                        }
                        break;


                }
            }
            //------------------------
            
        }
        #endregion

        #region Статичные методы
        private static string GetImageURL(Field fld)
        {
            try
            {
                return "ShowImage.ashx?InstanceId=" + fld.InstanceId.ToString() + "&FieldId=" + fld.FieldId.ToString() + "&Language=" + ApplicationSettings.Language.ToString() + "&IndexId=0";
            }
            catch { return "images/1x1.gif"; }
        }

        public static string fnGetUrlImage(object pNode, string FieldName)
        {
            var nd = pNode as Node;

            if(nd == null)
            {
                return String.Empty;
            }

            nd.GetProperties(ApplicationSettings.Language);
            return GetImageURL(nd.fields.FindByAlias(FieldName));
        }

        public static int GetImageHeight (object pNode)
        {
            var nd = pNode as Node;

            if (nd == null)
            {
                return 0;
            }

            nd.GetProperties(ApplicationSettings.Language);
            if (nd.fields[0].values[0] == null)
            {
                nd.fields = null;
                nd.GetProperties(0);
            }
            var valueBinary = nd.fields[0].values[0] as ValueBinary;
            return valueBinary != null ? valueBinary.BinaryHeight : 0;
        }

        public static string fnGetXNomenclatureUrlImage(object pNode, string FieldName,int NodeIndex,string FieldXName)
        {
            var nd = pNode as Node;
            try
            {
                var ndX = nd.fields[FieldName].cldNodesXValuesSelected[NodeIndex];
                if(ndX == null)
                {
                    return String.Empty;
                }
            
                return GetImageURL(ndX.fields[FieldXName]);
            }
            catch
            {
            }
            return String.Empty;
        }
        public static string fnGetXNomenclatureString(object pNode, string FieldName,int NodeIndex,string FieldXName)
        {
            var nd = pNode as Node;
            try
            {
                var ndX = nd.fields[FieldName].cldNodesXValuesSelected[NodeIndex];
                if(ndX == null)
                {
                    return String.Empty;
                }
            
                return ndX.fields[FieldXName].values[0].VALUE.ToString();
            }
            catch
            {
            }
            return String.Empty;
        }
        
        public static string fnGetValueFromField(object pNode, string FieldName)
        {
            return fnGetValueFromField(pNode, FieldName, "");
        }

        public static string fnGetValueFromField(object pNode, string FieldName, string format)
        {
            var nd = pNode as Node;
            
            if(nd == null)
            {
                return String.Empty;
            }
            if (nd.fields == null) nd.GetProperties(ApplicationSettings.Language);
            try
            {
                if (nd.fields.FindByAlias(FieldName)?.values?[0] != null)
                {
                    if (nd.fields.FindByAlias(FieldName).values[0].VALUE.GetType() != typeof(DateTime))
                    {
                        return nd.fields.FindByAlias(FieldName).values[0].VALUE.ToString();
                    }
                    var dt = (DateTime)nd.fields.FindByAlias(FieldName).values[0].VALUE;
                    return string.IsNullOrWhiteSpace(format) ? dt.ToShortDateString() : dt.ToString(format);
                }
            }
            catch
            {
                return String.Empty;
            }
            return String.Empty;
        }

        public static string fnGetValueFromField0(object pNode, string FieldName)
        {
            var nd = pNode as Node;
            //if (nd.fields == null) 
            if (nd == null)
            {
                return String.Empty;
            }
            nd.fields = null;
            nd.GetProperties(0);
            try
            {
                if (nd.fields.FindByAlias(FieldName)?.values[0] == null)
                    return null;
                if (nd.fields.FindByAlias(FieldName).values[0].VALUE.GetType() != typeof(DateTime))
                {
                    return nd.fields.FindByAlias(FieldName).values[0].VALUE.ToString();
                }
                else
                {
                    var dt = (DateTime)nd.fields.FindByAlias(FieldName).values[0].VALUE;
                    return dt.ToShortDateString();
                }
            }
            catch
            {
                return String.Empty; //return "Не заполнено";
            }
            finally
            {
                nd.fields = null;
            }
        }
        
        #endregion

        public Children References()
        {
            var ch = new Children();
            var arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@InstanceId", instanceid);
            var con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            var dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spNodeReferences", arParams);
            while(dr.Read())
            {
                var nd = new Node();
                nd.InstanceId = dr.GetInt32(0);
                nd.GetNodeFields();
                ch.Add(nd);
            }
            dr.Close();
            con.Close();
            return ch;			
        }

    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Data.Config;

namespace Data.DataTier
{
	public class Tree
	{
        public static void LoadNodeChilds(TreeItem ParentNode, bool treeFullLoad)
		{
			DataTable TData = Data.DataTier.Tree.ReadTreeTable(ParentNode.ID);

			foreach (DataRow row in TData.Rows)
			{
				var newNode = new TreeItem();

				newNode.Text = row["Name"].ToString();
				newNode.ID = row["InstanceId"].ToString();
                newNode.HasChilds = NodeHasChilds(newNode.ID);
                newNode.IsVisible = (bool)row["Visible"];

				ParentNode.Nodes.Add(newNode);

                if (treeFullLoad) LoadNodeChilds(newNode, treeFullLoad);
			}
		}

        public static DataTable ReadTreeTable()
        {
            return ReadTreeTable(String.Empty);
        }
        
        public static DataTable ReadTreeTable(string ParentId)
        {
            SqlConnection sqlCon = new SqlConnection(ApplicationSettings.ConnectionString);
            sqlCon.Open();
			SqlDataAdapter Reader = new SqlDataAdapter("SELECT * FROM tblInstance WHERE InstancePid" + (string.IsNullOrEmpty(ParentId) ? " IS NULL" : " = " + ParentId) + " ORDER BY OrderNumber", sqlCon);
            DataTable result = new DataTable();
            Reader.Fill(result);
			Reader.Dispose();
			sqlCon.Close();
			return result;
        }

		public static bool NodeHasChilds(string NodeId)
		{
			SqlConnection sqlCon = new SqlConnection(ApplicationSettings.ConnectionString);
			sqlCon.Open();
			SqlCommand com = new SqlCommand("SELECT count(*) FROM tblInstance WHERE InstancePid = " + NodeId, sqlCon);
			object res = com.ExecuteScalar();
			com.Dispose();
			sqlCon.Close();
			return Convert.ToInt32(res) > 0;
		}

		public string ExpandTree(int NodeId)
		{
			SqlParameter[] arParams = new SqlParameter[1];
			arParams[0] = new SqlParameter("@current", NodeId);
			SqlConnection sqlCon = new SqlConnection(ApplicationSettings.ConnectionString);
			sqlCon.Open();
			XmlReader dr =  SqlHelper.ExecuteXmlReader(sqlCon, CommandType.StoredProcedure, "spTreeExpand", arParams);
				
			DataSet datasetExpand = new DataSet();
			datasetExpand.DataSetName = "ROOT";
			datasetExpand.ReadXml(dr, XmlReadMode.InferSchema);
			string res = datasetExpand.GetXml();
			datasetExpand.Dispose();
			dr.Close();
			sqlCon.Close();
			return res;
			// Put user code to initiali

		}
	
		public static string NodesAccessPolicyForUser(int UserId)
		{

			SqlParameter[] arParams = new SqlParameter[1];
			arParams[0] = new SqlParameter("@UserId", UserId);
			SqlConnection sqlCon = new SqlConnection(ApplicationSettings.ConnectionString);
			sqlCon.Open();
			XmlReader dr =  SqlHelper.ExecuteXmlReader(sqlCon, CommandType.StoredProcedure, "spSecurityUserNodesGet", arParams);
				
			DataSet datasetExpand = new DataSet();
			datasetExpand.DataSetName = "ROOT";
			datasetExpand.ReadXml(dr, XmlReadMode.InferSchema);
			string res = datasetExpand.GetXml();
			datasetExpand.Dispose();
			sqlCon.Close();
			return res;
		}

		public string NodesPossibilityToMove(int NodeId, int UserId)
		{
			SqlParameter[] arParams = new SqlParameter[2];
			arParams[0] = new SqlParameter("@NodeId", NodeId);
			arParams[1] = new SqlParameter("@UserId", UserId);
			SqlConnection sqlCon = new SqlConnection( ApplicationSettings.ConnectionString);
			sqlCon.Open();
			XmlReader dr =  SqlHelper.ExecuteXmlReader(sqlCon, CommandType.StoredProcedure, "spTreePossibilityToMove", arParams);
				
			DataSet datasetExpand = new DataSet();
			datasetExpand.DataSetName ="ROOT";
			datasetExpand.ReadXml(dr, XmlReadMode.InferSchema);
			string res = datasetExpand.GetXml();
			datasetExpand.Dispose();
			sqlCon.Close();
			return res;

		}
	}

    public class TreeItem
    {
        public TreeItem()
        {
            Nodes = new List<TreeItem>();
        }

        public string ID { get; set; }
        public string Text { get; set; }
        public bool HasChilds { get; set; }
        public List<TreeItem> Nodes { get; private set; }
        public bool IsVisible { get; set; }
    }
}

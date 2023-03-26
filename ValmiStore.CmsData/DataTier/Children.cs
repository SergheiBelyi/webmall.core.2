using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Data.Config;
using Data.DataTier.Comparers;

namespace Data.DataTier
{
	/// <summary>
	/// Summary description for Children.
	/// </summary>
	public class Children: IEnumerable
	{		
		protected ArrayList children;
		public object parent;

		public ArrayList InnerArray
		{
			get
			{
				return children;
			}
		}

		public Children()
		{
			children = new ArrayList();
		}

		#region Сортировка
		public void Sort(string fieldName, int valueIndex, bool @ascending)
		{
			if(@ascending)
			{
				var cmp = new ChildrenSortAsc {FieldName = fieldName, ValueIndex = valueIndex};
			    var cmpr = cmp as IComparer;
				if(cmpr != null)
				{
					children.Sort(cmpr);
				}
			}
			else
			{
				var cmp = new ChildrenSortDesc {FieldName = fieldName, ValueIndex = valueIndex};
			    var cmpr = cmp as IComparer;
				if(cmpr != null)
				{
					children.Sort(cmpr);
				}
			}
		}
		#endregion

		// Метод для индексатора
		public void GetNodesProperties(int language)
		{
			foreach(Node nd in this)
			{
				nd.GetProperties(language);
				if(nd.children!=null)
				{
					nd.children.GetNodesProperties(language);
				}
			}
		}

		public Node this[int index]
		{
			get
			{
				return children[index] as Node;
			}
			set
			{
				children[index]= value;
			}
		}
		public void Add(Node nd)
		{
			nd.parent = this;
			children.Add(nd);
		}

		public void Remove(Node nd)
		{
			children.Remove(nd);
		}

		public void Remove(int instanceId)
		{
			for (int i = 0 ; i < Count ; i++)
			{
				if ( this[i].InstanceId == instanceId ) 
				{
					Remove (this[i]);
					return ;
				}
			}
		}
		public Node FindByClassName(string className)
		{
			foreach(Node nd in children)
			{
				if(nd.ClassName == className)
				{
					return nd;
				}
				if(nd.children!=null)
				{
					Node ndD = nd.children.FindByClassName(className);
					if(ndD!=null)return ndD;
				}
			}
			return null;
		}
		public Children FindByClassName(string className, bool firstOnly)
		{
			Children cd = new Children();
			if(firstOnly)
			{
				Node nd = FindByClassName(className);
				if(nd!=null)
				{
					cd.Add(nd);
				}
			}
			else
			{
				
				foreach(Node nd in children)
				{
					if(nd.ClassName == className)
					{
						cd.Add(nd);
					}
				}
				
			}
			return cd;
		}
		public Children FindByClassName(string className, int level)
		{
			Children cd = new Children();
			foreach(Node nd in children)
			{
				if(nd.ClassName == className)
				{
					cd.Add(nd);
				}
				if((nd.children!=null)&&(level>=0))
				{
					Children cds = nd.children.FindByClassName(className,level-1);
					foreach(Node ndD in cds)
					{
						cd.Add(ndD);
					}
							
				}
								
			}
			return cd;
		}
		public Children FindByInstancePid(int instancePid)
		{
			Children cd = new Children();
			foreach(Node nd in children)
			{
				if(nd.InstancePid == instancePid)
				{
					cd.Add(nd);
				}
			}
			return cd;
		}
		public Node FindByInstanceId(int iInstanceId)
		{
			foreach(Node nd in children)
			{
				if(nd.InstanceId == iInstanceId)
				{
					return nd;
				}
				if(nd.children != null)
				{
					Node ndD = nd.children.FindByInstanceId(iInstanceId);
					if(ndD != null)
						return ndD;
				}
				
			}
			return null;
		}
		public Node FindByAlias(string alias)
		{
			foreach(Node nd in children)
			{
				if(nd.Alias.ToLower() == alias.ToLower())
				{
					return nd;
				}
			}
			return null;
		}

		public void GetByAlias(string alias, ref Children result)
		{
			foreach(Node nd in children)
			{
				if(nd.Alias == alias)
				{
					result.Add(nd);
				}
				if(nd.children!=null)
				{
					nd.children.GetByAlias(alias,ref result);
				}
			}
		}

		public  void GetByClassNameFromDB(string className)
		{
			//Children ch = new Children();
			SqlParameter[] arParams = new SqlParameter[1];
			arParams[0] = new SqlParameter("@ClassName", className);
			SqlConnection cn = new SqlConnection(ApplicationSettings.ConnectionString);
			cn.Open();
			SqlDataReader dr = SqlHelper.ExecuteReader(cn, CommandType.StoredProcedure, "spChildrenGetByClass", arParams);
			while(dr.Read())
			{
			    var nd = new Node {InstanceId = dr.GetInt32(0), InstancePid = dr.GetInt32(1)};
			    nd.GetNodeFields();
				Add(nd);
			}
			dr.Close();
			cn.Close();
		}
		public int Count
		{
			get
			{
				return children.Count;
			}
		}
		public void RemoveAllInvisible()
		{
			var ch = new ArrayList();
			foreach(Node nd in children)
			{
				try
				{
					if(nd.Visible)
					{					
						ch.Add(nd);	
						try
						{
							if(nd.children != null)nd.children.RemoveAllInvisible();
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
			children = ch;
		}

	
		public IEnumerator GetEnumerator()
		{
			return children.GetEnumerator();
		}
		
	

	}
}

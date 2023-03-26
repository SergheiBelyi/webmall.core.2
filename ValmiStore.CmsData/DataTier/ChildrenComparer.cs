using System.Collections;

namespace Data.DataTier.Comparers
{
	/// <summary>
	/// Summary description for ChildrenComparer.
	/// </summary>
	public class ChildrenSortAsc:IComparer
	{
		public ChildrenSortAsc()
		{
		}
		protected string fieldname;
		protected int valueindex;

		public string FieldName
		{
			set
			{
				fieldname = value;
			}
		}
		public int ValueIndex
		{
			set
			{
				valueindex = value;
			}
		}

		public int Compare(object P1, object P2)
		{
			Node nd1 = P1 as Node;
			Node nd2 = P2 as Node;
			if((nd1!=null)&&(nd2!=null))
			{
				try
				{
					Value vl1 = nd1.fields.FindByAlias(fieldname).values[valueindex];
					Value vl2 = nd2.fields.FindByAlias(fieldname).values[valueindex];
					int CompareResult = vl1.CompareTo(vl2);
					if(CompareResult==0)
					{
						return vl1.InstanceId.CompareTo(vl2.InstanceId);
					}

					return CompareResult;
				}
				catch
				{
					return 0;
				}
			}
			else
			{
				return 0;
			}

		}
	}

	public class ChildrenSortDesc:IComparer
	{
	    protected string fieldname;
		protected int valueindex;

		public string FieldName
		{
			set
			{
				fieldname = value;
			}
		}
		public int ValueIndex
		{
			set
			{
				valueindex = value;
			}
		}

		public int Compare(object P1, object P2)
		{
			Node nd1 = P1 as Node;
			Node nd2 = P2 as Node;
			if((nd1!=null)&&(nd2!=null))
			{
				try
				{
					if (fieldname == "InstanceId")
						return nd1.InstanceId.CompareTo(nd2.InstanceId);
					Value vl1 = nd1.fields.FindByAlias(fieldname).values[valueindex];
					Value vl2 = nd2.fields.FindByAlias(fieldname).values[valueindex];
					return vl2.CompareTo(vl1);
				}
				catch
				{
					return 0;
				}
			}
			else
			{
				return 0;
			}

		}
	}

}

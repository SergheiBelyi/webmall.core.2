using System;

namespace Data.DataTier
{
	/// <summary>
	/// Summary description for beClass.
	/// </summary>
	public class beClass
	{
		protected int id;
		protected string name;
		public beClass()
		{
		}
		
		public beClass(int iId, string sName):this()
		{
			this.id=iId;
			this.Name=sName;
		}

		public int Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
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
				name = value;
			}
		}
		
	}
}

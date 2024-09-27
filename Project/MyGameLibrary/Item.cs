using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Fall2020_CSC403_Project.code
{
	public class Item
	{
		public int ItemNum { get; set; }
		public string Name { get; set; }

		// item constructor w/ parameters
		public Item(int itemNum, string name)
		{
			ItemNum = itemNum;
			Name = name;
		}
		// creates new instance of items
		public Item Clone()
		{
			return new Item(ItemNum, Name);
		}
	}
}

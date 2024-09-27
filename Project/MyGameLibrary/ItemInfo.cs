using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Fall2020_CSC403_Project.code
{
	public static class ItemInfo
	{
		private static List<Item> _gameItem;
		static ItemInfo()
		{
			// creating the items for the game
			_gameItem = new List<Item>();
			// creating boss weapon
			_gameItem.Add(new Weapon(01, "Stapler", 5));
			// creating first health item
			_gameItem.Add(new HealthItem(02, "Water Cup", 10));
			// starting weapon
			_gameItem.Add(new Weapon(03, "Pencil", 1));
			// third weapon
			_gameItem.Add(new Weapon(04, "Mouse", 3));
		}
		// instantiates the items
		public static Item CreateItem(int itemNum)
		{
			// Looks through list for item with the itemNum
			Item regularItem = _gameItem.FirstOrDefault(item => item.ItemNum == itemNum);
			if (regularItem != null)
			{
				// if there is a matach, a new instance of the item is created
				return regularItem.Clone();
			}
			return null;
		}
	}
}

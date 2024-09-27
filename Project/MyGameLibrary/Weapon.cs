using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Fall2020_CSC403_Project.code
{
	public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Number { get; set; }
	// weapon constructor w/ parameters
        public Weapon(int itemNum, string name, int damage) 
            : base(itemNum, name)
        {
	    // weapon properties
            Damage = damage;
            Number = itemNum;
        }
	// create new instance of weapons
        public new Weapon Clone()
        {
            return new Weapon(ItemNum, Name, Damage);
        }
    }
}

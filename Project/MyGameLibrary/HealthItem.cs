using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Fall2020_CSC403_Project.code
{
	public class HealthItem : Item
	{
		public int Health { get; set; }
	// HealthItem constructor w/ paremeters
        public HealthItem(int itemNum, string name, int health) 
            : base(itemNum, name)
        {
	    // HealthItem properties
            Health = health;
        }
    }
	}

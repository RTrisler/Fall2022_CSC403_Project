using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 1591 // use this to disable comment warnings

namespace Fall2020_CSC403_Project.code {
    public class Inventory {
        List<object> inventoryList= new List<object>{};

        public void add(object newItem)
        {
            inventoryList.Add(newItem);
        }

        public List<object> getInventoryList()
        {
            return inventoryList;
        }
    }
}

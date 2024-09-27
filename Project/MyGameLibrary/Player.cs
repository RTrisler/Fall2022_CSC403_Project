using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2020_CSC403_Project.code {
  public class Player : BattleCharacter {

    public static Inventory inventory = new Inventory();
    public Player(Vector2 initPos, Collider collider) : base(initPos, collider) {

    }

    public List<object> getInventory()
        {
            return inventory.getInventoryList();
        }
    public void removeInventoryItem(object item)
    {
       inventory.drop(item);
    }

    public void addToInventory(object item)
    {
        inventory.add(item);
    }
    }
}

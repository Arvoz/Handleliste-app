using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class UserInventory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    } 
}

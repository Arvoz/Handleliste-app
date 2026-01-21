using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class GetAllInventoriesDto
    {
        public List<GetInventoryDto>? Inventories { get; set; }
    }
}

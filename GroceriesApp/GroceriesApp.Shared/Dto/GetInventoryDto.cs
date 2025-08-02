using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class GetInventoryDto
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<GetInventoryItemDto>? Ingrediens { get; set; }
    }
}

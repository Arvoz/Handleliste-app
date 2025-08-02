using GroceriesApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Api;

public class InventoryRepository : Repository<Inventory>, IInventoryReposotory
{
    public InventoryRepository(GroceriesAppDb db) : base(db)
    {

    }
    public async Task<Inventory?> GetByNameAsync(string name)
    {
        var inventory = await _db.Inventories.FirstOrDefaultAsync(i => i.Name == name);

        if (inventory == null) return null;

        return inventory;
    }


    public async Task<bool> CheckUserInventory(int userId, string name)
    {
        var existing = await _db.UserInventory
             .Include(ui => ui.Inventory)
             .FirstOrDefaultAsync(n => n.Inventory!.Name == name && n.UserId == userId);

        if (existing != null) return false;

        return true;
    }
}

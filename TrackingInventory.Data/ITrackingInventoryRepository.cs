using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingInventory.Models.entities;

namespace TrackingInventory.Data
{
    public interface ITrackingInventoryRepository
    {
        Task<IEnumerable<InventoryTracker>> GetItemsAsync();
        Task<InventoryTracker> GetItemAsync(string name);
        Task CreateItemAsync(InventoryTracker item);
        Task UpdateItemAsync(InventoryTracker item);
        Task DeleteItemAsync(string name);
    }
}
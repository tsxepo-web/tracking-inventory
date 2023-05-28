using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using TrackingInventory.Data;
using TrackingInventory.Models;
using TrackingInventory.Models.entities;

namespace TrackingInventory.Services
{
    public class TrackingInventoryRepository : ITrackingInventoryRepository
    {
        private readonly IMongoCollection<InventoryTracker> _inventoryTrackerCollection;
        public TrackingInventoryRepository(IMongoCollection<InventoryTracker> inventoryTackerCollection)
        {
            _inventoryTrackerCollection = inventoryTackerCollection;
        }
        public async Task CreateItemAsync(InventoryTracker item)
        {
            await _inventoryTrackerCollection.InsertOneAsync(item);
        }

        public async Task DeleteItemAsync(string name)
        {
            await _inventoryTrackerCollection.DeleteOneAsync(x => x.Name == name);
        }

        public async Task<InventoryTracker> GetItemAsync(string name)
        {
            return await _inventoryTrackerCollection.Find(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<InventoryTracker>> GetItemsAsync()
        {
            return await _inventoryTrackerCollection.Find(_ => true).ToListAsync();
        }

        public async Task UpdateItemAsync(InventoryTracker item)
        {
            await _inventoryTrackerCollection.ReplaceOneAsync(x => x.Name == item.Name, item);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackingInventory.Data;
using TrackingInventory.Models.entities;

namespace TrackingInventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackingInventoryController : ControllerBase
    {
        private readonly ITrackingInventoryRepository _trackingInventoryRepository;
        public TrackingInventoryController(ITrackingInventoryRepository trackingInventoryRepository)
        {
            _trackingInventoryRepository = trackingInventoryRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<InventoryTracker>> GetItems()
        {
            return await _trackingInventoryRepository.GetItemsAsync();
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<InventoryTracker>> GetItem(string name)
        {
            return await _trackingInventoryRepository.GetItemAsync(name);
        }
        [HttpPut("{name}")]
        public async Task<IActionResult> PutItem(InventoryTracker item, string name)
        {
            if (name != item.Name)
            {
                return BadRequest();
            }
            await _trackingInventoryRepository.UpdateItemAsync(item);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostItem(InventoryTracker item)
        {
            await _trackingInventoryRepository.CreateItemAsync(item);
            return NoContent();
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteItem(string name)
        {
            var itemToDelete = await _trackingInventoryRepository.GetItemAsync(name);
            if (itemToDelete == null)
            {
                return NotFound();
            }
            await _trackingInventoryRepository.DeleteItemAsync(itemToDelete!.Name!);
            return NoContent();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TrackingInventory.Models.entities
{
    public class InventoryTracker
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public double Value { get; set; }
        public byte[]? Photo { get; set; }
    }
}
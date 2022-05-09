﻿using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Kumibot.Database.Models;

public abstract class BaseResource
{
    [Required] [BsonId] public int Id { get; set; }
    [Required] public DateTime CreatedAt { get; set; }
    [Required] public DateTime UpdatedAt { get; set; }
    [Required] [ConcurrencyCheck] public int Version { get; set; }
}
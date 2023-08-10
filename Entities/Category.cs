﻿using System.ComponentModel.DataAnnotations.Schema;
using EfCore.Entities.Abstractions;

namespace EfCore.Entities;
public class Category : BaseEntity
{
    public required string Name { get; set; }
    public int? UpperId { get; set; }
    [JsonIgnore]
    public Category? Upper { get; set; }
    public Guid? ImageId { get; set; }
    public List<Category>? ChildCategories { get; set; }
}
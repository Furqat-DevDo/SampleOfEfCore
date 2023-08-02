﻿using EfCore.Entities.Abstractions;

namespace EfCore.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string? ImageSrc { get; set; }
    public required int CategoryId { get; set; } 
    public required int CompanyId { get; set; }
    public DateTime ManufacturedDate { get; set; }
    public DateTime ExpireDate { get; set; }
}

﻿namespace EfCore.Models.Requests;

public class UpdateShopRequest
{
    public required string Name { get; set; }
    public required string Adrress { get; set; }
    public string Phone { get; set; } = null!;
    public int? UpperId { get; set; }
}

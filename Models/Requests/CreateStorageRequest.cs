﻿using EfCore.Attributes;

namespace EfCore.Models.Requests;

public class CreateStorageRequest
{
    [StringValidator(minLength: 1, maxLength: 30, ErrorMessage = "Storage name")]
    public required string Name { get; set; }

    [StringValidator(minLength: 1, maxLength: 100, ErrorMessage = "Storage address")]
    public required string Adrress { get; set; }
    public List<int>? ProductIds { get; set; }
}

﻿using EfCore.Entities;
using EfCore.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace EfCore.Models.Responses
{
    public class GetStaffResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public EStaffRole Role { get; set; }
        public JsonDocument? PersonalData { get; set; }
        public double Salary { get; set; }
        public  string? FullName { get; set; }
    }
}

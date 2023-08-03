﻿using EfCore.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities
{
    public class CategoryImage : BaseFile
    {
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}

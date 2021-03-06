﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeePoint.Domain.Entities
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid DiscountGuid { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        public float Percetage { get; set; }
    }
}
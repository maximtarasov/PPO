using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeePoint.Domain.Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid AccountGuid { get; set; }
        
        [ForeignKey(nameof(Type))]
        public AccountTypeOption TypeId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Balance { get; set; }
        
        public virtual AccountType Type { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        
    }
}
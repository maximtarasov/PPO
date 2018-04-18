using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeePoint.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ItemGuid { get; set; }
        
        [ForeignKey(nameof(Order))]
        public Guid OrderGuid { get; set; }
        [ForeignKey(nameof(Product))]
        public Guid ProductGuid { get; set; }
        public int Count { get; set; }
        
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
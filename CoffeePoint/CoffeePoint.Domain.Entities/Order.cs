using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeePoint.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OrderGuid { get; set; }
        
        [ForeignKey(nameof(CashierShift))]
        public Guid ShiftGuid { get; set; }
        
        [ForeignKey(nameof(Discount))]
        public Guid? DiscountGuid { get; set; }
        
        public DateTimeOffset OpenDate { get; set; }  
        public DateTimeOffset? ClosedDate { get; set; }
        
        public decimal Balance { get; set; }
        
        public virtual CashierShift CashierShift { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        
        
    }
}
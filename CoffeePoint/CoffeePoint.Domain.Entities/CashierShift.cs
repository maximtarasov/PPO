using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeePoint.Domain.Entities
{
    public class CashierShift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ShiftGuid { get; set; }
        
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        
        
        public CashierShift()
        {
            ShiftGuid = Guid.NewGuid();
            StartDate = DateTimeOffset.Now;
        }
    }
}
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
        
        
        [ForeignKey(nameof(OpenedByUser))]
        public Guid OpenedByUserGuid { get; set; }
        [ForeignKey(nameof(ClosedByUser))]
        public Guid? ClosedByUserGuid { get; set; }
        
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        
        public decimal Balance { get; set; }
        
        [InverseProperty(nameof(User.OpenedShifts))]
        public virtual User OpenedByUser { get; set; }
        [InverseProperty(nameof(User.ClosedShifts))]
        public virtual User ClosedByUser { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        
        
        public CashierShift()
        {  }

        public CashierShift(Guid openedByUserGuid)
        {
            ShiftGuid = Guid.NewGuid();
            OpenedByUserGuid = openedByUserGuid;
            StartDate = DateTimeOffset.Now;
        }
    }
}
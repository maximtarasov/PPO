using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeePoint.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UserGuid { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; }

        [InverseProperty(nameof(CashierShift.OpenedByUser))]
        public virtual ICollection<CashierShift> OpenedShifts { get; set; }
        [InverseProperty(nameof(CashierShift.ClosedByUser))]
        public virtual ICollection<CashierShift> ClosedShifts { get; set; }


        public User()
        {
            UserGuid = Guid.NewGuid();
        }

        public User(string userName, string surname, string name, string passwordHash)
        {
            UserGuid = Guid.NewGuid();
            UserName = userName;
            Surname = surname;
            Name = name;
            PasswordHash = passwordHash;
        }
        
    }
}
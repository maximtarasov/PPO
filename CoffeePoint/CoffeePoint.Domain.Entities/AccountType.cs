using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeePoint.Domain.Entities
{
    public class AccountType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public AccountTypeOption TypeId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        public virtual ICollection<Account> Accounts { get; set; }

        public AccountType()
        { }

        public AccountType(AccountTypeOption typeId, string name)
        {
            TypeId = typeId;
            Name = name;
        }
    }
}
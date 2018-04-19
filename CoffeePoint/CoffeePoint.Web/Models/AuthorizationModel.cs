using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeePoint.Web.Models
{
    public class AuthorizationModel
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class User
    {
        [EmailAddress, Required]
        public string Email { get; set; }
        [StringLength(30, MinimumLength = 8), Required]
        public string Password { get; set; }
    }
}

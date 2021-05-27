using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Task
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Attendant { get; set; }

        public Task()
        {

        }

        public Task(int Id, string Title, string Description, string Attendant)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Attendant = Attendant;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Services.Database
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int NumberOfTasks { get; set; }

        public bool IsShared { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.BLL.Entities {
    public class TodoList {
        public TodoList() {
            Todos = new List<Todo>();
        }
        public int Id { get; set; }
        public string ListTitle { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.BLL.Entities;

namespace ToDo.BLL {
    public class TodoContext : DbContext {
        public TodoContext() : base("TodoDBCon") {

        }

        public DbSet<Todo> Todo { get; set; }
        public DbSet<TodoList> TodoList { get; set; }
    }
}

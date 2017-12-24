using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.BLL.Entities {
    public class Todo {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsDone { get; set; }
    }
}
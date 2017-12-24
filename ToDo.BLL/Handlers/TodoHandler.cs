using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.BLL.Entities;
using ToDo.BLL.IRepository;

namespace ToDo.BLL.Handlers {
    public class TodoHandler : IHandler<Todo>{
        private TodoContext context = new TodoContext();

        public void Add(Todo m) {
            context.Todo.Add(m);
        }
        public void Update(Todo m, int id) {
            context.Entry(m).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(Todo m) {
            context.Todo.Remove(m);
        }
        public ICollection<Todo> GetAll() {
            return context.Todo.ToList();
        }
        public Todo GetById(int id) {
            return context.Todo.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Save() => context.SaveChanges();
    }
}
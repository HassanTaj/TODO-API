using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ToDo.BLL.Entities;
using ToDo.BLL.IRepository;

namespace ToDo.BLL.Handlers {
    public class TodoListHandler : IHandler<TodoList> {
        private TodoContext ctx = new TodoContext();

        public void Add(TodoList m) {
            ctx.TodoList.Add(m);
        }

        public void Delete(TodoList m) {
            ctx.TodoList.Remove(m);
        }

        public ICollection<TodoList> GetAll() {
            return ctx.TodoList.Include(x => x.Todos).ToList();
        }

        public TodoList GetById(int id) {
            return ctx.TodoList
                .Include(x => x.Todos)
                .Where(x => x.Id == id).FirstOrDefault();
        }


        public void Update(TodoList m, int id) {

            ctx.Entry(m).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save() {
            ctx.SaveChanges();
        }
    }
}
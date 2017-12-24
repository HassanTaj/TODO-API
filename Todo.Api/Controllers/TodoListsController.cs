using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ToDo.BLL.Entities;
using ToDo.BLL.Handlers;

namespace ToDo.Api.Controllers
{
    public class TodoListsController : ApiController
    {
        private TodoListHandler db = new TodoListHandler();

        // GET: api/todolists
        [ResponseType(typeof(TodoList))]
        public ICollection<TodoList> GetTodoList() {
          return  db.GetAll();
        }

        // Get: api/todolists/id
        [ResponseType(typeof(TodoList))]
        public IHttpActionResult GetTodoList(int id) {
            TodoList todolist = db.GetById(id);
            if (todolist ==null) {
                return NotFound();
            }
            return Ok(todolist);
        }

        // POST: api/todolists/
        [ResponseType(typeof(TodoList))]
        public IHttpActionResult PostTodoList(TodoList model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            db.Add(model);
            db.Save();
            return Ok(model);
        }

        //PUT: api/todolists/id
        [ResponseType(typeof(TodoList))]
        public IHttpActionResult PutTodoList(int id, TodoList m) {
            TodoList list = db.GetById(id);
            if (list == null) {
                return NotFound();
            }
            db.Update(list,list.Id);
            db.Save();
            return Ok(list);
        }

        //DELETE
        [ResponseType(typeof(TodoList))]
        public IHttpActionResult DeleteTodoList(int id) {
            TodoList list = db.GetById(id);
            if (list == null) {
                return NotFound();
            }
            foreach (var todo in list.Todos) {

            }
            db.Delete(list);
            db.Save();
            return Ok(list);
        }


        public bool TodoListExists(int id) {
            return db.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}
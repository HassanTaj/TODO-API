using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToDo.BLL.Handlers;
using ToDo.BLL.Entities;

namespace ToDo.Api.Controllers
{
    public class TodosController : ApiController
    {
        private TodoHandler db = new TodoHandler();

        // GET: api/Todoes
        public IQueryable<Todo> GetTodo()
        {
            return db.GetAll().AsQueryable();
        }

        // GET: api/Todoes/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult GetTodo(int id)
        {
            Todo Todo = db.GetById(id);
            if (Todo == null)
            {
                return NotFound();
            }
            return Ok(Todo);
        }

        //// PUT: api/Todoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodo(int id, Todo Todo) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != Todo.Id) {
                return BadRequest();
            }
            db.Update(Todo,Todo.Id);
            try {
                db.Save();
            }
            catch (DbUpdateConcurrencyException) {
                if (!TodoExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Todoes
        [ResponseType(typeof(Todo))]
        public IHttpActionResult PostTodo(Todo Todo) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            db.Add(Todo);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = Todo.Id }, Todo);
        }

        //// DELETE: api/Todoes/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult DeleteTodo(int id) {
            Todo Todo = db.GetById(id);
            if (Todo == null) {
                return NotFound();
            }
            db.Delete(Todo);
            db.Save();
            return Ok(Todo);
        }

        //protected override void Dispose(bool disposing) {
        //    if (disposing) {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool TodoExists(int id) {
            return db.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}
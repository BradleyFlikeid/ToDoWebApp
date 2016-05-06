using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Common.Models;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    [Route("api/todo")]
    public class ToDoController : Controller
    {
        [FromServices]
        public IToDoRepository ToDos { get; set; }

        [HttpGet]
        public IEnumerable<ToDo> GetAll()
        {
            return ToDos.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]

        public IActionResult GetById(string id)
        {
            var item = ToDos.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ToDo item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }

            ToDos.Add(item);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] ToDo item)
        {
            if (item == null || item.Key != id)
            {
                return HttpBadRequest();
            }

            var todo = ToDos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }

            ToDos.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ToDos.Remove(id);
        }
    }
}

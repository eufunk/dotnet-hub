using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService _toDoService;

        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        // GET: api/ToDo
        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> Get()
        {
            return Ok(_toDoService.GetAll());
        }

        // GET: api/ToDo/5
        [HttpGet("{id}")]
        public ActionResult<ToDoItem> Get(int id)
        {
            var item = _toDoService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/ToDo
        [HttpPost]
        public ActionResult<ToDoItem> Post([FromBody] ToDoItem item)
        {
            _toDoService.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ToDoItem updatedItem)
        {
            var item = _toDoService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            _toDoService.Update(id, updatedItem);
            return NoContent();
        }

        // DELETE: api/ToDo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _toDoService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            _toDoService.Delete(id);
            return NoContent();
        }
    }
}

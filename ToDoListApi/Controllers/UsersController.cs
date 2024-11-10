using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;


namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        // In-memory list to simulate a database
        private static List<ToDoItem> _toDoItems = new List<ToDoItem>
        {
            new ToDoItem { Id = 1, Title = "Sample Task 1", IsCompleted = false },
            new ToDoItem { Id = 2, Title = "Sample Task 2", IsCompleted = true }
        };

        // Get all to-do items
        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> GetToDoItems()
        {
            return Ok(_toDoItems);  // Return the list of ToDoItems
        }

        // Get a to-do item by ID
        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetToDoItem(int id)
        {
            var item = _toDoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
                return NotFound();  // Return 404 if not found
            return Ok(item);  // Return the found item
        }

        // Create a new to-do item
        [HttpPost]
        public ActionResult<ToDoItem> CreateToDoItem(ToDoItem item)
        {
            // Generate a new ID based on the current max ID in the list
            item.Id = _toDoItems.Max(t => t.Id) + 1;
            _toDoItems.Add(item);  // Add new item to the in-memory list
            return CreatedAtAction(nameof(GetToDoItem), new { id = item.Id }, item);  // Return created response with new item
        }

        // Update an existing to-do item
        [HttpPut("{id}")]
        public IActionResult UpdateToDoItem(int id, ToDoItem updatedItem)
        {
            var item = _toDoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
                return NotFound();  // Return 404 if item not found

            // Update item details
            item.Title = updatedItem.Title;
            item.IsCompleted = updatedItem.IsCompleted;

            return NoContent();  // Return 204 No Content response after update
        }

        // Delete a to-do item
        [HttpDelete("{id}")]
        public IActionResult DeleteToDoItem(int id)
        {
            var item = _toDoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
                return NotFound();  // Return 404 if item not found

            _toDoItems.Remove(item);  // Remove the item from the list
            return NoContent();  // Return 204 No Content response after deletion
        }
    }

    // Simple ToDoItem model class
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ToDoItemsController : ControllerBase
{
    // In-memory list to simulate the database
    private static List<ToDoItem> _toDoItems = new List<ToDoItem>
    {
        new ToDoItem { Id = 1, Title = "Sample Task 1", IsCompleted = false },
        new ToDoItem { Id = 2, Title = "Sample Task 2", IsCompleted = true }
    };

    // Get all to-do items
    [HttpGet]
    public ActionResult<IEnumerable<ToDoItem>> GetToDoItems()
    {
        return _toDoItems;
    }

    // Get a to-do item by ID
    [HttpGet("{id}")]
    public ActionResult<ToDoItem> GetToDoItem(int id)
    {
        var item = _toDoItems.FirstOrDefault(t => t.Id == id);
        if (item == null) return NotFound();
        return item;
    }

    // Create a new to-do item
    [HttpPost]
    public ActionResult<ToDoItem> CreateToDoItem(ToDoItem item)
    {
        item.Id = _toDoItems.Max(t => t.Id) + 1; // Generate a new ID
        _toDoItems.Add(item);
        return CreatedAtAction(nameof(GetToDoItem), new { id = item.Id }, item);
    }

    // Update a to-do item
    [HttpPut("{id}")]
    public IActionResult UpdateToDoItem(int id, ToDoItem updatedItem)
    {
        var item = _toDoItems.FirstOrDefault(t => t.Id == id);
        if (item == null) return NotFound();

        item.Title = updatedItem.Title;
        item.IsCompleted = updatedItem.IsCompleted;

        return NoContent();
    }

    // Delete a to-do item
    [HttpDelete("{id}")]
    public IActionResult DeleteToDoItem(int id)
    {
        var item = _toDoItems.FirstOrDefault(t => t.Id == id);
        if (item == null) return NotFound();

        _toDoItems.Remove(item);
        return NoContent();
    }
}

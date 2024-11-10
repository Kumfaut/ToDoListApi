using ToDoListApi.Models;

public class ToDoItem
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; } = false;

    public int UserId { get; set; }

    public User User { get; set; }
}

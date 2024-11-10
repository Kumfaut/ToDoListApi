using Microsoft.AspNetCore.Mvc;

namespace ToDoListApi.Controllers
{
    public class ToDoItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

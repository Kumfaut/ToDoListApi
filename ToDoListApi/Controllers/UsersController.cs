using Microsoft.AspNetCore.Mvc;

namespace ToDoListApi.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

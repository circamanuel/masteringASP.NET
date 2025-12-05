using Microsoft.AspNetCore.Mvc;

namespace DiararyApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

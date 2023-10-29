using Microsoft.AspNetCore.Mvc;

namespace DotNetCore2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentBioData()
        {
            return View();
        }
    }
}

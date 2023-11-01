using Microsoft.AspNetCore.Mvc;

namespace GLDiagonistic.Web.Controllers
{
    public class AllPatientAppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using System.Web.Mvc;
using StudentsCore;
using WebDbApp.Models;

namespace WebDbApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly StudentsRepo Repo = new StudentsRepo();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Students = Repo.Load();

            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentsModel studentsmodel)
        {
            Repo.Save(new StudentsDto(studentsmodel.FirstName, studentsmodel.SecondName, studentsmodel.FacultyId, studentsmodel.OveralMark));

            ViewBag.Students = Repo.Load();

            return View();
        }

    }
}

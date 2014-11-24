using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebDbApp.Abstractions;
using WebDbApp.Models;

namespace WebDbApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentsModelValidator _studentsModelValidator;
        private readonly IStudentsViewReader _viewReader;
        private readonly IStudentsViewWriter _viewWriter;
        private readonly string _appVersion;

        public HomeController(IStudentsModelValidator studentsModelValidator, 
                                IStudentsViewReader viewReader, 
                                IStudentsViewWriter viewWriter,
                                string appVersion)
        {
            _studentsModelValidator = studentsModelValidator;
            _viewReader = viewReader;
            _viewWriter = viewWriter;
            _appVersion = appVersion;
        }


        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Students = _viewReader.ReadAll();

            ViewBag.Version = _appVersion;

            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentViewModel model)
        {
            List<string> invalidProperties;
            var isValid = _studentsModelValidator.ContainValidData(model, out invalidProperties);

            if (isValid)
            {
                var newModel = new StudentViewModel
                {
                    FirstName = model.FirstName + _appVersion,
                    SecondName = model.SecondName,
                    FacultyId = model.FacultyId,
                    OveralMark = model.OveralMark
                };
                _viewWriter.Create(newModel);
            }
            else
            {
                int i = 1;
                var msg = "Students model contains invalid data in following properties: ";
                foreach (var item in invalidProperties)
                {
                    string symbol;

                    if (i == invalidProperties.Count())
                    {
                        symbol = ".";
                    }
                    else
                    {
                        symbol = ", ";
                        i++;
                    }
                    msg = string.Format("{0} {1}{2}", msg, item, symbol);
                }

                throw new ArgumentException(msg);
            }

            ViewBag.Students = _viewReader.ReadAll().ToArray();
            ViewBag.Version = _appVersion;

            return View();
        }

    }
}

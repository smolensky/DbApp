using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebDbApp.EntityReaders;
using WebDbApp.Models;
using WebDbApp.ViewReaders;
using WebDbApp.ViewWriters;

namespace WebDbApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentsModelValidator _studentsModelValidator;
        private readonly StudentsViewReader _viewReader;
        private readonly StudentsViewWriter _viewWriter;

        public HomeController(StudentsModelValidator studentsModelValidator, 
                                StudentsViewReader viewReader, 
                                StudentsViewWriter viewWriter)
        {
            _studentsModelValidator = studentsModelValidator;
            _viewReader = viewReader;
            _viewWriter = viewWriter;
        }


        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Students = _viewReader.ReadAll();

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
                    FirstName = model.FirstName,
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

            return View();
        }

    }
}

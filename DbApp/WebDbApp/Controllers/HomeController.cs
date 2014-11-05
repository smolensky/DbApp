using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StudentsCore;
using WebDbApp.Models;

namespace WebDbApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentsModelValidator _studentsModelValidator;
        private readonly StudentsDataReader _dataReader;

        public HomeController(StudentsModelValidator studentsModelValidator, StudentsDataReader dataReader)
        {
            _studentsModelValidator = studentsModelValidator;
            _dataReader = dataReader;
        }


        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Students = _dataReader.ReadAll().ToArray();

            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentEntity studentEntity)
        {
            List<string> invalidProperties;
            var isValid = _studentsModelValidator.ContainValidData(studentEntity, out invalidProperties);

            if (isValid)
            {
                var newEntity = new StudentEntity
                {
                    FirstName = studentEntity.FirstName,
                    SecondName = studentEntity.SecondName,
                    FacultyId = studentEntity.FacultyId,
                    OveralMark = studentEntity.OveralMark
                };
                _dataReader.Create(newEntity);
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

            ViewBag.Students = _dataReader.ReadAll().ToArray();

            return View();
        }

    }
}

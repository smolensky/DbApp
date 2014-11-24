using System.Collections.Generic;
using System.IO;
using AutoMapper;
using WebAppData.Entities;
using WebAppData.EntityReaders;
using WebDbApp.Abstractions;
using WebDbApp.Models;

namespace WebDbApp.ViewReaders
{
    public class StudentsViewReader : IStudentsViewReader
    {
        private readonly StudentsEntityReader _studentsEntityReader;

        public StudentsViewReader(StudentsEntityReader studentsEntityReader)
        {
            _studentsEntityReader = studentsEntityReader;
        }

        public IEnumerable<StudentViewModel> ReadAll()
        {
            var entities = _studentsEntityReader.ReadAll();

            if (entities == null)
            {
                throw new InvalidDataException("You recieved no data from database.");
            }

            var result = Mapper.Map<IEnumerable<StudentEntity>, IEnumerable<StudentViewModel>>(entities);

            return result;
        }
    }
}
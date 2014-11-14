using System.Collections.Generic;
using System.Linq;
using WebDbApp.EntityReaders;
using WebDbApp.Models;

namespace WebDbApp.ViewReaders
{
    public class StudentsViewReader
    {
        private readonly StudentsEntityReader _studentsEntityReader;

        public StudentsViewReader(StudentsEntityReader studentsEntityReader)
        {
            _studentsEntityReader = studentsEntityReader;
        }

        public IEnumerable<StudentViewModel> ReadAll()
        {
            var entities = _studentsEntityReader.ReadAll().ToList(); //TODO: remove this because of possibility of null reference exception

            var result = entities.Select(Mapper.Map);

            return result;
        }
    }
}
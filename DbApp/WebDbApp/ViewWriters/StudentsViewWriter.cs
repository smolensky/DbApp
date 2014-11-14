using WebDbApp.EntityWriters;
using WebDbApp.Models;

namespace WebDbApp.ViewWriters
{
    public class StudentsViewWriter
    {
        private readonly StudentsEntityWriter _studentsEntityWriter;

        public StudentsViewWriter(StudentsEntityWriter studentsEntityWriter)
        {
            _studentsEntityWriter = studentsEntityWriter;
        }

        public StudentViewModel Create(StudentViewModel model)
        {
            var entity = Mapper.Map(model);

            var newEntity = _studentsEntityWriter.Create(entity);
            var result = Mapper.Map(newEntity);
            return result;
        }
    }
}
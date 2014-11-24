using System;
using AutoMapper;
using WebAppData.Abstractions;
using WebAppData.Entities;
using WebDbApp.Abstractions;
using WebDbApp.Models;

namespace WebDbApp.ViewWriters
{
    public class StudentsViewWriter : IStudentsViewWriter
    {
        private readonly string _appVersion;
        private readonly IStudentsEntityWriter _studentsEntityWriter;

        public StudentsViewWriter(IStudentsEntityWriter studentsEntityWriter, string appVersion)
        {
            _studentsEntityWriter = studentsEntityWriter;
            _appVersion = appVersion;
        }

        public StudentViewModel Create(StudentViewModel model)
        {
            var entity = Mapper.Map<StudentViewModel, StudentEntity>(model);
            var createdEntity = _studentsEntityWriter.Create(entity);
            if (createdEntity == null)
            {
                throw new InvalidOperationException("Entity writer returned null. This is unexpected.");
            }
            var result = Mapper.Map<StudentEntity, StudentViewModel>(createdEntity);
            return result;
        }
    }
}
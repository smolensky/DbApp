using AutoMapper;
using WebAppData.Entities;
using WebDbApp.Models;

namespace WebDbApp
{
    public class DatabaseMapper
    {
        public DatabaseMapper()
        {
            Mapper.CreateMap<StudentEntity, StudentViewModel>();
            Mapper.CreateMap<StudentViewModel, StudentEntity>();
        }

        public static StudentEntity MapView(StudentViewModel model)
        {
            return Mapper.Map<StudentViewModel, StudentEntity>(model);
        }

        public static StudentViewModel MapEntity(StudentEntity entity)
        {
            return Mapper.Map<StudentEntity, StudentViewModel>(entity);
        }
    }
}
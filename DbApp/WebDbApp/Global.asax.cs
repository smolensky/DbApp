using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Microsoft.Practices.Unity;
using WebAppData.Entities;
using WebDbApp.Models;

namespace WebDbApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Mapper.Initialize(x => x.AddProfile<StudentProfile>());

            Bootstrapper.Initialise();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }

    public class StudentProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<StudentViewModel, StudentEntity>();
            CreateMap<StudentEntity, StudentViewModel>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}
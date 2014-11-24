using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using WebAppData.Abstractions;
using WebAppData.EntityReaders;
using WebAppData.EntityWriters;
using WebDbApp.Abstractions;
using WebDbApp.Controllers;
using WebDbApp.Models;
using WebDbApp.ViewReaders;
using WebDbApp.ViewWriters;

namespace WebDbApp
{
  public static class Bootstrapper
  {
      public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
        var appVersion = GetAppVersion();
      RegisterTypes(container, appVersion);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container, string appVersion)
    {
        container.RegisterType<IStudentsModelValidator, StudentsModelValidator>();
        container.RegisterType<IFacultyEntityReader, FacultyEntityReader>();
        container.RegisterType<IStudentsEntityReader, StudentsEntityReader>();
        container.RegisterType<IStudentsEntityWriter, StudentsEntityWriter>();
        container.RegisterType<IStudentsViewReader, StudentsViewReader>();
        container.RegisterType<IStudentsViewWriter, StudentsViewWriter>().RegisterType<StudentsViewWriter>(
                                                                            new InjectionConstructor(
                                                                                new ResolvedParameter(typeof(IStudentsEntityWriter)),
                                                                                appVersion));
        container.RegisterType<HomeController>(new InjectionConstructor(
                                                new ResolvedParameter(typeof(StudentsModelValidator)),
                                                new ResolvedParameter(typeof(IStudentsViewReader)),
                                                new ResolvedParameter(typeof(IStudentsViewWriter)),
                                                    appVersion));
    }

      private static string GetAppVersion()
      {
          int version;

          if (Int32.TryParse(ConfigurationManager.AppSettings["Version"], out version))
          {
              return version.ToString();
          }
          else
          {
              throw new InvalidDataException("Version is not valid. Visit web.config file to fix this problem.");
          }
      }
  }
}
using System;
using System.Collections.Generic;
using Nancy;
using Registrar.Objects;

namespace Registrar
{
  public class HomeModule: NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Course> allCourses = Course.GetAll();
        return View["index.cshtml", allCourses];
      };

      Get["/add-course"] = _ => {
        return View["course_add.cshtml"];
      };

      Post["/"] = _ => {
        Course newCourse = new Course( Request.Form["course-name"], Request.Form["course-number"]);
        newCourse.Save();
        List<Course> allCourses = Course.GetAll();

        return View["index.cshtml", allCourses];
      };

    }
  }
}

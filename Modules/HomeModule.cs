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
        return View["index.cshtml"];
      };
      Get["/courses"] = _ => {
        List<Course> allCourses = Course.GetAll();
        return View["all_courses.cshtml", allCourses];
      };

      Get["/courses/new"] = _ => {
        return View["course_add.cshtml"];
      };

      Post["/courses"] = _ => {
        Course newCourse = new Course( Request.Form["course-name"], Request.Form["course-number"]);
        newCourse.Save();
        List<Course> allCourses = Course.GetAll();

        return View["all_courses.cshtml", allCourses];
      };

      Get["/students"] = _ => {
        List<Student> allStudents = Student.GetAll();
        return View["all_students.cshtml", allStudents];
      };

      Get["/students/new"] = _ => {
        return View["student_add.cshtml"];
      };

      Post["/students"] = _ => {
        Student newStudent = new Student(Request.Form["student-name"], Request.Form["enrollment-date"]);
        newStudent.Save();
        List<Student> allStudents = Student.GetAll();
        return View["all_students.cshtml", allStudents];
      };

    }
  }
}

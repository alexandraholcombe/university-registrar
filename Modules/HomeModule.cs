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

      Get["/courses/{id}/{number}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Course SelectedCourse = Course.Find(parameters.id);
        var studentsInCourse = SelectedCourse.GetStudents();
        var allStudents = Student.GetAll();
        model.Add("course", SelectedCourse);
        model.Add("students", studentsInCourse);
        model.Add("allStudents", allStudents);
        return View["course.cshtml", model];
      };

      Post["/courses/{id}/{number}"] = parameters => {
        Student newStudent = Student.Find(Request.Form["all-students"]);
        Course selectedCourse = Course.Find(parameters.id);
        selectedCourse.AddStudent(newStudent);
        Dictionary<string, object> model = new Dictionary<string, object>{};
        var studentsInCourse = selectedCourse.GetStudents();
        var allStudents = Student.GetAll();
        model.Add("course", selectedCourse);
        model.Add("students", studentsInCourse);
        model.Add("allStudents", allStudents);
        return View["course.cshtml", model];
      };

      Get["/students/{id}/{name}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Student SelectedStudent = Student.Find(parameters.id);
        List<Course> studentCourses = SelectedStudent.GetCourses();
        var allCourses = Course.GetAll();
        model.Add("student", SelectedStudent);
        model.Add("courses", studentCourses);
        model.Add("allCourses", allCourses);
        return View["student.cshtml", model];
      };

      Post["/students/{id}/{name}"] = parameters => {
        Course selectedCourse = Course.Find(Request.Form["all-courses"]);
        Student SelectedStudent = Student.Find(parameters.id);
        selectedCourse.AddStudent(SelectedStudent);
        Dictionary<string, object> model = new Dictionary<string, object>{};
        var studentCourses = SelectedStudent.GetCourses();
        var allCourses = Course.GetAll();
        model.Add("student", SelectedStudent);
        model.Add("courses", studentCourses);
        model.Add("allCourses", allCourses);
        return View["student.cshtml", model];
      };

    }
  }
}

using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Registrar.Objects
{
  public class CourseTest: IDisposable
  {
    //Set Course Objects for use in tests
    public static Course firstCourse = new Course("Intro to History", "HIST101");
    public static Course secondCourse = new Course("Differential Equations", "MATH504");

    public CourseTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=registrar_test;Integrated Security=SSPI;";
    }

    //Make sure the table is clear at the start of each test
    [Fact]
    public void Test_CheckDatabase_ReturnTrueIfEMpty()
    {
      //Arrange, Act
      int actualResult = Course.GetAll().Count;
      int expectedResult = 0;

      //Assert
      Assert.Equal(expectedResult, actualResult);
    }

    //Check if two objects are equal
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange,Act
      Course thirdCourse = firstCourse;

      //Assert
      Assert.Equal(thirdCourse, firstCourse);
    }

    //Check that Save method saves to DB
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange, Act
      firstCourse.Save();

      //Assert
      List<Course> actualResult = Course.GetAll();
      List<Course> expectedResult = new List<Course>{firstCourse};


      Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Test_GetAll_ReturnsListofCourses()
    {
      //Arrange

      //Act
      firstCourse.Save();
      secondCourse.Save();

      //Assert
      List<Course> actualResult = Course.GetAll();
      List<Course> expectedResult = new List<Course>{firstCourse, secondCourse};

      Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Test_Find_ReturnCourseFromDatabase()
    {
      //Arrange
      Course testCourse = firstCourse;
      testCourse.Save();

      //Act
      Course foundCourse = Course.Find(testCourse.GetId());

      //Assert
      Assert.Equal(testCourse,foundCourse);
    }

    //Add student to Course
    [Fact]
    public void Test_AddStudent_AddsStudentToCourse()
    {
      //Arrange
      firstCourse.Save();

      DateTime enrollmentDate = new DateTime(1795, 04,13);

      Student firstStudent = new Student("Rebecca", enrollmentDate);
      Student secondStudent = new Student("Julia", enrollmentDate);

      firstStudent.Save();
      secondStudent.Save();

      //Act
      firstCourse.AddStudent(firstStudent);
      firstCourse.AddStudent(secondStudent);

      List<Student> actualResult = firstCourse.GetStudents();
      List<Student> expectedResult = new List<Student>{firstStudent, secondStudent};
    }

    //return students in course
    [Fact]
    public void Test_GetStudents_ReturnStudentsInCourse()
    {
      //Arrange
      Course testCourse = new Course("Running", "PE901");
      testCourse.Save();

      DateTime enrollmentDate = new DateTime(1795, 04,13);

      Student firstStudent = new Student("Rebecca",enrollmentDate);
      Student secondStudent = new Student("Julia",enrollmentDate);
      Student thirdStudent = new Student("Claire",enrollmentDate);


      //Act
      firstStudent.Save();
      secondStudent.Save();
      thirdStudent.Save();

      testCourse.AddStudent(firstStudent);
      testCourse.AddStudent(secondStudent);
      testCourse.AddStudent(thirdStudent);

      //Assert
      List<Student> expectedResult = new List<Student>{firstStudent, secondStudent, thirdStudent};
      List<Student> actualResult = testCourse.GetStudents();

      Assert.Equal(expectedResult, actualResult);
    }

    //Delete everything between tests
    public void Dispose()
    {
      Course.DeleteAll();
      Student.DeleteAll();
    }


  }
}

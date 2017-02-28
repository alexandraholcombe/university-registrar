using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Registrar.Objects
{
  public class StudentTest: IDisposable
  {
    //Set DateTime Objects for use in tests
    public static DateTime newDate = new DateTime(2011,11,11);
    public static DateTime twoDate = new DateTime(1995,12,25);

    //Set Student Objects for use in tests
    public static Student firstStudent = new Student("Christ", twoDate);
    public static Student secondStudent = new Student("Joseph", newDate);

    public StudentTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=registrar_test;Integrated Security=SSPI;";
    }

    //Make sure the table is clear at the start of each test
    [Fact]
    public void Test_CheckDatabase_ReturnTrueIfEMpty()
    {
      //Arrange, Act
      int actualResult = Student.GetAll().Count;
      int expectedResult = 0;

      //Assert
      Assert.Equal(expectedResult, actualResult);
    }

    //Check if two objects are equal
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange,Act
      Student thirdStudent = firstStudent;

      //Assert
      Assert.Equal(thirdStudent, firstStudent);
    }

    //Check that Save method saves to DB
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange, Act
      firstStudent.Save();

      //Assert
      List<Student> actualResult = Student.GetAll();
      List<Student> expectedResult = new List<Student>{firstStudent};
      foreach (Student student in actualResult)
      {
        Console.WriteLine(student.GetName());
      }

      Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Test_GetAll_ReturnsListofStudents()
    {
      //Arrange

      //Act
      firstStudent.Save();
      secondStudent.Save();

      //Assert
      List<Student> actualResult = Student.GetAll();
      List<Student> expectedResult = new List<Student>{firstStudent, secondStudent};

      Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Test_Find_ReturnStudentFromDatabase()
    {
      //Arrange
      Student testStudent = firstStudent;
      testStudent.Save();

      //Act
      Student foundStudent = Student.Find(testStudent.GetId());

      //Assert
      Assert.Equal(testStudent,foundStudent);
    }

    public void Test_GetStudents_ReturnStudentsInCourse()
    {
      //Arrange
      Course testCourse1 = new Course("Running", "PE901");
      Course testCourse2 = new Course("Jogging", "PE801");
      Course testCourse3 = new Course("Power-Walking", "PE701");
      testCourse1.Save();
      testCourse2.Save();
      testCourse3.Save();

      DateTime enrollmentDate = new DateTime(1795, 04,13);

      Student firstStudent = new Student("Rebecca",enrollmentDate);
      //Act
      firstStudent.Save();

      testCourse1.AddStudent(firstStudent);
      testCourse2.AddStudent(firstStudent);
      testCourse3.AddStudent(firstStudent);

      //Assert
      List<Course> expectedResult = new List<Course>{testCourse1, testCourse2, testCourse3};
      List<Course> actualResult = firstStudent.GetCourses();

      Assert.Equal(expectedResult, actualResult);
    }


    //Delete everything between tests
    public void Dispose()
    {
      Student.DeleteAll();
      Course.DeleteAll();
    }

  }
}

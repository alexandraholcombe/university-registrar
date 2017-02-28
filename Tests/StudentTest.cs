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

      foreach (Student student in expectedResult)
      {
        Console.WriteLine("EXPECTED: " + student.GetName() + ", " + student.GetId());
      }

      foreach (Student student in actualResult)
      {
        Console.WriteLine("ACTUAL: " + student.GetName() + ", " + student.GetId());
      }

      Assert.Equal(expectedResult, actualResult);
    }
    //Delete everything between tests
    public void Dispose()
    {
      Student.DeleteAll();
    }

  }
}

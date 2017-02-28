using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Registrar.Objects
{
  public class StudentTest: IDisposable
  {
    public StudentTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=registrar_test;Integrated Security=SSPI;";
    }
    // //Set DateTime Objects for use in tests
    // DateTime newDate = new DateTime(2011,11,11);
    // DateTime twoDate = new DateTime(1995,12,25);
    //
    // //Set Student Objects for use in tests
    // Student firstStudent = new Student("Christ", twoDate);
    // Student secondStudent = new Student("Joseph", newDate);

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

    //Delete everything between test
    public void Dispose()
    {
      Student.DeleteAll();
    }

  }
}

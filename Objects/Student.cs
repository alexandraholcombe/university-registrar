using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Registrar.Objects
{
  public class Student
  {
    private int _id;
    private string _name;
    private DateTime _dateOfEnrollment;

    public Student(string name, DateTime dateOfEnrollment, int id=0)
    {
      _id = id;
      _name = name;
      _dateOfEnrollment = dateOfEnrollment;
    }

    public int GetId()
    {
      return _id;
    }

    // public int SetId(int newId)
    // {
    //   _id = newId;
    // }

    public string GetName()
    {
      return _name;
    }

    public DateTime GetDateOfEnrollment()
    {
      return _dateOfEnrollment;
    }

    //Check if two objects are equal
    public override bool Equals(System.Object otherStudent)
    {
      if (!(otherStudent is Student))
      {
        return false;
      }
      else
      {
        Student newStudent = (Student) otherStudent;
        bool idEquality = (this.GetId() == newStudent.GetId());
        bool nameEquality = (this.GetName() == newStudent.GetName());
        bool dateEquality = (this.GetDateOfEnrollment() == newStudent.GetDateOfEnrollment());

        return (idEquality && nameEquality && dateEquality);
      }
    }
    //Delete all rows from Students table
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM students;", conn);
      cmd.ExecuteNonQuery();

      conn.Close();
    }



    //Get All students from the Student table
    public static List<Student> GetAll()
    {
      List<Student> allStudents = new List<Student>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students ORDER BY id;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        DateTime dateOfEnrollment = rdr.GetDateTime(2);

        Student newStudent = new Student(name, dateOfEnrollment, id);
        allStudents.Add(newStudent);
      }

      if (rdr != null)
      {
        rdr.Close();
      }

      if(conn != null)
      {
        conn.Close();
      }

      return allStudents;
    }

    //Save student to database
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand ("INSERT INTO students (name, date_of_enrollment) OUTPUT INSERTED.id VALUES(@StudentName, @DateOfEnrollment);", conn);
      cmd.Parameters.Add(new SqlParameter("@StudentName", this.GetName()));
      cmd.Parameters.Add(new SqlParameter("@DateOfEnrollment", this.GetDateOfEnrollment()));

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    //Finds student in database and returns as object
    public static Student Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE id = @StudentId;", conn);
      cmd.Parameters.Add(new SqlParameter("@StudentId", id.ToString()));
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string foundName = null;
      DateTime foundDateTime = new DateTime();

      while (rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        foundName = rdr.GetString(1);
        foundDateTime = rdr.GetDateTime(2);
      }

      Student foundStudent = new Student(foundName, foundDateTime, foundId);

      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }

      return foundStudent;

    }
  }
}

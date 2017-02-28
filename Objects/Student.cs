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

      SqlCommand cmd = new SqlCommand("SELECT * FROM students;", conn);
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
  }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Registrar.Objects
{
  public class Course
  {
    private int _id;
    private string _name;
    private string _number;

    public Course(string name, string number, int id=0)
    {
      _id = id;
      _name = name;
      _number = number;
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

    public string GetNumber()
    {
      return _number;
    }

    //Check if two objects are equal
    public override bool Equals(System.Object otherCourse)
    {
      if (!(otherCourse is Course))
      {
        return false;
      }
      else
      {
        Course newCourse = (Course) otherCourse;
        bool idEquality = (this.GetId() == newCourse.GetId());
        bool nameEquality = (this.GetName() == newCourse.GetName());
        bool numberEquality = (this.GetNumber() == newCourse.GetNumber());

        return (idEquality && nameEquality && numberEquality);
      }
    }
    //Delete all rows from Courses table
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM courses;", conn);
      cmd.ExecuteNonQuery();

      conn.Close();
    }



    //Get All courses from the Course table
    public static List<Course> GetAll()
    {
      List<Course> allCourses = new List<Course>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses ORDER BY id;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string number = rdr.GetString(2);

        Course newCourse = new Course(name, number, id);
        allCourses.Add(newCourse);
      }

      if (rdr != null)
      {
        rdr.Close();
      }

      if(conn != null)
      {
        conn.Close();
      }

      return allCourses;
    }

    //Save student to database
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand ("INSERT INTO courses (name, course_number) OUTPUT INSERTED.id VALUES(@CourseName, @CourseNumber);", conn);
      cmd.Parameters.Add(new SqlParameter("@CourseName", this.GetName()));
      cmd.Parameters.Add(new SqlParameter("@CourseNumber", this.GetNumber()));

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
    public static Course Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses WHERE id = @CourseId;", conn);
      cmd.Parameters.Add(new SqlParameter("@CourseId", id.ToString()));
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string foundName = null;
      string foundNumber = null;

      while (rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        foundName = rdr.GetString(1);
        foundNumber = rdr.GetString(2);
      }

      Course foundCourse = new Course(foundName, foundNumber, foundId);

      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }

      return foundCourse;

    }
  }
}

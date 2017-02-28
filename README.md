# University Registrar Management

#### By _**Alexandra Holcombe & Marc Larkin**_

## Description

*  As a registrar, I want to enter a student, so I can keep track of all students enrolled at this University. I should be able to provide a name and date of enrollment.
*  As a registrar, I want to enter a course, so I can keep track of all of the courses the University offers. I should be able to provide a course name and a course number (ex. HIST100).
*  As a registrar, I want to be able to assign students to a course, so that teachers know which students are in their course. A course can have many students and a student can take many courses at the same time.

***

## Setup/Installation Requirements

#### Create Databases
* In `SQLCMD`:  
        `> CREATE DATABASE hair_salon`  
        `> GO`  
        `> USE hair_salon`  
        `> GO`  
        `> CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));`  
        `> GO`  
        `> CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);`  
        `> GO`  

* Requires DNU, DNX, MSSQL, and Mono
* Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

***

## Specifications

### Student Class
================  

**The DeleteAll method for the Student class will delete all rows from the students table.**
* Example Input: none
* Example Output: nothing

**The GetAll method for the Student class will return an empty list if there are no entries in the Student table.**
* Example Input: N/A, automatically loads on home page
* Example Output: empty list

**The Equals method for the Student class will return true if the Student in local memory matches the Student pulled from the database.**
* Example Input:  
        > Local: "Elizabeth", id is 10  
        > Database: "Elizabeth", id is 10  
* Example Output: `true`

**The Save method for the Student class will save new Students to the database.**
* Example Input:  
\> New stylist: "Jennifer"
* Example Output: no return value

**The Save method for the Student class will assign an id to each new instance of the Student class.**
* Example Input:  
\> New stylist: "Jennifer", `local id: 0`  
* Example Output:  
\> "Jennifer", `database-assigned id`  

**The GetAll method for the Student class will return all student entries in the database in the form of a list.**
* Example Input:  
        > "Elizabeth", id is 10  
        > "Katie", id is 11  
* Example Output: `{Elizabeth object}, {Katie object}`

**The Find method for the Student class will return the Student as defined in the database.**
* Example Input: "Jennifer"
* Example Output: "Jennifer", `database-assigned id`

### Course class
================

**The DeleteAll method for the Course class will will delete all rows from the courses table.**
* Example Input: none
* Example Output: nothing

**The GetAll method for the Course class will return an empty list if there are no entries in the Course table.**
* Example Input: N/A, automatically loads on home page
* Example Output: empty list

**The Equals method for the Course class will return true if the Course in local memory matches the Course pulled from the database.**
* Example Input:  
        > Local: "Intro to American History", id is 10  
        > Database: "Intro to American History", id is 10  
* Example Output: `true`

**The Save method for the Course class will save new Courses to the database.**
* Example Input:  
\> New course: "Intro to American History", `HIST101`
* Example Output: no return value

**The Save method for the Course class will assign an id to each new instance of the Course class.**
* Example Input:  
\> New stylist: "Intro to American History", `HIST101`, `local id: 0`  
* Example Output:  
\> "Intro to American History", `HIST101`, `database-assigned id`  

**The GetAll method for the Course class will return all course entries in the database in the form of a list.**
* Example Input:  
        > "Running", number is "PE901"
        > "Jogging", number is "PE801"
* Example Output: `{Running object}, {Jogging object}`

**The Find method for the Course class will return the Course as defined in the database.**
* Example Input: "Running", "PE901"
* Example Output: "Running", "PE901", `database-assigned id`


### Student && Course Classes
=========================  

**The AddStudent method for the Course class will add a row to students_courses.**
* Example Input: Course: "Running" Student: "Jennifer"
* Example Output: n/a

**The GetStudents method will return a list of students taking the specified course.**
* Example Input: "Running"
* Example Output: "Jennifer", "Marc"

**The GetCourses method will return a list of courses that a student is taking.**
* Example Input: "Marc"
* Example Output: "Power-Walking", "Sprinting", "Jazz Hands"

### User Interface
===================  

**The registrar can add a new Course using the "Add Course" form.**
* Example Input: New Course: "Jazz Hands"
* Example Output: All courses: "Jazz Hands", "Slow-Dancing", "Coloring"

**The registrar can add a new Student using the "Add New Student" form.**
* Example Input: New Student: "Jennifer", 02/28/2017
* Example Output: All students: "Allison, Kacey, Jennifer"

**The registrar can add a student to a course using the "Add to Class" form.**
* Example Input: "Marc", add to "Chorus"
* Example Output: All students in Chorus: "Marc", "Christ"

**The registrar can see a list of all students in a course by clicking on the course name.**
* Example Input: "Remedial Physics"
* Example Output: "Remedial Physics" Students: "Marc"

**The registrar can see a list of all courses taken by a student by clicking on the student.**
* Example Input: "Marc"
* Example Output: "Jazz Hands for Jesus", "Sprinting", "Power-Walking", "Chorus with Christ"

***

## Support and contact details

Please contact Allie Holcombe at alexandra.holcombe@gmail.com or Marc Larkin at larkimarc@gmail.com with any questions, concerns, or suggestions.

***

## Technologies Used

This web application uses:
* Nancy
* Mono
* DNVM
* C#
* Razor
* MSSQL & SSMS

***

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Alexandra Holcombe & Marc Larkin_**

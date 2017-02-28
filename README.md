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

<!-- ### Course class
================

**The DeleteAll method for the Course class will will delete all rows from the clients table.**
* Example Input: none
* Example Output: nothing

**The GetAll method for the Course class will return an empty list if there are no entries in the Course table.**
* Example Input: N/A, automatically loads on home page
* Example Output: empty list

**The Equals method for the Course class will return true if the Course in local memory matches the Course pulled from the database.**
* Example Input:  
        > Local: "Elizabeth", stylist_id is 4, id is 10  
        > Database: "Elizabeth", stylist_id is 4, id is 10  
* Example Output: `true`

**The Save method for the Course class will save new Courses to the database.**
* Example Input:  
\> New client: "Jennifer", `stylist_id`
* Example Output: no return value

**The Save method for the Course class will assign an id to each new instance of the Course class.**
* Example Input:  
\> New stylist: "Jennifer", `stylist_id`, `local id: 0`  
* Example Output:  
\> "Jennifer",  `stylist_id`, `database-assigned id`  

**The GetAll method for the Course class will return all client entries in the database in the form of a list.**
* Example Input:  
        > "Elizabeth", id is 10  
        > "Katie", id is 11  
* Example Output: `{Elizabeth object}, {Katie object}`

**The Find method for the Course class will return the Course as defined in the database.**
* Example Input: "Jennifer", `stylist_id`,
* Example Output: "Jennifer", `stylist_id`, `database-assigned id`

**The Update method for the Course class will return the Course with the new name.**
* Example Input: "Jennifer", `stylist_id`, id is 10
* Example Output: "Jenny", `stylist_id`, id is 10

**The Delete method for the Course class will return a list of Courses without the deleted Course.**
* Example Input: "Jennifer", `stylist_id`
* Example Output: "Kacey, Allison, Claire" -->


### Student && Client Classes
=========================  

**The GetClients method for the Stylist class will return a list of all Clients with a stylist_id that matches the Stylist's id property.**
* Example Input: "Jennifer"
* Example Output: `{List of Jennifer's Clients}`

### User Interface
===================  

**The registrar can add a new Student using the "Add Student" form.**
* Example Input: New Student: "Jennifer", 02/28/2017
* Example Output: All students: "Allison, Kacey, Jennifer"

<!-- **The user can add a new client using the "Add client" form.**
* Example Input: New Client: "Rebecca", Stylist: "Elizabeth"
* Example Output: Elizabeth's clients: "Claire, Rebecca"

**The user can click on any stylist in the Stylists list to view a new page with a list of the stylist's clients**
* Example Input: *jennifer clicky*
* Example Output: "Rebecca, Nicole, Claire"

**The user can edit a client using a link on the client's page which will lead to a change form.**
* Example Input:  
    \> *jennifer clicky*  
    \> New name: "Jenny"  
* Example Output: "Jenny", Stylist: "Allison"

**The user can delete a client using a link on the client's page which will lead to a change form.**
* Example Input:  
    \> *jennifer clicky*  
    \> *delete clicky*  
    \> *confirmation clicky*
* Example Output: Elizabeth's clients: "Rebecca, Claire" -->

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

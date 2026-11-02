E-Contact Management System
About the Project

E-Contact Management System is a desktop application developed using C#, Windows Forms and MySQL. It helps users manage contact information easily through a simple and user-friendly interface.

Features
Add new contacts
Update existing contact details
Delete contacts
Search contacts
View all contact records
Clear input fields
Technologies Used
C#
Windows Forms
MySQL Database
MySql.Data Connector
Visual Studio
Database Details

Database Name: EContactDB

Table Name: Contact

Column	Data Type
ContactID	INT (Primary Key, Auto Increment)
FirstName	VARCHAR(50)
LastName	VARCHAR(50)
ContactNo	VARCHAR(15)
Address	VARCHAR(255)
Gender	VARCHAR(10)
Installation and Setup
Clone or download this repository.
Open the project in Visual Studio.
Install the MySql.Data NuGet package.
Create the MySQL database named EContactDB.
Create the Contact table.
Configure the MySQL connection string in connection.cs.
Run the application.
Database Connection

Configure your connection string:

csharp
Server=localhost;Port=3308;Database=EContactDB;Uid=root;Pwd=1234;

Author

Developed as a C# Windows Forms and MySQL database management project.

License

This project is intended for educational purposes.

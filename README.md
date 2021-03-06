# Website
If you want to view the website you can view it at: https://jasontruong1321.azurewebsites.net

It is currently hosted on azure using CI/CD.

# Instructions
1. Navigate to the \dbscripts folder and update the 'run.bat' to point to the correct machine and SQL Server instance

Example:<br />
sqlcmd /S %COMPUTERNAME%\{SqlInstance} /i RemoveDatabase.sql<br />
sqlcmd /S %COMPUTERNAME%\{SqlInstance} /i CreateDatabase.sql<br />

2. Run the 'run.bat' file. 
3.The Batch script installs the a new Database and Table on a local instance of SQL.
4. In the Code, Navigate to the Constants and update the 'ComputerName' and 'SqlServer' constants to use the correct computer name and SQL Server instance.

# UserProjectWebApi
The User Project is a Single Page Application that uses the ASP.NET Web API to request for projects associated to the user and displays them using a combination of jQuery, Knockout, and Moment.Js to display values in a table.

![HomePage](/images/DefaultWebPage.PNG)
The Default Web page does not have any users selected so no web pages are displayed in the table.

![DropDown](/images/DropDown.PNG)
The Drop Down has a list of all the available users from the SQL database. The connection to the database is handled using the Entity Framework.

![Selected](/images/UserSelected.PNG)
Selecting any of the users will populate the table with all the associated project information.

# Instructions
Navigate to the \dbscripts folder and use the 'run.bat'. A database should be installed on a local instance of SQL. Afterwards the code can be compiled.

# UserProjectWebApi
The User Project is a Single Page Application that uses the ASP.NET Web API to request for projects associated to the user and displays them using a bootstrap table.

![HomePage](/images/DefaultWebPage.PNG)
The Default Web page does not have any users selected so no web pages are displayed in the table.

![DropDown](/images/DropDown.PNG)
The Drop Down has a list of all the available users from the SQL database. The connection to the database is handled using the Entity Framework.

![Selected](/images/UserSelected.PNG)
Selecting any of the users will populate the table with all the associated project information.

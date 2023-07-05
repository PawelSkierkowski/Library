# Library

Required software:
-.NET 6.0 SDK
-MSSQL Server

Steps to run the application:
1. Go to the Library\WebAPI folder
2. Edit the appsettings.json file.
3. Replace the connection string to use the local MSSQL server
4. Make sure the database does not already exist (new migration will be executed when running the app)
5. Open the terminal and execute "dotnet run Library.WebAPI.dll"

Note: Postman collection with example usage is included in the main folder.

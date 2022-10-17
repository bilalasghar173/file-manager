# file-manager
An API project and a web project to upload and manage files on a server.

Please follow these steps for running this application:

1) Checkout the code
2) Create a new database in SQL Server named "FileManagerDb"
3) Locate a file "FileManagerDb.sql" in the repo and execute the script in your newly created db.
4) Open the code in VisualStudio, and change the web.config of the API project according to your SQL Server Creds;
![image](https://user-images.githubusercontent.com/38526620/196122795-15a39725-1f69-4b55-8f61-a37827a89f9b.png)


Run the project now, you will see two tabs opening, one will run the APIs and other is the web portal. You can now add/delete files on the portal here. These files will be saved in API/Files folder.
You can also see the log file in API/Logs folder in case any method fails.


Please note following are the exposed methods in the APIs.
![image](https://user-images.githubusercontent.com/38526620/196134841-98372718-0a02-4593-99ab-e8459ef1dd67.png)

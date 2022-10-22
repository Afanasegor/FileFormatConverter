Stack
-----
* .NET Core 3.1 ([download](https://dotnet.microsoft.com/en-us/download/dotnet/3.1))
* ASP.NET WebApi
* EntityFramework (MSSQLServer)
* Vue.js
* PuppeterSharp
* Hangfire
* Swagger docs


Build process
----

Backend
-----
1) Download all nuget packeges and dependencies of project
2) Install SQLServerExpress
3) Choose project to start: FileFormatConverter.WebApi


Frontend
-----
1) Install NodeJs (LTS)
2) Go to context of project in terminal `.\frontend`
3) Start loading all dependencies using command `npm i`   
*Also if host addres will be changed on backend, set address and port in `.env` file in directory `.\frontend`
4) Launch frontend using command `npm run serve`


Workflow
-----
After starting backend and frontend u can go to main page (default localhost:8080 if running locally)   
U can see 3 pages. On the second one u can go over HTML-to-PDF screen or click on the navigation bar. Here u will see list of all your processes. If process is completed, you can download the result file (PDF).      
Also in admin page u can clear list of processes and go to different links (swagger | hangfire | git-project).

## Info
Assignment: Intermediate – Senior (Full-stack)

## TODO
- [ ] Upgrade Angular frontend from 7.0.4 to 13.1.1
- [ ] Upgrade .Net Core API Backend from 2.1 to 5.0

# Angular 7 Project with ASP.NET CORE 2.1 (GYM MANAGEMENT)

## Getting Started

This project contains good features which are required in all project which are developed in industries nowadays.
Let’s see what is this project all about, this project is a basic gym project which has 2 modules in it

1.	Admin end
2.	User end

### Admin end
Let’s start with admin end first in this part admin has all right of applications master such as adding Users, Role, Scheme, Plan, and various reports such as month wise income and year wise income reports, all member reports and also has a renewal report which shows how much renewal are there for period admin choose.

### User end
If you see User end where a User is a person who does work of registration of new members and collecting payment of membership. The user has limited access such user can register a new member and renew membership and see payment details of the member along with renewal date.
The project has 3 parts 
1.	Angular CLI which is on top of node js
2.	ASP.NET Core for APIS
3.	SQL server for database parts

### Database of Project
Will be made available on request to se.dube28@gmail.com

### About Platform and Tools Used 
Angular Version Used 7.0.4 and CLI version 7.0.6
Visual Studio Professional 2019
Visual Studio Code


### External packages which are used in .Net Core Project
1. JWT Token for Authentication of APIS
2. Dapper ORM
3. AutoMapper
4. System.Linq.Dynamic.Core
5. Swashbuckle.AspNetCore

### External packages which are used in Angular Project
1. @angular/material
2. @ngx-bootstrap/datepicker

### How To Run Both Projects side by side.
1. First of all Clone repository to your local machine which have two project.
2. Open "WebGYM.sln" under <strong> "WebGYM"</strong> Directory and Run Web API Project (API Run with default port <strong>"49749" or "5000" </strong>, Later on you can change this) which display all avaialble endpoint for API
3. To Run Angular Project you have to <strong>Open Command Prompt</strong> with run as administrator
4. cd <strong> "{FullDirectorypath}\Angular-7-Project-with-ASP.NET-CORE-APIS\gym-project" </strong>
5. Install npm dependency by running <strong>"npm install"</strong> command
6. In case if you have changed WebAPI Project running port then you need to change ApiEndPoint url in <strong> "environment\environment.ts"</strong> other wise skip this step.
7. Final step run command <strong> ng serve or npm start </strong> which run on default port <strong>"4200"</strong>
## Note : Run Visual studio 2019, Visual Studio Code or Command Prompt as Administrator in windows system to avoid some issue.

### Credentials <br>

### =========== User =========== <br>
Username :- user<br>
Password :- 123456<br>

### =========== Admin =========== <br>
Username :- admin<br>
Password :- 123456<br>

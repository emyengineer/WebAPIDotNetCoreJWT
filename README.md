# WebAPIDotNetCoreJWT

Project
31-03-2023 12:13 a.m
==================================
commit the project file to GitHub == done

add user class model ==> done , created D.B context

make sure table User is created in the D.B ==> Done

Create the GET method ==> Done

Create the POST method ==> Done

Add the JWT security token

Generate the correct Id value based on hashing and salting ==> DONE 

Ommit the Email value if the Marketing Consent is false

======================================
Add Genre table to the database

add-migration AddGenresTable
Remove-Migration 

update-database

https://github.com/emyengineer/WebAPIDotNetCoreJWT


https://www.youtube.com/watch?v=KYhbgEQDFcY&list=PL62tSREI9C-eYNE1Pyw0yv1tETs5V8WGd&index=2

Install-Package System.IdentityModel.Tokens.Jwt

Need packages:
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
Install-Package System.IdentityModel.Tokens.Jwt

Generate Key: https://8gwifi.org/jwsgen.jsp


==================================================================
Remove-Migration

Add-migration InitialCreate
update-database

====================================================================
Add-Migration SeedRoles 
update-database

[Arabic] Secure ASP NET 5 API with JWT Authentication - 06 Prepare Registration EndPoint

4-4-2023 Tuesday
================
[Arabic] Secure ASP NET 5 API with JWT Authentication - 07 Registration EndPoint Part 2

eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJlbXl6MyIsImp0aSI6IjhkZGFiNmVmLTA4NGItNDkwNy04MTY1LTU5ZGRjZWEyYzM2YyIsImVtYWlsIjoiZW15ejNAZ21haWwuY29tIiwidWlkIjoiNTZFM0Q3OUE2MTYzNDYzMDRGODdFN0Y1NkZEMEVDOUNGNTRGQTY4RDI2MTk4QkZERERFQTM5RkU4QjRBRTQ4N0E4OTE1Njc4NUQ0QzNFOTE1MzExNTI0NEVGOEUxQ0NERjBDMzRDRUVFRUI2QzlGRkExREM4RDcwMzYxODgzRDgiLCJyb2xlcyI6WyJVc2VyIiwiQWRtaW4iXSwiZXhwIjoxNjgzMjkwOTAzLCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.JOI1uY1Uibi6y6wCPJDtexwGsBqNOwMJkNtqb6f1G_Q











:: Global:
:: dotnet tool install -g dotnet-ef
:: FIXME: Add path but not found dotnet ef
::	- Replace `dotnet ef` with `C:\Users\mars\.dotnet\tools\dotnet-ef.exe`

:: Install dependencies:
:: dotnet add package AutoMapper --version 10.1.1
:: dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 8.1.1
:: dotnet add package BCrypt.Net-Next --version 4.0.3
dotnet add CopyNotionApi3 package Microsoft.EntityFrameworkCore.SqlServer
dotnet add CopyNotionApi3 package Microsoft.EntityFrameworkCore.Design

:: Initialize create database
:: dotnet ef migrations add InitialCreate
:: dotnet ef database update

:: Run: dotnet run

#TechEmpowerFrameworkBenchmarks
==============================

Additional web frameworks for the TechEmpower Framework Benchmarks, which are located here: https://github.com/TechEmpower/FrameworkBenchmarks

Initially, I am focused on adding .NET/C# based web frameworks. The benchmarks are running on a Linux server so Mono is being used, but the source code should compile and run on Windows also.

##Frameworks (with database access variants)
1. mono-httphandler
2. mono-mvc-dapper
3. mono-mvc-nhibernate
4. mono-mvc-raw
5. mono-nancy-dapper
6. mono-servicestack

###Notes:
- All projects use MySQL as the database. There is an included SQL script for creating a test database: database.sql
- mono-httphandler uses bare-bones HttpHandlers and will probably be the best performer because there is no real "framework" involved. It mirrors the Java servlet example. As I believe JSON serialization is one of the key indicators of performance, it has the option of using 3 different JSON serializers popular in the .NET world: NewtonSoft, ServiceStack and the default ASP.NET MVC serializer from System.Web.Extensions.dll. At present the rest of the ASP.NET MVC projects are using the default JSON serializer and should probably changed to use the fastest option (as servlet uses Jackson) which is probably going to be ServiceStack's serializer.
- The mvc projects are using the ASP.NET MVC web framework version 3 with the ASP.NET 4.0 DLLs.
- Dapper is a micro ORM created by Sam Saffron of StackOverflow fame. More info here: http://samsaffron.com/archive/2011/03/30/How+I+learned+to+stop+worrying+and+write+my+own+ORM
- Nhibernate is a popular full-featured ORM that is similar to Java's Hibernate ORM.
- Nancy is a lightweight framework for .NET that is similar to Sinatra for Ruby. More info here: http://nancyfx.org/
- mono-mvc-raw uses bare-bones ADO.NET calls for database access.
- mono-servicestack uses the ServiceStack framework which is supposed to have top performance for creating REST web services using .NET. It has it's own micro-ORM and JSON serializer which are supposed to be high performers. More info here: http://www.servicestack.net/benchmarks/
- AFAIK, the new Web API is not supported on Mono. See here: http://stackoverflow.com/questions/14126855/is-mono-capable-of-hosting-asp-net-mvc-webapi-in-mod-mono-yet

###Plans:
- Projects are using mono 2.10.x assemblies.  The plan is to upgrade to mono 3.0 and update the mvc projects to ASP.NET MVC 4. I'd like to also add Web API (new Microsoft framework for creating web services) and Entity Framework 5.0 variants if I can get them to work on Mono.
- Projects were created using Xamarin Studio 4.0 on Windows 7.  I am a more frequent user of Visual Studio, so I might switch back to Visual Studio in the future. I think Xamarin is a capable IDE, but it seems to lag behind Visual Studio when it comes to updates (example: MVC 4 Project Templates).

// See https://aka.ms/new-console-template for more information
using FodyExample;
using Serilog;

Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt")
            .WriteTo.Seq("http://localhost:5341")
            .MinimumLevel.Verbose()
            .CreateLogger();

Log.Information("Hello, {Name}!", Environment.UserName);
Console.WriteLine("Hello, World!");

var input = new InputClass() { IsActive = true, Name = "Tien", Value = "Admin" };

MyClass.MyMethod("test string", 12345, true, input);
//MyClass.Run("Tét");

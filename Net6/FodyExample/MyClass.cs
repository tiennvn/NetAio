using Serilog;
using System.Runtime.CompilerServices;

namespace FodyExample
{
    public class MyClass
    {

        [Interceptor]
        public static void MyMethod(string test, int number, bool isRight, InputClass input)
        {
            Console.WriteLine("Inside MyMethod");
        }

        [Interceptor]
        public static void MyExceptionMethod()
        {
            throw new("Foo");
        }
        public static void Run(string input, [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log.Information("Run MyMethod");
            Log.Information("Inside {@param}", methodName);
            Log.Information("Inside {@param}", filePath);
            Log.Information("Inside {@param}", lineNumber);
        }
    }

    public class InputClass
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }

    }
}

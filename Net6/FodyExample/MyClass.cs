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
    }

    public class InputClass
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }

    }
}

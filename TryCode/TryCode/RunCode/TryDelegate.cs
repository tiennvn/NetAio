namespace TryCode
{
    internal class TryDelegate
    {
        protected TryDelegate()
        {
        }

        public static void Run()
        {
            Console.WriteLine("RunCode");

            Predicate<string> checkCase = IsUpperCase;
            checkCase += IsLowerCase;

            checkCase += (str) =>
            {
                bool result = str.Equals("T");
                Console.WriteLine(result);
                return result;
            };

            //bool result = checkCase("hello world!!");

            //Console.WriteLine(result);

            TestDelegate(checkCase, "T");
        }

        static bool IsUpperCase(string str)
        {
            bool result = str.Equals(str.ToUpper());
            Console.WriteLine(result);
            return result;
        }

        public static bool IsLowerCase(string str)
        {
            bool result = str.Equals(str.ToLower()); ;
            Console.WriteLine(result);
            return result;

        }

        public static void TestDelegate(Predicate<string> param, string str)
        {
            var result = param(str);
            //result.
        }


    }
}

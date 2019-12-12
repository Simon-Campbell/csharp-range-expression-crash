using System;
using System.Linq.Expressions;

namespace csharp_range_expression_crash
{
    class Program
    {
        static void Main(string[] args)
        {
            var predicate =
                CreateCrashingExpression()
                    .Compile();

            var result = predicate("xxxxxRIGHTSUFFIX");

            // Should be true if the compiler did not
            // crash!
            Console.WriteLine(result);
        }

        public static Expression<Func<string, bool>> CreateCrashingExpression()
        {
            // Create an expression that compares the "tail" of the string value
            // with some known value.
            return (string a) => a[7..] == "RIGHTSUFFIX";
        }
    }

}
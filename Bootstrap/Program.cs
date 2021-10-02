//
//
//

using System;

using static System.Console;

namespace Neu
{
    public static partial class Program
    {
        public static void Main(
            String[] args)
        {
            var arguments = args
                .ToArguments();

            WriteLine(arguments);
            // args

            WriteLine("Hello World!");
        }
    }
}

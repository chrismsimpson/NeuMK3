//
//
//

using System;
using System.Diagnostics;
using System.Threading.Tasks;

using static System.Console;

namespace Neu
{
    public static partial class Program
    {
        public static async Task Main(
            String[] args)
        {
            var arguments = args
                .ToArguments();

            ///

            var name = arguments
                .GetFirstArgument();

            var command = arguments
                .ToCommand();

            ///

            var stopwatch = Stopwatch.StartNew();

            WriteLine($"\n//");
            WriteLine($"//  Neu.Bootstrap: {command.GetType().ToString()}");

            await command
                .Run(
                    arguments: arguments);

            stopwatch.Stop();

            WriteLine($"Command \"{name}\" completed in {stopwatch.GetElapsedString()}");
        }
    }
}

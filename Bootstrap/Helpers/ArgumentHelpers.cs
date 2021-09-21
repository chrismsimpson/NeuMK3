//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

namespace Neu
{
    public static partial class ArgumentHelpers
    {
        public static IEnumerable<IArgument> ToArguments(
            this String[] args)
        {
            var parser = ArgsParser.FromArgs(args);

            var arguments = parser.ParseArguments();

            return arguments;
        }

        public static String? Get(
            this IEnumerable<IArgument> arguments,
            String name)
        {
            throw new Exception();
        }

        public static String? GetFirstArgumentString(
            this IEnumerable<IArgument> arguments)
        {
            switch (arguments.FirstOrDefault())
            {
                case Option opt:
                    return opt.Opt.Source;

                ///

                case Argument arg:
                    return arg.Arg.Source;

                ///

                default:
                    return null;
            }
        }
    }
}
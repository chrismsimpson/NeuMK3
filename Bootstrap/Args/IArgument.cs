//
//
//

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using static Neu.PathFunctions;

namespace Neu
{
    public interface IArgument { }

    ///

    public static partial class iArgumentFunctions
    {
        public static bool IsFile(
            this IArgument argument)
        {
            var current = GetCurrentDirectoryPath();

            return argument.IsFile(current);
        }

        public static bool IsFile(
            this IArgument argument,
            Path path)
        {
            var a = argument as Argument;

            if (a == null)
            {
                return false; // an option can't be a file
            }

            ///

            var location = a.Arg.Source.ToPathLocation();

            var dest = location.Traverse(path);

            var p = dest.ToPathString();

            if (File.Exists(p))
            {
                return true;
            }

            return false;
        }
    

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

        public static String? GetFirstArgument(
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

        public static String ToAbsolutePathString(
            this IArgument argument)
        {
            var a = argument as Argument;

            if (a == null)
            {
                throw new Exception();
            }

            ///

            return a.Arg.Source.ToAbsolutePathString();
        }
    }
}
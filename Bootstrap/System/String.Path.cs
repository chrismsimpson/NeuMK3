//
//
//

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using static System.Console;
using static System.String;

using static System.IO.Directory;
using static System.IO.Path;

using static Neu.PathFunctions;
using static Neu.PathLocationFunctions;

namespace Neu
{
    public static partial class StringFunctions
    {
        public static Path ToPath(
            this String source)
        {
            var parser = PathParser.FromString(source);

            return parser.ParsePath();
        }

        public static PathLocation ToPathLocation(
            this String source)
        {
            var path = source.ToPath();

            return new PathLocation(path);
        }

        public static String ToAbsolutePathString(
            this String source)
        {
            var current = GetCurrentDirectoryPath();

            var pathLoc = source.ToPathLocation();

            var dest = pathLoc.Traverse(current);

            return dest.ToPathString();
        }

        public static bool IsFile(
            this String source)
        {
            var current = GetCurrentDirectoryPath();

            return source.IsFile(current);
        }

        public static bool IsFile(
            this String source,
            Path path)
        {
            var location = source.ToPathLocation();

            var dest = location.Traverse(path);

            var p = dest.ToPathString();

            if (File.Exists(p))
            {
                return true;
            }

            return false;
        }
    }
}
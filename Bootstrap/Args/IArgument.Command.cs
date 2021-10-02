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
    public static partial class IArgumentFunctions
    {
        public static ICommand ToCommand(
            this IEnumerable<IArgument> arguments)
        {
            switch (arguments.GetFirstArgument())
            {
                case "neu":
                    return arguments.ToNeuCommand();

                ///

                default:
                    throw new Exception();
            }
        }
    }
}
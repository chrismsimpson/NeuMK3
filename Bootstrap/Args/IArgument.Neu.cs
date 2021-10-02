//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class IArgumentFunctions
    {
        public static ICommand ToNeuCommand(
            this IEnumerable<IArgument> arguments)
        {
            switch (arguments.GetFirstArgument())
            {
                case "neu" when !arguments.AnyArgumentsAfterFirst():
                    return new NeuRunInteractiveCommand();

                ///

                case "neu" when arguments.GetSecondArgument() == "tests":
                    return new NeuRunTestsCommand();

                ///

                case "neu":
                    return new NeuRunSourceFileCommand();

                ///

                default:
                    throw new Exception();
            }
        }
    }
}
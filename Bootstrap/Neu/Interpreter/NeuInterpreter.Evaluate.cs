//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

namespace Neu
{
    public static partial class NeuInterpreterFunctions
    {
        public static NeuValue Evaluate(
            this NeuInterpreter interpreter,
            IEnumerable<IArgument> arguments)
        {
            var argument = arguments.FirstOrDefault();

            if (argument == null)
            {
                throw new Exception();
            }

            return interpreter.Evaluate(argument);
        }

        public static NeuValue Evaluate(
            this NeuInterpreter interpreter,
            IArgument? argument)
        {
            if (argument == null)
            {
                throw new Exception();
            }

            ///

            if (!argument.IsFile())
            {
                throw new Exception();
            }

            ///

            var a = argument as Argument;

            if (a == null)
            {
                throw new Exception();
            }

            ///

            var file = a.Arg.Source.ToAbsolutePathString();

            if (IsNullOrWhiteSpace(file))
            {
                throw new Exception();
            }

            ///

            return interpreter.Evaluate(file);
        }

        public static NeuValue Evaluate(
            this NeuInterpreter interpreter,
            String filename)
        {
            var parser = NeuParser.FromFile(filename);

            ///

            var script = parser.ParseSourceFile();

            ///

            return interpreter.Run(script);
        }
    }
}
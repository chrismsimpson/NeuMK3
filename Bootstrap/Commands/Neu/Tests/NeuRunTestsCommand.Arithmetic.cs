//
//
//

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using static System.Console;
using static System.String;

namespace Neu
{
    public partial class NeuRunArithmeticTestCommand : ICommand
    {
        public NeuRunArithmeticTestCommand() { }

        ///

        public async Task Run(
            params String[] args)
        {
            await this.Run(args.ToArguments());
        }

        public async Task Run(
            IEnumerable<IArgument> arguments)
        {
            await Task.Run(() =>
            {
                var interpreter = new NeuInterpreter();

                ///

                var result = interpreter.Evaluate(arguments.DropArguments(number: 1));

                ///

                var floatResult = result as NeuFloat;

                if (floatResult == null)
                {
                    throw new Exception();
                }

                ///

                if (floatResult.Value != 2.5)
                {
                    throw new Exception();
                }

                WriteLine($"{arguments.GetFirstArgument()} successful");
            });
        }
    }
}
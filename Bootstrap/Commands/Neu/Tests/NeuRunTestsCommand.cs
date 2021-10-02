//
//
//

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static System.Console;

namespace Neu
{
    public partial class NeuRunTestsCommand : ICommand
    {
        public NeuRunTestsCommand() { }

        ///

        public async Task Run(
            IEnumerable<IArgument> arguments)
        {
            WriteLine($"//  {arguments.GetFirstArgument()}\n");

            await (new NeuRunArithmeticTestCommand())
                .Run("neu", "../Tests/Neu/test01.neu");
        }
    }
}
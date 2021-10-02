//
//
//

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static System.Console;

namespace Neu
{
    public partial class NeuRunInteractiveCommand : ICommand
    {
        public NeuRunInteractiveCommand() { }

        ///

        public async Task Run(
            IEnumerable<IArgument> arguments)
        {
            WriteLine($"//  {arguments.GetFirstArgument()}\n");

            await Task.Run(() =>
            {
                throw new Exception();
            });
        }
    }
}
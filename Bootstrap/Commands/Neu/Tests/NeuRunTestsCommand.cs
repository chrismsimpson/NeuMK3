//
//
//

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neu
{
    public partial class NeuRunTestsCommand
    {
        public NeuRunTestsCommand() { }

        ///

        public async Task Run(
            IEnumerable<IArgument> arguments)
        {
            await Task.Run(() => {});

            throw new Exception();
            
            // WriteLine($"//  {arguments.GetFirstArgument()}\n");

            // await (new NeuRunArithmeticTestCommand())
            //     .Run("neu", "../Tests/Neu/test01.neu");
            
            // await Task.Run(() => {});
        }
    }
}
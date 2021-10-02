//
//
//

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static System.Console;
using static System.String;

namespace Neu
{
    public partial class NeuRunSourceFileCommand : ICommand
    {
        public NeuRunSourceFileCommand() { }

        ///

        public async Task Run(
            IEnumerable<IArgument> arguments)
        {
            WriteLine($"//  {arguments.GetFirstArgument()}\n");

            await Task.Run(() =>
            {
                var interpreter = new NeuInterpreter();

                ///

                var sourceFiles = new List<NeuSourceFile>();

                ///

                foreach (var argument in arguments)
                {
                    if (!argument.IsFile())
                    {
                        throw new Exception();
                    }

                    ///

                    var file = argument.ToAbsolutePathString();

                    if (IsNullOrWhiteSpace(file))
                    {
                        throw new Exception();
                    }

                    ///

                    var parser = NeuParser.FromFile(file);

                    ///

                    var sourceFile = parser.ParseSourceFile();

                    WriteLine($"AST:");

                    WriteLine($"{sourceFile.Dump()}\n");

                    ///

                    var result = interpreter.Run(sourceFile);

                    WriteLine($"Value: {result.Dump()}\n");

                    ///

                    sourceFiles.Add(sourceFile);
                }
            });
        }
    }
}
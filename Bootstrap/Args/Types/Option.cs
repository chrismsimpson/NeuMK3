//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class Option : IArgument
    {
        public OptionToken Opt { get; init; }

        public IEnumerable<ArgToken> Args { get; init; }

        ///

        public Option(
            OptionToken opt,
            IEnumerable<ArgToken> args)
        {
            this.Opt = opt;
            this.Args = args;
        }
    }
}
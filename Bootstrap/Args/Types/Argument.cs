//
//
//

using System;

namespace Neu
{
    public partial class Argument : IArgument
    {
        public ArgToken Arg { get; init; }

        ///
        public Argument(
            ArgToken arg)
        {
            this.Arg = arg;
        }
    }
}
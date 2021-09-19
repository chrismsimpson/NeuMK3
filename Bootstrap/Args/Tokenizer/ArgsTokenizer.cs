//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class ArgsTokenizer
    {
        // internal ArgsScanner Scanner { get; init; }

        internal IList<ArgsToken> Tokens { get; init; }

        internal int Counter { get; init; }

        public ArgsTokenizer()
        {
            

            this.Tokens = new List<ArgsToken>();

            this.Counter = 0;
        }
    }
}
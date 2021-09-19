//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class Tokenizer<T> where T : Token
    {
        internal Scanner Scanner { get; init; }

        internal IList<T> Tokens { get; init; }

        internal int Counter { get; init; }

        ///

        public Tokenizer(
            Scanner scanner)
        {
            this.Scanner = scanner;

            this.Tokens = new List<T>();

            this.Counter = 0;
        }
    }
}
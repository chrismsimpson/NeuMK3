//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class ArgsParser
    {
        internal ArgsTokenizer Tokenizer { get; init; }

        ///

        public ArgsParser(
            ArgsTokenizer tokenizer)
        {
            this.Tokenizer = tokenizer;
        }
    }

    ///

    public partial class ArgsParser
    {
        public static ArgsParser FromArgs(
            IEnumerable<String> args)
        {
            throw new Exception();
            
            // return new ArgsParser(
            //     ArgsTokenizer.FromArgs(args));
        }
    }
}
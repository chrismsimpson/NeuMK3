//
//
//

using System;

namespace Neu
{
    public partial class NeuParser : Parser<NeuToken>
    {
        public NeuParser(
            NeuTokenizer tokenizer)
            : base(tokenizer) { }
    }

    ///

    public partial class NeuParser
    {
        public static NeuParser FromFile(
            String fullPath)
        {
            return new NeuParser(
                NeuTokenizer.FromFile(fullPath));
        }
    }
}
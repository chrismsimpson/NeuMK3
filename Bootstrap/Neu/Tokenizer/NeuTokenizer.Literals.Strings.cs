//
//
//

using System;

namespace Neu
{
    public partial class NeuTokenizer
    {
        public static bool IsStringLiteralStart(
            Char c)
        {
            return c == '"';
        }
    }

    ///

    public static partial class NeuTokenizerFunctions
    {
        public static NeuStringLiteral TokenizeStringLiteral(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Next() is NeuStringLiteral s)
            {
                return s;
            }

            throw new Exception();
        }
    }
}
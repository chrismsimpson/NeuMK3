//
//
//

using System;

namespace Neu
{
    public partial class NeuTokenizer
    {
        public static bool IsNumericLiteralStart(
            Char c)
        {
            return c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '.';
        }

        public static bool IsNumericLiteralPart(
            Char c)
        {
            return c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '.';
        }
    }
}
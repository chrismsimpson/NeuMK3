//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

using static Neu.PathTokenizer;

namespace Neu
{
    public static partial class PathTokenizerFunctions
    {
        public static PathComponent RawTokenizeComponent(
            this Tokenizer<PathToken> tokenizer)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var source = tokenizer.Scanner.Consume(c => IsComponentPart(c));

            ///

            return new PathComponent(
                source: source,
                start: start,
                end: tokenizer.Scanner.GetPosition());
        }

        ///

        public static ParentDirectoryComponent RawTokenizeParentDirectoryComponent(
            this Tokenizer<PathToken> tokenizer)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var source = tokenizer.Scanner.Consume("..");

            ///

            return new ParentDirectoryComponent(
                source: source,
                start: start,
                end: tokenizer.Scanner.GetPosition());
        }

        public static CurrentDirectoryComponent RawTokenizeCurrentDirectoryComponent(
            this Tokenizer<PathToken> tokenizer)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var source = tokenizer.Scanner.Consume(".");

            ///

            return new CurrentDirectoryComponent(
                source: source,
                start: start,
                end: tokenizer.Scanner.GetPosition());
        }
    }
}
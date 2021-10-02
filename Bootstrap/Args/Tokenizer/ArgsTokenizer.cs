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
        internal ArgsScanner Scanner { get; init; }

        internal IList<ArgToken> Tokens { get; init; }

        internal int Counter { get; set; }

        ///

        public ArgsTokenizer(
            ArgsScanner scanner)
        {
            this.Scanner = scanner;

            this.Tokens = new List<ArgToken>();

            this.Counter = 0;
        } 
    }

    ///

    public partial class ArgsTokenizer
    {
        public static ArgsTokenizer FromArgs(
            IEnumerable<String> args)
        {
            return new ArgsTokenizer(
                new ArgsScanner(args));
        }
    }

    ///

    public static partial class ArgsTokenizerFunctions
    {
        public static bool IsEof(
            this ArgsTokenizer tokenizer)
        {
            if (tokenizer.Position() == tokenizer.Scanner.Position)
            {
                return tokenizer.Scanner.IsEof();
            }

            return false;
        }

        ///

        public static int Position(
            this ArgsTokenizer tokenizer)
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                return tokenizer.Tokens.ElementAt(tokenizer.Counter).Position;
            }

            return tokenizer.Scanner.Position;
        }

        ///

        public static ArgToken? Next(
            this ArgsTokenizer tokenizer)
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                var token = tokenizer.Tokens.ElementAt(tokenizer.Counter);

                tokenizer.Counter++;

                return token;
            }

            ///

            if (tokenizer.Scanner.IsEof())
            {
                return null;
            }

            ///

            var next = tokenizer.RawNext();

            tokenizer.Tokens.Add(next);

            tokenizer.Counter++;

            return next;
        }

        private static ArgToken RawNext(
            this ArgsTokenizer tokenizer)
        {
            switch (tokenizer.Scanner.RawNext())
            {
                case String next when next.StartsWith("--"):
                    return tokenizer.RawTokenizeOptionToken();

                case String next when next.StartsWith("/") || next.EndsWith(".dll") || next == "./":
                    return tokenizer.RawTokenizeUnknownArgToken();

                case String _:
                    return tokenizer.RawTokenizeArgToken();

                default:
                    throw new Exception();
            }
        }

        private static OptionToken RawTokenizeOptionToken(
            this ArgsTokenizer tokenizer)
        {
            var position = tokenizer.Scanner.Position;

            ///

            return new OptionToken(
                source: tokenizer.Scanner.Consume(),
                position: position);
        }

        private static UnknownArgToken RawTokenizeUnknownArgToken(
            this ArgsTokenizer tokenizer)
        {
            var position = tokenizer.Scanner.Position;

            ///

            return new UnknownArgToken(
                source: tokenizer.Scanner.Consume(),
                position: position);
        }

        private static ArgToken RawTokenizeArgToken(
            this ArgsTokenizer tokenizer)
        {
            var position = tokenizer.Scanner.Position;

            ///

            return new ArgToken(
                source: tokenizer.Scanner.Consume(),
                position: position);
        }

        ///

        public static OptionToken TokenizeOptionToken(
            this ArgsTokenizer tokenizer)
        {
            if (tokenizer.Next() is OptionToken t)
            {
                return t;
            }

            throw new Exception();
        }

        public static UnknownArgToken TokenizeUnknownArgToken(
            this ArgsTokenizer tokenizer)
        {
            if (tokenizer.Next() is UnknownArgToken t)
            {
                return t;
            }

            throw new Exception();
        }

        public static ArgToken TokenizeArgToken(
            this ArgsTokenizer tokenizer)
        {
            if (tokenizer.Next() is ArgToken t)
            {
                return t;
            }

            throw new Exception();
        }
    }
}
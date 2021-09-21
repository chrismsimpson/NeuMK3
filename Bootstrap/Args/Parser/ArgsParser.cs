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
            return new ArgsParser(
                ArgsTokenizer.FromArgs(args));
        }
    }

    ///

    public static partial class ArgsParserHelpers
    {
        public static IEnumerable<IArgument> ParseArguments(
            this ArgsParser parser)
        {
            var arguments = new List<IArgument>();

            ///

            while (!parser.Tokenizer.IsEof())
            {
                var argument = parser.ParseArgument();

                arguments.Add(argument);
            }

            ///

            return arguments;
        }

        public static IArgument ParseArgument(
            this ArgsParser parser)
        {
            switch (parser.Tokenizer.Peek())
            {
                case OptionToken _:
                    return parser.ParseOption();

                default:
                    return parser.ParseSingleArgument();
            }
        }

        public static Argument ParseSingleArgument(
            this ArgsParser parser)
        {
            var arg = parser.Tokenizer.TokenizeArgToken();

            ///

            return new Argument(
                arg: arg);
        }

        public static Option ParseOption(
            this ArgsParser parser)
        {
            var opt = parser.Tokenizer.TokenizeOptionToken();

            ///

            var args = parser.ParseArgTokens();

            ///

            return new Option(
                opt: opt,
                args: args);
        }

        public static IEnumerable<ArgToken> ParseArgTokens(
            this ArgsParser parser)
        {
            var args = new List<ArgToken>();

            ///

            while (!parser.Tokenizer.IsEof())
            {
                if (parser.Tokenizer.PeekOptionToken())
                {
                    break;
                }

                ///

                var arg = parser.Tokenizer.TokenizeArgToken();

                args.Add(arg);
            }

            ///

            return args;
        }
    }
}
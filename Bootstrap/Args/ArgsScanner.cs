//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class ArgsScanner
    {
        public IEnumerable<String> Args { get; init; }

        internal int Position { get; set; }

        ///

        public ArgsScanner(
            IEnumerable<String> args)
        {
            this.Args = args;

            this.Position = 0;
        }
    }

    ///

    public static partial class ArgsScannerFunctions
    {
        public static String Consume(
            this ArgsScanner scanner)
        {
            var arg = scanner.Args.ElementAt(scanner.Position);

            scanner.Position++;

            return arg;
        }

        public static IEnumerable<String> ConsumeUntil(
            this ArgsScanner scanner,
            Func<String, bool> test)
        {
            var result = new List<String>();

            while (!scanner.IsEof() && !test(scanner.RawNext()))
            {
                result.Add(scanner.Consume());
            }

            return result;
        }

        public static bool IsEof(
            this ArgsScanner scanner)
        {
            return scanner.Position == scanner.Args.Count();
        }

        public static String RawNext(
            this ArgsScanner scanner)
        {
            return scanner.Args.ElementAt(scanner.Position);
        }
    }
}
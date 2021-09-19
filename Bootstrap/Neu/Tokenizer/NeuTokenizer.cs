//
//
//

using System;
using System.Linq;

using static System.IO.File;

namespace Neu
{
    public partial class NeuTokenizer : Tokenizer<NeuToken>
    {
        public NeuTokenizer(
            Scanner scanner)
            : base(scanner) { }
    }

    ///

    public partial class NeuTokenizer
    {
        public static NeuTokenizer FromFile(
            String file)
        {
            var contents = ReadAllText(file);

            return new NeuTokenizer(
                new Scanner(contents));
        }
    }
}
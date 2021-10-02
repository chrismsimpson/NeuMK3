//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

namespace Neu
{
    public partial class NeuKey
    {
        public String? Value { get; init; }

        ///

        public NeuKey(
            String? value)
        {
            this.Value = value;
        }
    }

    ///

    public static partial class NeuKeyFunctions
    {
        public static void SetValue<Value>(
            this IDictionary<NeuKey, Value> dictionary,
            String? key,
            Value value)
        {
            dictionary[new NeuKey(key)] = value;
        }

        public static Value? GetValue<Value>(
            this IDictionary<NeuKey, Value> dictionary,
            String? key)
        {
            return dictionary.FirstOrDefault(x => x.Key.Value == key).Value;
        }

    }
}
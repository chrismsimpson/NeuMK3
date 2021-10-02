//
//
//

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neu
{
    public interface ICommand
    {
        Task Run(
            IEnumerable<IArgument> arguments);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Redactors
{
    public interface IMatcher : IRedactConfigurable<IMatcher, IRedactorOptions>
    {
        IEnumerable<IRedactorMatch> Match(string input);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Redactors
{
    public static class MatchProcessorFactory
    {
        public static IMatchProcessor GetMatchProcessor<T>() where T : IMatchProcessor
        {
            return Activator.CreateInstance<T>();
        }
    }
}

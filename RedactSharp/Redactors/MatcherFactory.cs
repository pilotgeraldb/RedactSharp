using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Redactors
{
    public static class MatcherFactory
    {
        public static IMatcher GetMatcher<T>() where T : IMatcher
        {
            return Activator.CreateInstance<T>();
        }
    }
}

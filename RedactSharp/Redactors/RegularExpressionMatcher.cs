using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RedactSharp.Redactors
{
    public class RegularExpressionMatcher : IExpressionMatcher, IRedactConfigurable<IMatcher, IRedactorOptions>
    {
        public IRedactorOptions Options { get; private set; }
        public string Expression { get; set; }

        public RegularExpressionMatcher()
        {
        }

        public RegularExpressionMatcher(string expression)
        {
            Expression = expression;
        }

        public IEnumerable<IRedactorMatch> Match(string input)
        {
            List<IRedactorMatch> matches = new List<IRedactorMatch>();

            if (Expression == null || string.IsNullOrWhiteSpace(input))
            {
                return matches;
            }

            Regex r = new Regex(Expression, RegexOptions.Multiline);
            MatchCollection mc = r.Matches(input);

            foreach (Match m in mc)
            {
                matches.Add(new RedactorMatch()
                {
                    Index = m.Index,
                    Length = m.Length,
                    Value = m.Value
                });
            }

            return matches;
        }

        public IMatcher Configure(IRedactorOptions options)
        {
            Options = options;

            return this;
        }
        public IRedactorOptions GetConfiguration()
        {
            return Options;
        }
    }
}

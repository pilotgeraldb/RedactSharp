using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Redactors
{
    public sealed class RedactorCollection : IRedactorCollection
    {
        public List<IRedactor> Redactors { get; set; }
        public IList<RedactorLogItem> Logs { get; set; }

        public RedactorCollection()
        {
            Redactors = new List<IRedactor>();
        }

        public string Redact(string stringToRedact)
        {
            if (stringToRedact == null)
            {
                return null;
            }

            StringBuilder input = new StringBuilder(stringToRedact);

            List<IRedactorResult> redactorResults = new List<IRedactorResult>();

            foreach (IRedactor r in Redactors)
            {
                IRedactorResult redactorResult = r.Redact(input.ToString());

                input = new StringBuilder(redactorResult.Result);

                redactorResults.Add(redactorResult);
            }

            return input.ToString();
        }        
    }
}

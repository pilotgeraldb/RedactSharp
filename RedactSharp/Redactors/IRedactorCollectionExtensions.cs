using RedactSharp.Redactors;
using System.Collections.Generic;

namespace RedactSharp.Redactors
{
    public static class IRedactorCollectionExtensions
    {
        public static IRedactorCollection Add(this IRedactorCollection collection, IRedactor redactor)
        {
            collection.Redactors.Add(redactor);

            return collection;
        }

        public static IRedactorCollection AddRange(this IRedactorCollection collection, IEnumerable<IRedactor> redactors)
        {
            collection.Redactors.AddRange(redactors);

            return collection;
        }
    }
}

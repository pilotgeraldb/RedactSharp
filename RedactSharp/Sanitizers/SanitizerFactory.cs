using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Sanitizers
{
    public class SanitizerFactory
    {
        public static ISanitizer GetSanitizer<T>()
        {
            if (typeof(T).GetInterfaces().Contains(typeof(ISanitizer)))
            {
                return (Activator.CreateInstance(typeof(T)) as ISanitizer);
            }

            return null;
        }

        public static ISanitizer GetSanitizer(Type type)
        {
            if (type.GetInterfaces().Contains(typeof(ISanitizer)))
            {
                return (Activator.CreateInstance(type) as ISanitizer);
            }

            return null;
        }
    }
}

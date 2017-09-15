using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Validators
{
    public static class ValidatorFactory
    {
        public static IValidator GetValidator<T>() where T : IValidator
        {
            return Activator.CreateInstance<T>();
        }
    }
}

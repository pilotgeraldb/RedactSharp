using System.Text.RegularExpressions;

namespace RedactSharp.Redactors
{
    public interface IMatchProcessor : IRedactConfigurable<IMatchProcessor, IRedactorOptions>
    {
        string Process(string input, IRedactorMatch m);
    }
}
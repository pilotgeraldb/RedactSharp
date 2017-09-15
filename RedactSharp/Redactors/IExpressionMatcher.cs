namespace RedactSharp.Redactors
{
    public interface IExpressionMatcher : IMatcher
    {
        string Expression { get; set; }
    }
}
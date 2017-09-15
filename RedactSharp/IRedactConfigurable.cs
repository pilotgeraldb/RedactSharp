namespace RedactSharp
{
    public interface IRedactConfigurable<TType, TOptions>
    {
        TType Configure(TOptions options);

        TOptions GetConfiguration();
    }
}
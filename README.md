# RedactSharp
A library for redacting text.

> this project is still under heavy development. The documentation is incomplete and still being updated.

## Basic Usage

Use a redactor collection to add all of the relevant redactors.

```csharp
var redactors = new RedactorCollection();
```

Register all of the relevant redactors.

```csharp
redactors.Add(CreditCardRedactors.All());
redactors.Add(new TelephoneRedactor());
redactors.Add(new SocialSecurityRedactor());
```

Redact your text.

```csharp
//redact your text
string input = "this is sample text with a credit card number 5105105105105100";
string output = redactors.Redact(input);

```

## Custom Redactors

The easiest way to create a redactor is to take advantage of the default redactor process by inheriting from `AbstractRedactor`.

```csharp
public class CustomCreditCardRedactor : AbstractRedactor
{
    public CustomCreditCardRedactor()
    {
        this.UseValidator<LuhnValidator>();
        this.UseExpressionMatcher<RegularExpressionMatcher>(@"(5[06-8]|6\d)\d{10,17}");
        this.UseFriendlyName("CustomCreditCardRedactor");
    }
}
```

If you prefer to write a custom redactor from the ground up you can implement `IRedactor`.

```csharp
public class MyCustomRedactor : IRedactor
{
    public string FriendlyName { get; set; }

    public IRedactorResult Redact(string input)
    {
        return new RedactorResult() { Result = input };
    }
}
```

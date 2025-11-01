namespace ProjectFlow.Domain.Projects;

public record Money
{
    public decimal Amount { get; init; }
    public Currency Currency { get; init; }

    private Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Create(decimal amount, Currency currency)
    {
        return new Money(amount, currency);
    }

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException("Cannot add money with different currencies");

        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static Money Zero() => new(0, Currency.None);
}
namespace ProjectFlow.Domain.Projects;

public record Name
{
    public string Value { get; init; }

    public Name(string value)
    {
        Value = value;
    }

    public static Name Create(string value)
    {
        return new Name(value.Trim());
    }
}
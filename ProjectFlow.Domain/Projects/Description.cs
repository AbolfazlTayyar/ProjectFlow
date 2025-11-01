namespace ProjectFlow.Domain.Projects;

public record Description
{
    public string Value { get; init; }

    public Description(string value)
    {
        Value = value;
    }

    public static Description Create(string value)
    {
        return new Description(value);
    }
}

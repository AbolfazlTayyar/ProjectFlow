using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id,
        FirstName firstName,
        LastName lastName,
        PhoneNumber phoneNumber)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }

    public static User Create(FirstName firstName, LastName lastName, PhoneNumber phoneNumber)
    {
        return new User(Guid.NewGuid(), firstName, lastName, phoneNumber)
        {
            CreatedOnUtc = DateTime.UtcNow
        };
    }
}

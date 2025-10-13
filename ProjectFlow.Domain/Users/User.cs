using ProjectFlow.Domain.Abstracts;
using ProjectFlow.Domain.Users.Events;

namespace ProjectFlow.Domain.Users;

public sealed class User : Entity
{
    private User(
        Guid id,
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
        User user = new(Guid.NewGuid(), firstName, lastName, phoneNumber);
        user.CreatedOnUtc = DateTime.UtcNow;

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}

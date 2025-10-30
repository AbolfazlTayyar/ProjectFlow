using Bogus;
using Dapper;
using ProjectFlow.Application.Abstractions.Data;

namespace ProjectFlow.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        var users = new List<object>();
        var userIds = new List<Guid>();
        for (int i = 0; i < 10; i++)
        {
            var userId = Guid.NewGuid();
            userIds.Add(userId);
            users.Add(new
            {
                Id = userId,
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                PhoneNumber = $"0937214443{i}",
                Email = faker.Internet.Email(),
                CreatedOnUtc = DateTime.UtcNow
            });
        }

        const string userSql = """
            INSERT INTO users (id, first_name, last_name, email, phone_number, created_on_utc)
            VALUES (@Id, @FirstName, @LastName, @Email, @PhoneNumber, @CreatedOnUtc);
            """;

        connection.Execute(userSql, users);

        var projects = new List<object>();
        for (int i = 0; i < 100; i++)
        {
            projects.Add(new
            {
                Id = Guid.NewGuid(),
                CreatedByUserId = userIds[faker.Random.Int(0, userIds.Count - 1)],
                Name = faker.Company.CompanyName(),
                Description = "New Project!",
                StartDate = DateOnly.MinValue,
                EndDate = DateOnly.MaxValue,
                EstimatedHours = i + 1,
                PriceAmount = faker.Finance.Amount(1000, 10000),
                PriceCurrency = "USD",
                MaxMemberCount = i * 2,
                CreatedOnUtc = DateTime.UtcNow
            });
        }

        const string projectSql = """
                INSERT INTO projects
                (id, created_by_user_id, name, description, date_range_start_date, date_range_end_date, time_estimate_estimated_hours, price_amount, price_currency, max_member_count, created_on_utc)
                VALUES(@Id, @CreatedByUserId, @Name, @Description, @StartDate, @EndDate, @EstimatedHours, @PriceAmount, @PriceCurrency, @MaxMemberCount, @CreatedOnUtc);
                """;

        connection.Execute(projectSql, projects);
    }
}

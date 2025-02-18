using System.Collections.Generic;
using LanguageLearning.Domain.Entities;

public static class UserMockData
{
    public static List<User> GetUsers() => new List<User>
    {
        new User { Id = 1, Email = "user1@example.com" },
        new User { Id = 2, Email = "user2@example.com" }
    };
}

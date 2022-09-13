using MongoDB.Entities;

namespace MinimalApi.Features.Author.Signup;

public static class Data
{
    internal static Task<bool> EmailAddressIsTaken(string email)
    {
        return DB
            .Find<Entities.Author>()
            .Match(a => a.Email == email)
            .ExecuteAnyAsync();
    }

    internal static Task<bool> UserNameIsTaken(string loweCaseUserName)
    {
        return DB
            .Find<Entities.Author>()
            .Match(a => a.UserName.ToLower() == loweCaseUserName)
            .ExecuteAnyAsync();
    }

    internal static Task CreateNewAuthor(Entities.Author author)
    {
        return author.SaveAsync();
    }
}

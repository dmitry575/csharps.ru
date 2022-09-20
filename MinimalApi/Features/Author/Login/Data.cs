namespace MinimalApi.Features.Author.Login;

public static class Data
{
    internal static Task<Entities.Author> GetAuthor(string userName)
    {
        return DB
            .Find<Entities.Author, Entities.Author>()
            .Match(a => a.UserName == userName)
            .Project(a => new()
            {
                ID = a.ID,
                FirstName = a.FirstName,
                LastName = a.LastName,
                PasswordHash = a.PasswordHash
            })
            .ExecuteSingleAsync();
    }
}

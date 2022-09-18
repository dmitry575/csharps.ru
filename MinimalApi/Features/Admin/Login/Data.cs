public static class Data
{
    internal static Task<(string adminID, string passwordHash)> GetAdmin(string userName)
    {
        return DB
            .Find<Perpission.Admin, (string adminID, string passwordHash)>()
            .Match(a => a.UserName == userName)
            .Project(a => new(a.ID, a.PasswordHash))
            .ExecuteSingleAsync();
    }
}
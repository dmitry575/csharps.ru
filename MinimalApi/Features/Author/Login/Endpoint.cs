using MinimalApi.Auth;

namespace MinimalApi.Features.Author.Login;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/author/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var author = await Data.GetAuthor(r.UserName);

        if (author.PasswordHash is null)
            ThrowError("No author found with that username!");

        if (!BCrypt.Net.BCrypt.Verify(r.Password, author.PasswordHash))
            ThrowError("Password is incorrect!");

        var authorPermissions = new[]
        {
            Permission.ArticleGetOwnList,
            Permission.ArticleSaveOwn,
            Permission.AuthorUpdateOwnProfile,
            Permission.AuthorDeleteOwnArticle
        };

        Response.FullName = author.FirstName + " " + author.LastName;
        Response.UserPermissions = new Permission().NamesFor(authorPermissions);
        Response.Token.ExpiryDate = DateTime.UtcNow.AddHours(4);
        Response.Token.Value = JWTBearer.CreateToken(
            signingKey: Config["JwtSigningKey"],
            expireAt: DateTime.UtcNow.AddHours(4),
            permissions: authorPermissions,
            claims: (Claim.AuthorId, author.ID));

        await SendAsync(Response);
    }
}

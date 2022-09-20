using MinimalApi.Auth;

namespace MinimalApi.Features.Admin.Login;
public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/admin/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var (adminID, passwordHash) = await Data.GetAdmin(r.UserName);

        if (passwordHash is null)
            ThrowError("No admin account by that username!");

        if (!BCrypt.Net.BCrypt.Verify(r.Password, passwordHash))
            ThrowError("Password is incorrect!");

        var adminPemissions = new[]
        {
            Permission.ArticleModerate,
            Permission.ArticleDelete,
            Permission.ArticleGetPendingList,
            Permission.ArticleUpdate,
            Permission.AuthorUpdateProfile
        };

        Response.UserName = r.UserName;
        Response.UserPermissions = new Permission().NamesFor(adminPemissions);
        Response.Token.ExpiryDate = DateTime.UtcNow.AddHours(4);
        Response.Token.Value = JWTBearer.CreateToken(
            signingKey: Config["JwtSigningKey"],
            expireAt: DateTime.UtcNow.AddHours(4),
            permissions: adminPemissions,
            claims: (Claim.AdminId, adminID));

        await SendAsync(Response);
    }
}
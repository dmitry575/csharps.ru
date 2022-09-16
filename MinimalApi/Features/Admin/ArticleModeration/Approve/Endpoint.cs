using MinimalApi.Auth;

namespace MinimalApi.Features.Admin.ArticleModeration.Approve;

public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/admin/article-moderation/approve");
        Claims(Claim.AdminId);
        Permissions(Permission.ArticleModerate);
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        await Data.ApproveArticle(r.ArticleId);
        await SendOkAsync(c);
    }
}

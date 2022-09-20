using MinimalApi.Auth;

namespace MinimalApi.Features.Admin.ArticleModeration.Reject;

public class Endpoint : Endpoint<Reject.Request>
{
    public override void Configure()
    {
        Post("/admin/article-moderation/reject");
        Claims(Claim.AdminId);
        Permissions(Permission.ArticleModerate);
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        await Data.RejectArticle(r.ArticleID, r.RejectionReason);
        await SendOkAsync();
    }
}

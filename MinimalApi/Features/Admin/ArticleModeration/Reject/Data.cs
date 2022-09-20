using MinimalApi.Entities;

namespace MinimalApi.Features.Admin.ArticleModeration.Reject;

public static class Data
{
    internal static Task RejectArticle(string articleId, string reason)
    {
        return DB
            .Update<Article>()
            .MatchID(articleId)
            .Modify(a => a.IsApproved, false)
            .Modify(a => a.RejectionReason, reason)
            .ExecuteAsync();
    }
}
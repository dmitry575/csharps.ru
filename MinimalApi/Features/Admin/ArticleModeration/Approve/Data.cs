using MinimalApi.Entities;

namespace MinimalApi.Features.Admin.ArticleModeration.Approve;

public static class Data
{
    internal static Task ApproveArticle(string articleId)
    {
        return DB
            .Update<Article>()
            .MatchID(articleId)
            .Modify(a => a.IsApproved, true)
            .ExecuteAsync();
    }
}
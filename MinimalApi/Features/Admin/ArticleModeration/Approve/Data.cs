using MinimalApi.Entities;

namespace MinimalApi.Features.Admin.ArticleModeration.Approve;

public  class Data
{
    internal static Task ApproveArticle(string articleID)
    {
        return DB
            .Update<Article>()
            .MatchID(articleID)
            .Modify(a => a.IsApproved, true)
            .ExecuteAsync();
    }
}
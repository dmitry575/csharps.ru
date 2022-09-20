using MinimalApi.Entities;

namespace MinimalApi.Features.Public.AddArticleComment;

public static class Data
{
    internal static Task AddCommentToArticle(string articleId, Article.Comment comment)
    {
        return DB
            .Update<Article>()
            .MatchID(articleId)
            .Modify(b => b.AddToSet(a => a.Comments, comment))
            .ExecuteAsync();
    }
}

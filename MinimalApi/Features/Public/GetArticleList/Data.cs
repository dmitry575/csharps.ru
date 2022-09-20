using MinimalApi.Entities;

namespace MinimalApi.Features.Public.GetArticleList;

public static class Data
{
    internal static Task<List<ArticleModel>> GetRecentArticles()
    {
        return DB
            .Find<Article, ArticleModel>()
            .Match(a => a.IsApproved)
            .Sort(a => a.CreatedOn, Order.Descending)
            .Project(a => new()
            {
                ArticleId = a.ID,
                AuthorName = a.AuthorName,
                CommentCount = a.Comments.Length,
                Title = a.Title,
                CreatedOn = a.CreatedOn
            })
            .ExecuteAsync();
    }
}

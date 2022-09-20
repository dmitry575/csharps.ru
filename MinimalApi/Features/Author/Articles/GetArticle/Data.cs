using MinimalApi.Entities;
using MinimalApi.Features.Author.Articles.GetArticle;

namespace Author.Articles.GetArticle;

public static class Data
{
    internal static Task<Response> GetArticle(string articleId)
    {
        return DB
            .Find<Article, Response>()
            .MatchID(articleId)
            .Project(a => new()
            {
                ArticleId = a.ID,
                Content = a.Content,
                Title = a.Title
            })
            .ExecuteSingleAsync();
    }
}

using MinimalApi.Entities;
using MinimalApi.Features.Public.GetArticle;

namespace Public.GetArticle;

public static class Data
{
    internal static Task<Response> GetArticle(string articleId)
    {
        return DB
            .Find<Article, Response>()
            .MatchID(articleId)
            .Project(a => new()
            {
                ArticleID = a.ID,
                AuthorName = a.AuthorName,
                CommentCount = a.Comments.Length,
                Content = a.Content,
                CreatedOn = a.CreatedOn,
                Title = a.Title
            })
            .ExecuteSingleAsync();
    }
}

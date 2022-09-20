using MinimalApi.Entities;
using MinimalApi.Features.Author.Articles.GetMyArticles;

namespace Author.Articles.GetMyArticles;

public static class Data
{
    internal static Task<List<Response.Article>> GetArticlesForAuthor(string authorId)
    {
        return DB
            .Find<Article, Response.Article>()
            .Match(a => a.AuthorId == authorId)
            .Project(a => new()
            {
                IsApproved = a.IsApproved,
                ArticleId = a.ID,
                RejectionReason = a.RejectionReason,
                Title = a.Title
            })
            .ExecuteAsync();
    }
}

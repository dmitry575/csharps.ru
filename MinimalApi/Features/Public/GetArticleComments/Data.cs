using MinimalApi.Entities;
using Public.GetArticleComments;

namespace MinimalApi.Features.Public.GetArticleComments;

public static class Data
{
    internal static async Task<List<CommentModel>> GetCommentsForArticle(string articleId)
    {
        return DB
            .Queryable<Article>()
            .Where(a => a.ID == articleId)
            .SelectMany(a => a.Comments)
            .Select(c => new CommentModel
            {
                Comment = c.Content,
                PostedOn = c.DateAdded,
                Poster = c.NickName
            })
            .ToList();
    }
}

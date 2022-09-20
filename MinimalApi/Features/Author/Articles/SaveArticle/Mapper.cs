using Author.Articles.SaveArticle;

namespace MinimalApi.Features.Author.Articles.SaveArticle;

public class Mapper : Mapper<Request, Response, Entities.Article>
{
    public override async Task<Entities.Article> ToEntityAsync(Request r)
    {
        return new Entities.Article()
        {
            ID = r.ArticleId,
            AuthorId = r.AuthorId,
            Title = r.Title,
            Content = r.Content,
            AuthorName = await Data.GetAuthorName(r.AuthorId)
        };
    }
}
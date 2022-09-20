using MinimalApi.Auth;
using MinimalApi.Features.Author.Articles.GetArticle;

namespace Author.Articles.GetArticle;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/author/articles/get-article/{ArticleID}");
        Claims(Claim.AuthorId);
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        await SendAsync(await Data.GetArticle(r.ArticleId));
    }
}

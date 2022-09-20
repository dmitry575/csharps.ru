using Author.Articles.GetMyArticles;
using MinimalApi.Auth;

namespace MinimalApi.Features.Author.Articles.GetMyArticles;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/author/articles/get-my-articles");
        Claims(Claim.AuthorId);
        Permissions(Permission.ArticleGetOwnList);
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        Response.Articles = await Data.GetArticlesForAuthor(r.AuthorId);
        await SendAsync(Response);
    }
}
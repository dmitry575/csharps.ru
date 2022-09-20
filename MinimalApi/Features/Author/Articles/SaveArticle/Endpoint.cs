using Author.Articles.SaveArticle;
using MinimalApi.Auth;

namespace MinimalApi.Features.Author.Articles.SaveArticle;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/author/articles/save-article");
        Claims(Claim.AuthorId);
        Permissions(Permission.ArticleSaveOwn);
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        Response.ArticleId = await Data.CreateOrUpdateArticle(
            await Map.ToEntityAsync(r));

        if (Response.ArticleId is null)
            ThrowError("Unable to save the article!");

        await SendAsync(Response);
    }
}
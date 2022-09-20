using MinimalApi.Auth;

namespace MinimalApi.Features.Author.Article.DeleteArticle;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Delete("/author/articles/delete-article/{ArticleID}");
        Claims(Claim.AuthorId);
        Permissions(Permission.AuthorDeleteOwnArticle);
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        if (await Data.DeleteArticle(r.ArticleId, r.AuthorId))
        {
            Response.Message = "Article Deleted!";
            return;
        }

        ThrowError("Article Delete Failed!");
    }
}

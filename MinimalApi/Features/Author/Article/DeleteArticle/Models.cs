namespace MinimalApi.Features.Author.Article.DeleteArticle;

public class Request
{
    public string ArticleId { get; set; }

    [FromClaim]
    public string AuthorId { get; set; }
}

public class Response
{
    public string Message { get; set; }
}

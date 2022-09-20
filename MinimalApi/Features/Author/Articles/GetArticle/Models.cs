namespace MinimalApi.Features.Author.Articles.GetArticle;

public class Request
{
    public string ArticleId { get; set; }
}

public class Response : ArticleModel { }

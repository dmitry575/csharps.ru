using System.Text.Json.Serialization;

namespace MinimalApi.Features.Author.Articles.GetMyArticles;

public class Request
{
    [FromClaim]
    public string AuthorId { get; set; }
}

public class Response
{
    public IEnumerable<Article> Articles { get; set; }

    public class Article
    {
        public string ArticleId { get; set; }
        public string Title { get; set; }
        public string RejectionReason { get; set; }
        public string ApprovalStatus
        {
            get
            {
                if (IsApproved) return "Approved";
                return RejectionReason is null ? "Pending" : "Rejected";
            }
        }

        [JsonIgnore]
        public bool IsApproved { get; set; }

    }
}

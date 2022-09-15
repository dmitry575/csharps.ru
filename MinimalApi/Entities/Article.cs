namespace MinimalApi.Entities;

public class Article : Entity
{
    [ObjectId]
    public string AuthorId { get; set; }

    public string AuthorName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsApproved { get; set; }

    [IgnoreDefault]
    public string RejectionReason { get; set; }

    [IgnoreDefault]
    public Comment[] Comments { get; set; } = Array.Empty<Comment>();

    public class Comment
    {
        [ObjectId]
        public string Id { get; set; }

        public string NickName { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

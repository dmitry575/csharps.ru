using MinimalApi.Entities;
using MongoDB.Bson;
using Public.AddArticleComment;

namespace MinimalApi.Features.Public.AddArticleComment;

public class Mapper : Mapper<Request, object, Article.Comment>
{
    public override Article.Comment ToEntity(Request r) => new()
    {
        Content = r.Comment,
        NickName = r.NickName,
        ID = ObjectId.GenerateNewId().ToString(),
        DateAdded = DateTime.UtcNow
    };
}
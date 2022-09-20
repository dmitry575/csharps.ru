using MinimalApi.Entities;

namespace Author.Articles.SaveArticle;

public static class Data
{
    internal static Task<string> GetAuthorName(string authorId)
    {
        return DB
            .Find<MinimalApi.Entities.Author, string>()
            .MatchID(authorId)
            .Project(a => a.FirstName + " " + a.LastName)
            .ExecuteSingleAsync();
    }

    internal static async Task<string> CreateOrUpdateArticle(Article article)
    {
        if (article.ID is null) //create new article
        {
            article.CreatedOn = DateTime.UtcNow;
            await article.SaveAsync();
        }
        else //update existing article
        {
            var res = await DB
                .Update<Article>()
                .Match(a =>
                       a.ID == article.ID &&
                       a.AuthorId == article.AuthorId)
                .ModifyOnly(
                    members: a => new
                    {
                        a.Title,
                        a.Content
                    },
                    entity: article)
                .ExecuteAsync();

            if (res?.MatchedCount != 1)
                return null;
        }

        return article.ID;
    }
}

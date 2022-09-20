namespace MinimalApi.Features.Author.Articles.DeleteArticle;

public static class Data
{
    internal static async Task<bool> DeleteArticle(string articleId, string authorId)
    {
        return (await DB
            .DeleteAsync<Entities.Article>(a =>
                a.ID == articleId &&
                a.AuthorId == authorId)
            ).DeletedCount > 0;
    }
}

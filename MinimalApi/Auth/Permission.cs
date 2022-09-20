namespace MinimalApi.Auth;

public class Permission: Permissions
{
    public const string Admin = "99";
    
    // Правка для админов
    public const string ArticleModerate = "100";
    public const string ArticleDelete = "101";
    public const string ArticleGetPendingList = "102";
    public const string ArticleUpdate = "103";
    public const string AuthorUpdateProfile = "104";

    // права для авторов
    public const string ArticleGetOwnList = "200";
    public const string ArticleSaveOwn = "201";
    public const string AuthorUpdateOwnProfile = "202";
    public const string AuthorDeleteOwnArticle = "202";
}

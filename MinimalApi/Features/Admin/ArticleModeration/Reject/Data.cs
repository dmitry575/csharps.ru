using System;

public static class Data
{
    internal static Task RejectArticle(string articleID, string reason)
    {
        return DB
            .Update<Article>()
            .MatchID(articleID)
            .Modify(a => a.IsApproved, false)
            .Modify(a => a.RejectionReason, reason)
            .ExecuteAsync();
    }
}
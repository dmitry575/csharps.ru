using MinimalApi.Auth;

namespace MinimalApi.Features.Admin.ArticleModeration.GetPendingList;

public class Endpoint : EndpointWithoutRequest<List<ArticleModel>>
{
	public override void Configure()
	{
		Get("/admin/article-moderation/get-pending-list");
		Claims(Claim.AdminId);
		Permissions(Permission.ArticleGetPendingList);
	}

	public override async Task HandleAsync(CancellationToken ct)
	{
		//instead of using a SendAsync() method, you can simply set the Response property.
		//it's just a shortcut/alternative to SendAsync()

		Response = await Data.GetPendingArticles();
	}
}
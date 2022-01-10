using System.Collections.Generic;
using System.Linq;
using Humble.Umbraco.ContentNodeIcons.Database;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Scoping;

namespace Humble.Umbraco.ContentNodeIcons.Api
{

	public class ContentNodeIconsServiceComposer: IComposer {
		public void Compose(IUmbracoBuilder builder) {
			builder.Services.AddSingleton<IContentNodeIconsService, ContentNodeIconsService>();
		}
	}

	public class ContentNodeIconsService : IContentNodeIconsService
	{
		private readonly IAppPolicyCache _runtimeCache;
		private readonly IScopeProvider _scopeProvider;

		public ContentNodeIconsService(AppCaches appCaches, IScopeProvider scopeProvider)
		{
			_runtimeCache = appCaches.RuntimeCache;
			_scopeProvider = scopeProvider;
		}

		public List<Schema> GetIcons()
		{
			// GetCacheItem will automatically insert the object
			// into cache if it doesn't exist.
			return (List<Schema>) _runtimeCache.Get(Settings.CacheKey, () =>
			{
				using var scope = _scopeProvider.CreateScope(autoComplete: true);
				var database = scope.Database;
				var results = scope.Database.Fetch<Schema>($"SELECT * FROM {Settings.TableName}");
				scope.Complete();
				return results;
			});
		}

		public Schema GetIcon(int id)
		{
			var icons = GetIcons();
			return icons.Where(x => x.ContentId.Equals(id)).FirstOrDefault();
		}

		public Schema SaveIcon(Schema config)
		{
			using (var scope = _scopeProvider.CreateScope(autoComplete: true))
			{
				var database = scope.Database;
				scope.Database.Save<Schema>(config);
				scope.Complete();

				RecycleCache();

				return config;
			}
		}

		public bool RemoveIcon(int id)
		{
			using (var scope = _scopeProvider.CreateScope(autoComplete: true))
			{
				var database = scope.Database;
				scope.Database.Delete<Schema>(id);
				scope.Complete();
				
				RecycleCache();

				return true;
			}
		}

		private void RecycleCache()
		{
			// Clear cache
			_runtimeCache.ClearByKey(Settings.CacheKey);

			// Rebuild cache
			GetIcons();
		}
	}
}
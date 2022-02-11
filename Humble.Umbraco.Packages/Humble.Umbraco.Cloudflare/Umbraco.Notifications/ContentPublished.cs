/*
 * Database -vs- Cache
 * Ref: https://www.enkelmedia.se/blogg/2021/6/11/10-things-every-umbraco-developer-should-know/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Humble.Umbraco.Cloudflare.Umbraco.Notifications
{
	internal class ContentPublished : INotificationAsyncHandler<ContentPublishedNotification>
	{
		private List<Uri> _urls = new List<Uri>();
		private readonly IUmbracoContextFactory _contextFactory;
		private readonly IScopeProvider _scopeProvider;
		private readonly IDomainService _domainService;

		public ContentPublished(IUmbracoContextFactory contextFactory, IScopeProvider scopeProvider, IDomainService domainService)
		{
			_contextFactory = contextFactory;
			_scopeProvider = scopeProvider;
			_domainService = domainService;
		}

		/// <summary>
		/// Handler for the "Content Published" notification in Umbraco v9.
		/// </summary>
		/// <param name="notification"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task HandleAsync(ContentPublishedNotification notification, CancellationToken cancellationToken)
		{
			// Build list of absolute URIs to send to Cloudflare
			using (var scope = _scopeProvider.CreateScope(autoComplete: true))
			{
				using (var ctx = _contextFactory.EnsureUmbracoContext())
				{

					foreach (var node in notification.PublishedEntities)
					{
						var content = ctx.UmbracoContext.Content.GetById(node.Key);
						var relativeUrl = content.Url(null, UrlMode.Relative);
						var domains = _domainService.GetAssignedDomains(content.Root().Id, false);

						if (domains.Any())
						{
							foreach (var domain in domains)
							{
								if(IsFullyQualifiedDomainName(domain.DomainName))
								{
									_urls.Add(new Uri($"{domain.DomainName}{relativeUrl}"));
								}
							}
						}
					}
				}
			}

			// Send to Cloudflare

			return Task.CompletedTask;
		}

		/// <summary>
		/// Helps us filter valid domain names with the protocol defined.
		/// </summary>
		/// <param name="domain"></param>
		/// <returns></returns>
		private bool IsFullyQualifiedDomainName(string domain)
		{
			var uri = new Uri(domain);

			// Check the hostname
			var validHostName = Uri.CheckHostName(uri.Host) != UriHostNameType.Unknown;

			// Check for `http` or `https`
			var scheme = uri.Scheme;
			var validProtocol = scheme.Equals(Uri.UriSchemeHttp) || scheme.Equals(Uri.UriSchemeHttps);

			// Return checks
			return validHostName && validProtocol;
		}

	}
}

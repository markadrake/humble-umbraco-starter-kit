using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble.Umbraco.Cloudflare.Helpers
{
	internal static class Cloudflare
	{

		private readonly static string baseUrl = "https://api.cloudflare.com/client/v4/";

		public static void PurgeAllFiles()
		{
			// Ref: https://api.cloudflare.com/#zone-purge-all-files
			var requestUri = new Uri($"{baseUrl}zones/:identifier/purge_cache");
		}

		public static void PurgeFilesByUrl()
		{
			// Ref: https://api.cloudflare.com/#zone-purge-files-by-url

		}

		public static void PurgeFilesByCacheTags()
		{
			// Ref: https://api.cloudflare.com/#zone-purge-files-by-cache-tags,-host-or-prefix
			throw new NotImplementedException();
		}

		public static void PurgeFilesByHost()
		{
			// Ref: https://api.cloudflare.com/#zone-purge-files-by-cache-tags,-host-or-prefix
			throw new NotImplementedException();
		}

		public static void PurgeFilesByPrefix()
		{
			// Ref: https://api.cloudflare.com/#zone-purge-files-by-cache-tags,-host-or-prefix
			throw new NotImplementedException();
		}
	}
}

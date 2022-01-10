using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humble.Umbraco.ContentNodeIcons.Database;

namespace Humble.Umbraco.ContentNodeIcons.Api
{
	public interface IContentNodeIconsService
	{
		List<Schema> GetIcons();
		Schema GetIcon(int id);
		Schema SaveIcon(Schema config);
		bool RemoveIcon(int id);
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumbleUmbraco.ContentNodeIcons.Database;

namespace HumbleUmbraco.ContentNodeIcons.Api
{
	public interface IContentNodeIconsService
	{
		List<Schema> GetIcons();
		Schema GetIcon(int id);
		Schema SaveIcon(Schema config);
		bool RemoveIcon(int id);
	}
}
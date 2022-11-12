using System;
using Microsoft.Extensions.Logging;
using NPoco;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;
namespace Humble.Umbraco.StructuredData.Database.Migrations;

public class Init : MigrationBase
{
	public Init(IMigrationContext context) : base(context)
	{
	}

	protected override void Migrate()
	{
		Logger.LogDebug("Running migration {MigrationStep}", Constants.TABLE_NAME);

		// Lots of methods available in the MigrationBase class - discover with this.
		if (TableExists(Constants.TABLE_NAME) == false)
		{
			Create.Table<StructuredDataSchema>().Do();
		}
		else
		{
			Logger.LogDebug("The database table {DbTable} already exists, skipping", Constants.TABLE_NAME);
		}
	}

	[TableName(Constants.TABLE_NAME)]
	[PrimaryKey("id", AutoIncrement = true)]
	[ExplicitColumns]
	public class StructuredDataSchema
	{
		[PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1)]
		[Column("id")]
		public int Id { get; set; }

		[Column("umbracoKey")]
		public Guid UmbracoKey { get; set; }

		[Column("userKey")]
		public Guid UserKey { get; set; }

		[Column("data")]
		[SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
		public string Data { get; set; }

		[Column("saved")]
		public DateTime Saved {get; set;}

	}
}

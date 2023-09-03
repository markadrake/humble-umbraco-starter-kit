using Microsoft.Extensions.Logging;
using NPoco;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;
using Umbraco.Cms.Infrastructure.Scoping;
using IScopeProvider = Umbraco.Cms.Infrastructure.Scoping.IScopeProvider;

namespace Humble.Umbraco.ContentNodeIcons.Database;

/*
 * Umbraco Documentation: 
 * https://our.umbraco.com/documentation/extending/database/
 */

public class ContentNodeIconsComposer : ComponentComposer<ContentNodeIconsComponent>, IComposer
{
}

public class ContentNodeIconsComponent : IComponent
{
	private readonly IScopeProvider _scopeProvider;
	private readonly IScopeAccessor _scopeAccessor;
	private readonly IMigrationBuilder _migrationBuilder;
	private readonly IKeyValueService _keyValueService;
	private readonly ILoggerFactory _loggerFactory;
	private readonly IRuntimeState _runtimeState;

	public ContentNodeIconsComponent(IScopeProvider scopeProvider, IScopeAccessor scopeAccessor, IMigrationBuilder migrationBuilder, IKeyValueService keyValueService, ILoggerFactory loggerFactory, IRuntimeState runtimeState)
	{
		_scopeProvider = scopeProvider;
		_scopeAccessor = scopeAccessor;
		_migrationBuilder = migrationBuilder;
		_keyValueService = keyValueService;
		_loggerFactory = loggerFactory;
		_runtimeState = runtimeState;
	}

	public void Initialize()
	{
		if (_runtimeState.Level < RuntimeLevel.Run)
		{
			return;
		}

		// Create a migration plan for a specific project/feature
		// We can then track that latest migration state/step for this project/feature
		var migrationPlan = new MigrationPlan("HumbleUmbraco.ContentNodeIcons");
		var migrationPlanExecutor = new MigrationPlanExecutor(_scopeProvider, _scopeAccessor, _loggerFactory, _migrationBuilder);

		// This is the steps we need to take
		// Each step in the migration adds a unique value
		migrationPlan.From(string.Empty)
			.To<AddContentNodeIconsTable>("contentNodeIcons-db");

		// Go and upgrade our site (Will check if it needs to do the work or not)
		// Based on the current/latest step
		var upgrader = new Upgrader(migrationPlan);
		upgrader.Execute(
			migrationPlanExecutor,
			_scopeProvider,
			_keyValueService);
	}

	public void Terminate()
	{
	}
}

public class AddContentNodeIconsTable : MigrationBase
{
	public AddContentNodeIconsTable(IMigrationContext context) : base(context)
	{
	}

	protected override void Migrate()
	{
		Logger.LogDebug("Running migration {MigrationStep}", "AddHumbleContentNodeIconsTable");

		// Lots of methods available in the MigrationBase class - discover with this.
		if (TableExists(Settings.TableName) == false)
		{
			Create.Table<Schema>().Do();
		}
		else
		{
			Logger.LogDebug("The database table {DbTable} already exists, skipping", "HumbleContentNodeIcons");
		}
	}

}
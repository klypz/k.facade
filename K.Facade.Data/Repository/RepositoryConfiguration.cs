using System;
using System.Data.Common;

namespace K.Facade.Data.Repository
{
	public static class RepositoryConfiguration
	{
		public static Func<DbConnection> GetConnection { get; set; } = null;
	}
}

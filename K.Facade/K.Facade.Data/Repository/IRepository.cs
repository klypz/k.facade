using System.Data.Common;

namespace K.Facade.Data.Repository
{
	public interface IRepository
	{
		DbConnection Connection { get; set; }
		DbTransaction Transaction { get; set; }
	}
}

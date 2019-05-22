using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace K.Facade.Data.Repository
{
	public interface IRepository
	{
		DbConnection Connection { get; set; }
		DbTransaction Transaction { get; set; }
	}
}

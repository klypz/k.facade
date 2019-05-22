using K.Facade.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace K.Facade
{
	public interface IFacadeFactory
	{
		void Map(Action<IFacadeMapper> mapper);
	}
}

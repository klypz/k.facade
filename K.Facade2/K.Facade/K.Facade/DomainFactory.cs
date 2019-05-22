using System;
using System.Collections.Generic;
using System.Text;

namespace K.Facade
{
	internal class DomainFactory : FacadeFactory
	{
		public DomainFactory()
		{
			SetFacadeFactory(new DomainFacade.FacadeFactory());
			SetFacadeMapper(new DomainFacade.FacadeMapper());
			SetLoadMapper(new DomainFacade.FacadeLoadMapper());
			SetConfigurationFileDefault("config.json");
		}
	}
}

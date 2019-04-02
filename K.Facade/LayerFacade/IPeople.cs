using System.Collections.Generic;

namespace LayerFacade
{
    public interface IPeople
    {
        void Salvar(object entity);
        List<object> GetList();
    }
}

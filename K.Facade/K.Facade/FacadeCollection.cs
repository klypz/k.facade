using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace K.Facade
{
    sealed class FacadeCollection : ICollection<FacadeMap>
    {
        private List<FacadeMap> Mapping { get; set; } = new List<FacadeMap>();

        public FacadeMap this[Type self, string target = null]
        {
            get
            {
                return Mapping.FirstOrDefault(p => p.Facade == self && p.Target == target);
            }
        }

        public int Count => Mapping.Count();

        public bool IsReadOnly => false;

        public void Add(FacadeMap item)
        {
            if (!Contains(item))
            {
                Mapping.Add(item);
            }
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(FacadeMap item)
        {
            return Mapping.Any(p => p.Facade == item.Facade && p.Target == item.Target);
        }

        public void CopyTo(FacadeMap[] array, int arrayIndex)
        {
            Mapping.CopyTo(array, arrayIndex);
        }

        public IEnumerator<FacadeMap> GetEnumerator()
        {
            return Mapping.GetEnumerator();
        }

        public bool Remove(FacadeMap item)
        {
            var _item = Mapping.FirstOrDefault(p => p.Facade == item.Facade && item.Target == item.Target);

            if (_item != null)
            {
                Mapping.Remove(_item);
                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Mapping.GetEnumerator();
        }
    }
}

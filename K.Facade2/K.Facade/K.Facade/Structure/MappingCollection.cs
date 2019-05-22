using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace K.Facade.Structure
{
	public sealed class MappingCollection : ICollection<Mapping>
	{
		private readonly List<Mapping> _mappings = new List<Mapping>();

		public int Count => _mappings.Count();

		public bool IsReadOnly => true;

		public void Add(Mapping item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			if (item.Facade == null)
			{
				throw new ArgumentNullException(nameof(item.Facade));
			}

			if (item.Value == null)
			{
				throw new ArgumentNullException(nameof(item.Value));
			}

			if (!_mappings.Any(a=>a.Facade == item.Facade && a.Target == item.Target))
			{
				_mappings.Add(item);
			}
			else
			{
				throw new FacadeException("DUPLICATE_KEY", item.Facade.Name, item.Target);
			}
		}

		public void Clear()
		{
			_mappings.Clear();
		}

		public bool Contains(Mapping item)
		{
			return _mappings.Any(p => p.Facade == item.Facade && p.Target == item.Target);
		}

		public void CopyTo(Mapping[] array, int arrayIndex)
		{
			_mappings.CopyTo(array, arrayIndex);
		}

		public IEnumerator<Mapping> GetEnumerator()
		{
			return _mappings.GetEnumerator();
		}

		public bool Remove(Mapping item)
		{
			return _mappings.Remove(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _mappings.GetEnumerator();
		}

		public Mapping Get(Type facade, string target)
		{
			return _mappings.FirstOrDefault(p => p.Facade == facade && p.Target == target);
		}

		public Mapping Get(Type facade)
		{
			return Get(facade, null);
		}
	}
}

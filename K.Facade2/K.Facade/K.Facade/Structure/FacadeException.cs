using System;
using System.Collections.Generic;
using System.Linq;

namespace K.Facade.Structure
{
	[Serializable]
	public class FacadeException : Exception
	{
		private static readonly List<KeyValuePair<string, string>> MSGS = new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string, string>("DUPLICATE_KEY", "Duplicate keys: {0}"),
			new KeyValuePair<string, string>("FACADE_NOT_FOUND", "Facade not found: {0}"),
			new KeyValuePair<string, string>("MAPPING_COLLECTION_IS_NOT_DEFINED", "Mapping Collection is not defined")
		};
		private string code;
		public string Code { get => code; set => code = value; }

		internal FacadeException(string code) : base(MSGS.First(p => p.Key == code).Value)
		{
			this.code = code;
		}
		internal FacadeException(string code, string facade, string target) : base(string.Format(MSGS.First(p => p.Key == code).Value, $"facade: [{facade}]{(!string.IsNullOrEmpty(target) ? $" - target: [{target}]" : "")}"))
		{
			this.code = code;
		}

		public override string ToString()
		{
			return $"{Code} - {Message}";
		}
	}
}
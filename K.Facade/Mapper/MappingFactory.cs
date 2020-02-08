using System.Linq;
using K.Facade.Abstracts;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;

namespace K.Facade.Mapper
{
	public class MappingFactory : IMappingFactory
	{
		protected IMappingStorage Mapper { get; }
		private string AssembliesField { get; }
		private Type AttributeSearch { get; }

		public MappingFactory(MappingCollection mappings, string assembliesField, Type attributeSearch)
		{
			if (!attributeSearch.IsSubclassOf(typeof(Attribute)) || !attributeSearch.GetInterfaces().Any(a => a == typeof(ISetFacadeAttribute)))
			{
				throw new NotImplementedException($"Not implemented [{typeof(ISetFacadeAttribute).Name}]");
			}

			Mapper = new MappingStore(mappings);
			AssembliesField = assembliesField;
			AttributeSearch = attributeSearch ?? throw new ArgumentNullException(nameof(attributeSearch));
		}
		public void Map(Action<IMappingStorage> map)
		{
			map.Invoke(Mapper);
		}

		public void LoadMapping()
		{
			LoadMapping(FacadeConfiguration.ConfigurationFile);
		}

		public void LoadMapping(string jsonFile)
		{
			if (File.Exists(jsonFile))
			{
				JObject jObject = null;

				using (FileStream f = File.OpenRead(jsonFile))
				{
					using (var sr = new StreamReader(f))
					{
						jObject = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(sr.ReadToEnd());

						if (jObject?["facade"]?["map"]?[AssembliesField].Type != JTokenType.Array)
						{
							return;
						}

						string[] assemblies = ((JArray)jObject?["facade"]?["map"]?[AssembliesField]).Select(s => s.ToString()).ToArray();

						SearchAttributes(assemblies);
					}
				}
			}
		}

		private void SearchAttributes(string[] assemblies)
		{
			foreach (var item in assemblies)
			{
				Assembly assembly = Assembly.Load(item.ToString());
				if (assembly != null)
				{
					var listTypes = assembly.GetTypes().Where(p => p.GetCustomAttributes().Any(a => AttributeSearch == a.GetType())).ToList();
					if (listTypes.Count() > 0)
					{
						Map(cfg =>
						{
							listTypes.ForEach(f =>
							{
								f.GetCustomAttributes(AttributeSearch).ToList().ForEach(a =>
								{
									if (AttributeSearch.GetProperty("Target").GetValue(a) == null)
									{
										cfg.Add((Type)AttributeSearch.GetProperty("Facade").GetValue(a), f);
									}
									else
									{
										cfg.Add((Type)AttributeSearch.GetProperty("Facade").GetValue(a), f, (string)AttributeSearch.GetProperty("Target").GetValue(a));
									}
								});
							});
						});
					}
				}
			}
		}
	}
}

using K.Facade.Auxiliars;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace K.Facade
{
    public sealed class RegisterConfig
    {
        private readonly MappingConfig mapping = new MappingConfig();

        public IFactory Factory => new FactoryBase(mapping);

        public RegisterConfig()
        {

        }

        internal RegisterConfig(MappingConfig mapping)
        {
            this.mapping = mapping;
        }

        public void Config(Action<IMappingConfig> action)
        {
            action.Invoke(mapping);
        }

        public void ConfigAll()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\config.json"))
            {
                ConfigAll(Directory.GetCurrentDirectory() + "\\config.json");
            }
        }

        public void ConfigAll(string jsonfile)
        {
            if (File.Exists(jsonfile))
            {
                JObject jObject = null;

                using (FileStream f = File.OpenRead(jsonfile))
                {
                    using (var sr = new StreamReader(f))
                    {
                        jObject = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(sr.ReadToEnd());
                    }
                }

                if (jObject?["facade"]?["map"]?.Type != JTokenType.Array)
                {
                    return;
                }
                foreach (var item in (JArray)jObject["facade"]["map"])
                {
                    Assembly assembly = Assembly.Load(item.ToString());
                    if (assembly != null)
                    {
                        var listTypes = assembly.GetTypes().Where(p => p.GetCustomAttributes().Any(a => typeof(SetFacadeAttribute) == a.GetType())).ToList();
                        if (listTypes.Count() > 0)
                        {
                            Config(cfg =>
                            {
                                listTypes.ForEach(f =>
                                {
                                    f.GetCustomAttributes<SetFacadeAttribute>().ToList().ForEach(a =>
                                    {
                                        if (a.Target == null)
                                        {
                                            cfg.Register(a.Facade, f);
                                        }
                                        else
                                        {
                                            cfg.Register(a.Facade, a.Target, f);
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
}

using K.Facade.Base;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace K.Facade
{
    /// <summary>
    /// Registra o conjunto de facade
    /// </summary>
    public class RegisterConfig
    {
        protected Type SetFacadeAttribute { get; set; } = typeof(SetFacadeAttribute);
        private readonly IMappingConfig mapping = new MappingConfig();

        protected RegisterConfig(IMappingConfig mappingConfig)
        {
            mapping = mappingConfig;
        }

        public RegisterConfig() { }


        /// <summary>
        /// Factory com base no mapeamento da instância
        /// </summary>
        public IFactory Factory => new FactoryBase(mapping);

        protected string ConfigFileName { get; set; } = "\\config.json";

        /// <summary>
        /// Cria um novo mapeamento para registro de facade local
        /// </summary>

        internal RegisterConfig(MappingConfig mapping)
        {
            this.mapping = mapping;
        }

        /// <summary>
        /// Registra o mapeamento de facade
        /// </summary>
        /// <example>
        /// <code>
        ///     RegisterConfig register = new RegisterConfig();
        ///     register.Config(cfg => {
        ///         a.Register&lt;IFacade, class&gt;();
        ///         a.Register&lt;IFacade, class2&gt;("TARGET");
        ///     });
        ///     
        ///     IFactory fac = register.Facade;
        /// </code>
        /// </example>
        /// <param name="action">Ação de mapeamento de facade</param>
        public void Config(Action<IMappingConfig> action)
        {
            action.Invoke(mapping);
        }

        /// <summary>
        /// <para>Registra o mapeamento de facade com base em um arquivo de configuração</para>
        /// <para>Por padrão o arquivo [config.json] no diretorio de execução da aplicação</para>
        /// </summary>
        /// <example>
        /// <code>
        ///     RegisterConfig register = new RegisterConfig();
        ///     register.ConfigAll();
        ///     IFactory fac = register.Facade;
        /// </code>
        /// </example>
        public void ConfigAll()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + this.ConfigFileName))
            {
                ConfigAll(Directory.GetCurrentDirectory() + this.ConfigFileName);
            }
        }

        /// <summary>
        /// <para>Registra o mapeamento de facade com base em um arquivo de configuração</para>
        /// </summary>
        /// <example>
        /// <code>
        ///     RegisterConfig register = new RegisterConfig();
        ///     register.ConfigAll("c:/diretorio/configFile.json");
        ///     IFactory fac = register.Facade;
        /// </code>
        /// </example>
        /// <param name="jsonfile">Endereço do arquivo de configuração</param>
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

                if (jObject?["facade"]?["data"]?["map"]?.Type != JTokenType.Array)
                {
                    return;
                }
                foreach (var item in (JArray)jObject["facade"]["data"]["map"])
                {
                    Assembly assembly = Assembly.Load(item.ToString());
                    if (assembly != null)
                    {
                        var listTypes = assembly.GetTypes().Where(p => p.GetCustomAttributes().Any(a => SetFacadeAttribute == a.GetType())).ToList();
                        if (listTypes.Count() > 0)
                        {
                            Config(cfg =>
                            {
                                listTypes.ForEach(f =>
                                {
                                    f.GetCustomAttributes(SetFacadeAttribute).ToList().ForEach(a =>
                                    {
                                        if (SetFacadeAttribute.GetProperty("Target").GetValue(a) == null)
                                        {
                                            cfg.Register((Type)SetFacadeAttribute.GetProperty("Facade").GetValue(a), f);
                                        }
                                        else
                                        {
                                            cfg.Register((Type)SetFacadeAttribute.GetProperty("Facade").GetValue(a), (string)SetFacadeAttribute.GetProperty("Target").GetValue(a), f);
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

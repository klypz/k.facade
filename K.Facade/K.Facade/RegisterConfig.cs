using K.Facade.Auxiliars;
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
    public sealed class RegisterConfig
    {
        private readonly MappingConfig mapping = new MappingConfig();

        /// <summary>
        /// Factory com base no mapeamento da instância
        /// </summary>
        public IFactory Factory => new FactoryBase(mapping);

        /// <summary>
        /// Cria um novo mapeamento para registro de facade local
        /// </summary>
        public RegisterConfig()
        {

        }

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
            if (File.Exists(Directory.GetCurrentDirectory() + "\\config.json"))
            {
                ConfigAll(Directory.GetCurrentDirectory() + "\\config.json");
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

namespace K.Facade.Data
{
    public class RepositoryConfig : RegisterConfig
    {
        public RepositoryConfig() : base(new RepositoryMapping())
        {
            ConfigFileName = "\\config.json";
            SetFacadeAttribute = typeof(SetRepositoryAttribute);
        }
    }
}

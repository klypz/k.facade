namespace K.Facade.Data
{
    public class RepositoryConfig : RegisterConfig
    {
        public RepositoryConfig() : base(new RepositoryMapping())
        {
            ConfigFileName = "\\configRepository.json";
            SetFacadeAttribute = typeof(SetRepositoryAttribute);
        }
    }
}

namespace DI_MiddleWare_Configuration.Services
{
    public class TestService:ITestService
    {
        public ITransientUniqueKeyProvider TransientUniquekeyProvider
        {
            get;
            set;
        }
        public IScopedUniqueKeyProvider ScopedUniquekeyProvider
        {
            get;
            set;
        }
        public ISingletonUniqueKeyProvider SingletonUniquekeyProvider
        {
            get;
            set;
        }
        public TestService(ITransientUniqueKeyProvider transientprovider,
            IScopedUniqueKeyProvider scopedprovider,
            ISingletonUniqueKeyProvider singletonprovider)
        {
            TransientUniquekeyProvider = transientprovider;
            ScopedUniquekeyProvider = scopedprovider;
            SingletonUniquekeyProvider = singletonprovider;
        }
    }
}

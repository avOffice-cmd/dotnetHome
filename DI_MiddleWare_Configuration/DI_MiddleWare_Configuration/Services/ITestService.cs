namespace DI_MiddleWare_Configuration.Services
{
    public interface ITestService
    {
        ITransientUniqueKeyProvider TransientUniquekeyProvider
        {
            get;
            set;
        }
        IScopedUniqueKeyProvider ScopedUniquekeyProvider
        {
            get;
            set;
        }
        ISingletonUniqueKeyProvider SingletonUniquekeyProvider
        {
            get;
            set;
        }
    }
}

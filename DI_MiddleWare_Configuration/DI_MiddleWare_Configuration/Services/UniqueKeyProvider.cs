namespace DI_MiddleWare_Configuration.Services
{
    public class UniqueKeyProvider : ITransientUniqueKeyProvider,
        ISingletonUniqueKeyProvider,
        IScopedUniqueKeyProvider
    {
        public Guid UniqueKey
        {
            get;
            set;
        }
        public UniqueKeyProvider(Guid uniqueKey)
        {
            UniqueKey = uniqueKey;
        }
    }
}

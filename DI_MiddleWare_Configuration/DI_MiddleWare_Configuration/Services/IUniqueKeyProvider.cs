namespace DI_MiddleWare_Configuration.Services
{
    public interface IUniqueKeyProvider
    {
        Guid UniqueKey
        {
            get;
            set;
        }
    }
    public interface ITransientUniqueKeyProvider : IUniqueKeyProvider
    { }
    public interface IScopedUniqueKeyProvider : IUniqueKeyProvider
    { }
    public interface ISingletonUniqueKeyProvider : IUniqueKeyProvider
    { }
}

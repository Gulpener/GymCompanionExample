namespace CQRSCore
{
    public interface IQueryHandler<T,X> where T : IQuery
    {
        X Get(T query);
    }
}

namespace CQRSCore
{
    public interface IQueryHandler<T,X>
    {
        X Get(T query);
    }
}

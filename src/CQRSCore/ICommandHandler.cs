namespace CQRSCore
{
    public interface ICommandHandler<T>
    {
        void Execute(T command);
    }
}

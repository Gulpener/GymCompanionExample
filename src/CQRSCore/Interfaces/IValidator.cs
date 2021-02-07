namespace CQRSCore.Interfaces
{
    public interface IValidator<T>
    {
        void Validate(T validatableObject);
    }
}

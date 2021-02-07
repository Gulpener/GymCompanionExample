namespace CQRSCore
{
    public interface IValidator<T>
    {
        void Validate(T validatableObject);
    }
}

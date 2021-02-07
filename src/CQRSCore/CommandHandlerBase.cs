using System;

namespace CQRSCore
{
    public abstract class CommandHandlerBase<T> : ICommandHandler<T> where T: ICommand
    {
        private readonly IValidator<T> _validator;

        public CommandHandlerBase()
        {

        }

        public CommandHandlerBase(IValidator<T> validator)
        {
            _validator = validator;
        }

        public void Execute(T command)
        {
            if (_validator != null) _validator.Validate(command);
            Handle(command);
        }

        public abstract void Handle(T command);
    }
}

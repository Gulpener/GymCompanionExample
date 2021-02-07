using CQRSCore.Interfaces;
using System;

namespace CQRSCore
{
    public abstract class QueryHandlerBase<T, X> : IQueryHandler<T, X> where T: IQuery
    {
        private readonly IValidator<T> _validator;
        public QueryHandlerBase()
        {

        }
        public QueryHandlerBase(IValidator<T> validator)
        {
            _validator = validator;
        }

        public X Execute(T query)
        {
            if (_validator != null) _validator.Validate(query);
            return Handle(query);
        }

        public abstract X Handle(T query);
    }
}

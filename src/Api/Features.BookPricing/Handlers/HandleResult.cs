using System;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Handlers
{
    public abstract class HandleResult
    {
        public static HandleResult Success<T>(T result) => new SuccessHandleResult<T>(result);

        public static HandleResult Success(Guid id) => new SuccessHandleResult(id);

        public static HandleResult NotFound() => new NotFoundHandleResult();
    }

    public sealed class SuccessHandleResult<T> : HandleResult
    {
        public T Result { get; }

        internal SuccessHandleResult(T result) => Result = result;
    }

    public sealed class SuccessHandleResult : HandleResult
    {
        public Guid Id { get; }

        internal SuccessHandleResult(Guid id) => Id = id;
    }

    public sealed class NotFoundHandleResult : HandleResult
    {
    }

    public sealed class BadRequestHandleResult : HandleResult
    {

    }

    public sealed class InternalServerErrorHandleResult : HandleResult
    {

    }
}
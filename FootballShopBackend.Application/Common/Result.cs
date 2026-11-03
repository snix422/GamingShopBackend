namespace FootballShopBackend.Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; protected init; }

        public string? Error { get; protected init; }

        public static Result Success()
        {
            return new Result
            {
                IsSuccess = true
            };
        }

        public static Result Failure(string error)
        {
            return new Result
            {
                IsSuccess = false,
                Error = error
            };
        }
    }

    public sealed class Result<T> : Result
    {
        public T? Data { get; private init; }

        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Data = data
            };
        }

        public new static Result<T> Failure(string error)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Error = error
            };
        }
    }
}

using ArtForAll.Shared.ErrorHandler.Results;

namespace ArtForAll.Shared.ErrorHandler
{
    public class Result<T, E> : IResult<T, E>
        where T : class
        where E : class
    {
        private T value;
        private E error;
        private bool isSuccess;

        public Result(T value, bool isSuccess, E error)
        {
            this.value = value;
            this.isSuccess = isSuccess;
            this.error = error;
        }

        public T Value => this.value;
        public bool IsSucces => this.isSuccess;
        public bool IsFailure => !this.isSuccess;

        public E Error => this.error;

        public static Result<T, E> Success(T value)
        {
            return new Result<T, E>(value, true, null);
        }

        public static Result<T, E> Failure(E error)
        {
            return new Result<T, E>(null, false, error);
        }

        public static implicit operator Result<T, E>(T value)
        {
            return Result<T, E>.Success(value);
        }

        public static implicit operator Result<T, E>(E error)
        {
            return Result<T, E>.Failure(error);
        }
    }
}

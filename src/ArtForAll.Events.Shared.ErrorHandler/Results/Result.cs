namespace ArtForAll.Shared.ErrorHandler
{
    public class Result
    {
        private bool isSuccess;
        private string message;
        private readonly string id;

        public Result(bool isSuccess, string message)
        {
            this.isSuccess = isSuccess;
            this.message = message;
        }

        public Result(bool isSuccess, string message, string id)
            : this(isSuccess, message)
        {
            this.id = id;
        }

        public bool IsSucces => this.isSuccess;
        public bool IsFailure => !this.isSuccess;
        public string Message => this.message;
        public string Id => this.id;

        public static Result Success()
        {
            return new Result(true, string.Empty);
        }

        public static Result Success(string id)
        {
            return new Result(true, string.Empty, id);
        }

        public static Result Failure(string message)
        {
            return new Result(false, message);
        }
    }
}

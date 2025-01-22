namespace ArtForAll.Shared.ErrorHandler.Results;
public interface IValue<out T>
{
    T Value { get; }
}

public interface IError<out E>
{
    E Error { get; }
}

public interface IResult<out T, out E> : IValue<T>, IError<E>
{
}

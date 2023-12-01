namespace QuickLap.Data.Exceptions;

public class NotFoundException<T> : Exception where T : class
{
    public NotFoundException(int id) : base($"Entity {nameof(T)} from ID {id} was not found")
    {
    }
}

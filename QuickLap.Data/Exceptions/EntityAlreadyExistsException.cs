namespace QuickLap.Data.Exceptions;

public class EntityAlreadyExistsException<T> : Exception where T : class
{
    public EntityAlreadyExistsException(object key) : base($"Entity {nameof(T)} from {key} already exists")
    {
    }
}

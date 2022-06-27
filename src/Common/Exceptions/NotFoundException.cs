namespace Jtbuk.VerticalArchitecture.Common.Exceptions;

public abstract class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }

    public CustomError ErrorObject => new(Message);
}


public class NotFoundException<TEntity> : NotFoundException where TEntity : BaseEntity
{
    public NotFoundException(int Id) : base($"{typeof(TEntity).Name} not found with the id {Id}") { }
}

namespace Jtbuk.VerticalArchitecture.Common.Exceptions;

public class NotFoundException<TEntity> : Exception where TEntity : BaseEntity
{
    public NotFoundException(int Id) : base($"{nameof(TEntity)} not found with the id {Id}"){}
}

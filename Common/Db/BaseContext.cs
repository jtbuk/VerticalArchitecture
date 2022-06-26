namespace Jtbuk.VerticalArchitecture.Common.Db;

public abstract class BaseContext : DbContext
{
    protected BaseContext(DbContextOptions options) : base(options) { }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        SetAutomaticFields();

        ValidateEntities();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        SetAutomaticFields();

        ValidateEntities();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void ValidateEntities()
    {
        var changedEntities = ChangeTracker
            .Entries()
            .Where(entities => entities.State is EntityState.Added or EntityState.Modified);

        var errors = new List<ValidationResult>();
        foreach (var changedEntity in changedEntities)
        {
            var validationContext = new ValidationContext(changedEntity.Entity, null, null);
            Validator.TryValidateObject(changedEntity.Entity, validationContext, errors, validateAllProperties: true);
        }

        if (errors.Any())
        {
            var commaSeperatedErrors = string.Join(",", errors.Select(e => e.ErrorMessage ?? "").ToList());
            throw new ValidationException(commaSeperatedErrors);
        }
    }

    private void SetAutomaticFields()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not BaseEntity baseEntity)
            {
                continue;
            }

            if (entry.State == EntityState.Added)
            {
                baseEntity.CreatedDate = DateTime.UtcNow;
            }
        }
    }
}

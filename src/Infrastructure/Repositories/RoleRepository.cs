namespace JMTopUpBackend.Infrastructure.Repositories
{
    public interface IRoleRepository : IBaseRepository
    {
        Task<Role?> GetById(short id, CancellationToken cancellationToken);
        Task<List<Role>> Gets(CancellationToken cancellationToken);
        ValueTask<EntityEntry<Role>> Insert(Role entity, CancellationToken cancellationToken);
        EntityEntry<Role> Update(Role entity);
    }
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(JMTopUpContext context) : base(context) { }

        public Task<Role?> GetById(short id, CancellationToken cancellationToken)
        {
            return context.Roles.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<List<Role>> Gets(CancellationToken cancellationToken)
        {
            return context.Roles.ToListAsync(cancellationToken);
        }

        public ValueTask<EntityEntry<Role>> Insert(Role entity, CancellationToken cancellationToken)
        {
            return context.Roles.AddAsync(entity, cancellationToken);
        }

        public EntityEntry<Role> Update(Role entity)
        {
            return context.Roles.Update(entity);
        }
    }
}
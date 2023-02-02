namespace JMTopUpBackend.Infrastructure.Repositories
{
    public interface IUserProfileRepository : IBaseRepository
    {
        Task<UserProfile?> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<UserProfile>> GetsByUsername(string username, CancellationToken cancellationToken);
        Task<List<UserProfile>> Gets(CancellationToken cancellationToken);
        ValueTask<EntityEntry<UserProfile>> Insert(UserProfile entity, CancellationToken cancellationToken);
        EntityEntry<UserProfile> Update(UserProfile entity);
    }
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(JMTopUpContext context) : base(context) { }
        public Task<UserProfile?> GetById(Guid id, CancellationToken cancellationToken)
        {
            return context.UserProfiles.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
        public Task<List<UserProfile>> GetsByUsername(string username, CancellationToken cancellationToken)
        {
            return context.UserProfiles.Where(p => p.UserName == username).ToListAsync(cancellationToken);
        }
        public Task<List<UserProfile>> Gets(CancellationToken cancellationToken)
        {
            return context.UserProfiles.ToListAsync(cancellationToken);
        }
        public ValueTask<EntityEntry<UserProfile>> Insert(UserProfile entity, CancellationToken cancellationToken)
        {
            return context.UserProfiles.AddAsync(entity, cancellationToken);
        }
        public EntityEntry<UserProfile> Update(UserProfile entity)
        {
            return context.UserProfiles.Update(entity);
        }
    }
}
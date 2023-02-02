
namespace JMTopUpBackend.Infrastructure.Repositories
{
    public interface ICoreRepository : IBaseRepository { }
    public class CoreRepository : BaseRepository, ICoreRepository
    {
        public CoreRepository(JMTopUpContext context) : base(context) { }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
        public virtual Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return context.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
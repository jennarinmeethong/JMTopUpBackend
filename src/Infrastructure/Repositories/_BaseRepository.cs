namespace JMTopUpBackend.Infrastructure.Repositories
{
    public interface IBaseRepository { }
    public abstract class BaseRepository : IBaseRepository
    {
        protected readonly JMTopUpContext context;
        public BaseRepository(JMTopUpContext context)
        {
            this.context = context;
        }
    }
}
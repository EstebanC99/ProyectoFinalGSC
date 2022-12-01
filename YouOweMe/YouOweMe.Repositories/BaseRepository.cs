namespace YouOweMe.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        protected IYouOweMeContext Context { get; set; }

        public BaseRepository(IYouOweMeContext context)
        {
            this.Context = context;
        }
    }
}

using WCFUygulama.DataAccess.Repository;
using WCFUygulama.Data.Database;

namespace WCFUygulama.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected tablolarEntities _context;
        public UnitOfWork(tablolarEntities context)
        {

            if (context == null)
            {
                context = new tablolarEntities();
            }

            _context = context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(_context);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFUygulama.DataAccess.Repository;

namespace WCFUygulama.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected Data.Database.tablolarEntities _context;
        public UnitOfWork(Data.Database.tablolarEntities context)
        {
            if (context==null)
            {
                context = new Data.Database.tablolarEntities();
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

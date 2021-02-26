using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DataAccess.Repository.IRepository<T> GetRepository<T>() where T : class;
        int Complete();
    
    }
}

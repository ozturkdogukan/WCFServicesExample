using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.DataAccess.Repository
{
    public interface IRepository<T> where T: class
    {
        



        void Add(T entity);

        T Get(int userid);

        void Set(T entity);

        void Del(T entity);


    }
}

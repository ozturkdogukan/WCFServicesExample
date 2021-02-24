using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.DataAccess.Repository
{
    public class RepositoryBase<TT> : IRepository<TT> where TT : class
    {
        protected Data.Database.tablolarEntities context;
        // Singleton Pattern : Uygulamanın tek context veya tek connection üzerinden 
        // işlem yapmasının sağlandığı tasarım desenidir.

        public Data.Database.tablolarEntities Context
        {
            get {
                if (context == null)
                {
                    context = new Data.Database.tablolarEntities();
                }
                
                return context; }
            set { context = value; }
        }


        public void Add(TT entity)
        {
            Context.Set<TT>().Add(entity);
            try
            {
                Context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public TT Get(int userid)
        {
            return Context.Set<TT>().Find(userid);
        }

        public void Set(TT entity)
        {
            try
            {
                Context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Del(TT entity)
        {
            Context.Set<TT>().Remove(entity);
            try
            {
                Context.SaveChanges();
                
            }
            catch (Exception)
            {
                throw;
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFUygulama.Data.Database;

namespace WCFUygulama.DataAccess.Repository
{
    public class RepositoryBase<TT> : IRepository<TT> where TT: class
    {
        protected Data.Database.tablolarEntities context;

        public RepositoryBase(tablolarEntities context)
        {
            if (context == null)
            {
                context = new Data.Database.tablolarEntities();
            }
            this.context = context;
        }

        // Singleton Pattern : Uygulamanın tek context veya tek connection üzerinden 
        // işlem yapmasının sağlandığı tasarım desenidir.

        


        public void Add(TT entity) 
        {
            context.Set<TT>().Add(entity);
            try
            {
                context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public TT Get(int userid) 
        {
            return context.Set<TT>().Find(userid);
        }

        public void Set(TT entity) 
        {
            try
            {
                context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Del(TT entity)
        {
            context.Set<TT>().Remove(entity);
            try
            {
                context.SaveChanges();
                
            }
            catch (Exception)
            {
                throw;
                
            }
        }

        public List<projectroles> GetProjectRoles(int projectId)
        {
            var result = context.Set<Data.Database.projectroles>().Where(x => x.projectid == projectId).ToList();
            return result;
        }
    }
}

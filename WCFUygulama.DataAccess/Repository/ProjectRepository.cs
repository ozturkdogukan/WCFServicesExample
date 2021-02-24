using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.DataAccess.Repository
{
    public class ProjectRepository:RepositoryBase<Data.Database.project>,IProjectRepository
    {

        private Data.Database.tablolarEntities _context;
        public ProjectRepository(Data.Database.tablolarEntities context)
        {
           
        }
        


    }
}

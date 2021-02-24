using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFUygulama.Data.Database;

namespace WCFUygulama.DataAccess.Repository
{
    public class ProjectRoleRepository:RepositoryBase<Data.Database.projectroles>,IProjectRoleRepository
    {
        public ProjectRoleRepository(Data.Database.tablolarEntities Context)
        {
            if(context == null)
            {
                context = new tablolarEntities();
            }

        }

        public List<projectroles> GetProjectRoles(int projectId)
        {
            
            var result = context.Set<Data.Database.projectroles>().Where(x => x.projectid == projectId).ToList();
            return result;
        }
    }
}

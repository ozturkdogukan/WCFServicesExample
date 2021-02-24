using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.DataAccess.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        DataAccess.Repository.IUserRepository UserRepository { get; }

        DataAccess.Repository.IProjectRepository ProjectRepository { get; }
        
        DataAccess.Repository.IProjectRoleRepository ProjectRoleRepository { get; }

        int Complete();
    
    }
}

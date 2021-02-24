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
        private Data.Database.tablolarEntities _context;
        public UnitOfWork(Data.Database.tablolarEntities context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            ProjectRepository = new ProjectRepository(_context);
            ProjectRoleRepository = new ProjectRoleRepository(_context);
        }

        public IUserRepository UserRepository { get; private set; }

        public IProjectRepository ProjectRepository { get; private set; }

        public IProjectRoleRepository ProjectRoleRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

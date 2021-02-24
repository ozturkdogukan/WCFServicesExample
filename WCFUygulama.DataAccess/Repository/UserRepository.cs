using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.DataAccess.Repository
{
    public class UserRepository:RepositoryBase<Data.Database.user>,IUserRepository
    {

        public UserRepository(Data.Database.tablolarEntities context)
        {

        }


    }
}

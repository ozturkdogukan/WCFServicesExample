﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.DataAccess.Repository
{
    public interface IProjectRoleRepository:IRepository<Data.Database.projectroles>
    {

        List<Data.Database.projectroles> GetProjectRoles(int projectId);


    }
}

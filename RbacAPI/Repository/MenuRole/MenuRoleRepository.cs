using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MenuRole
{
    public class MenuRoleRepository:BaseRepository<RoleMenu,int>,IMenuRoleRepository
    {
    }
}

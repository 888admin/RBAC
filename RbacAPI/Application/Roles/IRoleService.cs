using Application.Roles.Dto;
using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IRoleService:IBaseService<Role, RoleCreateDto>
    {
        int SavePermission(PermissionDto permission);
        List<RoleCreateDto> RoleShow();
    }
}

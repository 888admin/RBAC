using AutoMapper;
using ClassLibraryEF;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class RoleService : BaseService<Role, RoleCreateDto>, IRoleService
    {
        private readonly IRolerepository repository;

        public RoleService(IRolerepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
        }
    }
}
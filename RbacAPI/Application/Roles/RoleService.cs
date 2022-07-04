using Application.Roles.Dto;
using AutoMapper;
using ClassLibraryEF;
using Repository;
using Repository.MenuRole;
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
        private readonly IMenuRoleRepository menuRoleRepository;
        private readonly IMapper mapper;

        //private readonly IMenuRoleRepository menuRoleRepository;

        public RoleService(IRolerepository repository, IMenuRoleRepository menuRoleRepository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.menuRoleRepository = menuRoleRepository;
            this.mapper = mapper;
        }

        public List<RoleCreateDto> RoleShow()
        {
            var list = mapper.Map<List<RoleCreateDto>>(repository.QueryAll());
            return list;
        }

        public int SavePermission(PermissionDto permission)
        {
            var ids = permission.MenuId.Select(m => new RoleMenu { MenuId = m, RoleId = permission.RoleId }).ToList();

            return menuRoleRepository.AddAll(ids);
        }
    }
}
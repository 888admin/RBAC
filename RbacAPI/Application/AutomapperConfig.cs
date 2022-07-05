using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Menus.Dto;
using Application.Roles.Dto;
using AutoMapper;
using ClassLibraryEF;

namespace Application
{
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<MenuAddDto, Menu>().ReverseMap();
            CreateMap<RoleCreateDto, Role>().ReverseMap();
            CreateMap<AdminDto, Admin>().ReverseMap();
            CreateMap<MenuDto, Menu  >().ReverseMap();
            CreateMap<MenuShowDto, Menu>().ReverseMap();
            CreateMap<MenuRoleDto, RoleMenu>().ReverseMap();
        }
    }
}

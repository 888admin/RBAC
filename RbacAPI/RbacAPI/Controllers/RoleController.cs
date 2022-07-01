using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application;
using ClassLibraryEF;
using Application.Roles.Dto;

namespace RbacAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        public int Create(RoleCreateDto dto)
        {
            return roleService.Create(dto);
        }


        [HttpGet]
        public int Delete(int id)
        {
            return roleService.Delete(id);
        }

        [HttpGet]
        public RoleCreateDto GetBity(int id)
        {
            return roleService.Find(id);
        }

        [HttpPost]
        public int Update(RoleCreateDto dto)
        {
            return roleService.Update(dto);
        }
        [HttpPost]
        public IActionResult SavePermission(PermissionDto permission)
        {
            roleService.SavePermission(permission);
            return Ok();
        }

    }
}

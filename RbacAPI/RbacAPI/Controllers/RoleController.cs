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
        public IActionResult SavePermission(PermissionDto permission)
        {
            roleService.SavePermission(permission);
            return Ok();
        }
        [HttpGet]
        public IActionResult RoleShow()
        {
            var list= roleService.RoleShow();
            return new JsonResult(list);
        }

    }
}

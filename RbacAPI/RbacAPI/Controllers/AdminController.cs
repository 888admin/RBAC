using Application;
using ClassLibraryEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RbacAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService m;

        public AdminController(IAdminService m)
        {
            this.m = m;
        }

        [HttpPost]
        public IActionResult Register(AdminDto dto)
        {
            return Ok(m.Register(dto));
        }

        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            return Ok(m.Login(dto));
        }
    }
}

using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RbacAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController<Tservice,tenity,Tdto> : ControllerBase
        where Tservice : IBaseService<tenity, Tdto>
        where tenity : class, new()
        where Tdto : class, new()
    {
        private readonly Tservice m;

        public BaseController(Tservice m)
        {
            this.m = m;
        }

        [HttpPost]
        public IActionResult Create(Tdto dto)
        {
            return Ok(m.Create(dto));
        }
        [HttpPost]
        public IActionResult Update(Tdto dto)
        {
            return Ok(m.Update(dto));
        }

        [HttpGet]
        public IActionResult Find(int id)
        {
            return Ok(m.Find(id));
        }

        [HttpGet]
        public IActionResult Del(int id)
        {
            return Ok(m.Delete(id));
        }

        [HttpGet]
        public IActionResult Query()
        {
            return new JsonResult(m.Query());
        }
    }
}

using Application;
using Application.Menus.Dto;
using ClassLibraryEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RbacAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpGet]
        public List<MenuDto> QueryAll()
        {
            return menuService.QueryAll();
        }

        [HttpGet]
        public int DelMenu(int id)
        {
            return menuService.DelMenu(id);
        }

        [HttpGet]
        public List<MenuCreateDto> QueryCreateMeun()
        {
            return menuService.QueryCreateMeun();
        }


        [HttpPost]
        public int AddMenu(MenuAddDto menu)
        {
            return menuService.AddMenu(menu);
        }

        [HttpGet]
        public Menu GetBity(int id)
        {
            return menuService.GetBity(id);
        }

        [HttpPost]
        public int MenuUpd(MenuAddDto menu)
        {
            return menuService.MenuUpd(menu);
        }
        [HttpGet]
        [AllowAnonymous]
        public List<MenuShowDto> Show()
        { 
            return menuService.Show();
        }
    }
}

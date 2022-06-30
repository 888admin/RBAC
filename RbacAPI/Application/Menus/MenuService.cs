using System;
using System.Collections.Generic;
using Repository;
using ClassLibraryEF;
using System.Linq;
using AutoMapper;

namespace Application
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository menuRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuRepository"></param>

        public MenuService(IMenuRepository menuRepository,IMapper mapper)
        {
            this.menuRepository = menuRepository;
            this.mapper = mapper;
        }
        public List<MenuDto> QueryAll()
        {
            var list=menuRepository.QueryAll();
            List<MenuDto> menus = new List<MenuDto>();
            var menu = list.Where(t => t.PId == 0).Select(t => new MenuDto
            {
                MenuId = t.MenuId,
                MenuName = t.MenuName,
                MenuLink = t.MenuLink,
            }).ToList();
            NOMenu(menu);
            return menu;
        }

        public void NOMenu(List<MenuDto> menus)
        {
            var list = menuRepository.QueryAll();
            foreach(var item in menus)
            {
                var query = list.Where(t => t.PId == item.MenuId).Select(t => new MenuDto
                {
                    MenuId = t.MenuId,
                    MenuName = t.MenuName,
                    MenuLink = t.MenuLink,
                }).ToList();
                item.children.AddRange(query);
                NOMenu(query);
            }
        }
        public int DelMenu(int id)
        {
            var list= menuRepository.QueryAll();
            var query = list.Where(t => t.MenuId == id).Select(t => new MenuDto
            {
                MenuId = t.MenuId,
                MenuLink = t.MenuLink,
                MenuName = t.MenuName,
                children = list.Where(t => t.PId == id).Select(t => new MenuDto
                {
                    MenuId = t.MenuId,
                    MenuLink = t.MenuLink,
                    MenuName = t.MenuName,
                }).ToList()
            }).FirstOrDefault();
            if (query.children.Count() > 0)
            {
                return 500;
            }
            return menuRepository.Delete(id);
        }

        public List<MenuCreateDto> QueryCreateMeun()
        {
            var list = menuRepository.QueryAll();
            List<MenuCreateDto> menu=list.Where(t=>t.PId==0).Select(t=>new MenuCreateDto
            {
                value=t.MenuId,
                label = t.MenuName,
            }).ToList();
            NoCreateMenu(menu);
            return menu;
        }

        public void NoCreateMenu(List<MenuCreateDto> menuCreate)
        {
            var list=menuRepository.QueryAll();
            foreach (var item in menuCreate)
            {
                var query = list.Where(t => t.PId == item.value).Select(t => new MenuCreateDto
                {
                    value = t.MenuId, 
                    label = t.MenuName,
                }).ToList();
                item.children.AddRange(query);
                NoCreateMenu(query);
            }
            
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int AddMenu(MenuAddDto menu)
        {
            return menuRepository.AddInfo(new Menu
            {
                MenuName = menu.MenuName,
                PId = menu.PId,
                MenuLink = menu.MenuLink,
                CreateId = 0,
                IsDelete=false,
                CreateTime = DateTime.Now,
            });

        }

        public Menu GetBity(int id)
        {
            return menuRepository.GetBity(id);
        }


        public int MenuUpd(MenuAddDto menu)
        {
            return menuRepository.UpdInfo(new Menu
            {
                MenuLink = menu.MenuLink,
                MenuName = menu.MenuName,
                PId = menu.PId,
                IsDelete = false,
                CreateId = 0,
                CreateTime = DateTime.Now,
            });
        }

        public List<MenuDto> Show()
        {
            var list = mapper.Map<List<MenuDto>>(menuRepository.QueryAll());
            return list;
        }
    }
}

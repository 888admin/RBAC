using ClassLibraryEF;
using System.Collections.Generic;

namespace Application
{
    public interface IMenuService
    {
        List<MenuDto> QueryAll();
        int DelMenu(int id);
        List<MenuCreateDto> QueryCreateMeun();
        int AddMenu(MenuAddDto menu);

        Menu GetBity(int id);

        int MenuUpd(MenuAddDto menu);

    }
}
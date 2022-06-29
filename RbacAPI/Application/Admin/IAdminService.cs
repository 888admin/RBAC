using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAdminService : IBaseService<Admin, AdminDto>
    {
        ResultDto Register(AdminDto dto);
        TokenDto Login(LoginDto dto);
        List<Admin> AdminShow();
    }
}

using ClassLibraryEF;
using Repository;

namespace Application
{
    public interface IMenuRoleRepository : IBaseRepository<RoleMenu, int>
    {
    }
}
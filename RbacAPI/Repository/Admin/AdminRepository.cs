using ClassLibraryEF;
namespace Repository
{
    public class AdminRepository : BaseRepository<Admin, int>, IAdminRepository
    {
        public AdminRepository(MyDbContext context)
        {
            this.myDbContext = context;
        }
    }
}

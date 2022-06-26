using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEF;

namespace Repository
{
    public class Rolerepository : BaseRepository<Role, int>, IRolerepository
    {
        public Rolerepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
    }
}

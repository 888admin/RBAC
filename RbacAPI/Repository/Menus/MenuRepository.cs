using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MenuRepository : BaseRepository<Menu, int>, IMenuRepository
    {

        public MenuRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        //public MenuRepository(MyDbContext myDbContext) : base(myDbContext)
        //{
        //    IMenuRepository repository = new MenuRepository(myDbContext);
        //}
    }
}

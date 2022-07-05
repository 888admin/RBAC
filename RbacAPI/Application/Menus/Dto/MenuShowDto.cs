using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Menus.Dto
{
    public class MenuShowDto
    {
        public int MenuId { get; set; }

        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public int PId  { get; set; }
        public virtual bool IsShow { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class RoleCreateDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }
    }
}

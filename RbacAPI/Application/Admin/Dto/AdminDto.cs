using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AdminDto
    {
        public long AdminId { get; set; }

        public string UserName { get; set; }


        public string Password { get; set; }


        public string Email { get; set; }


        public DateTime? LastLoginTime { get; set; }


        public DateTime CreateTime { get; set; }
    }
}

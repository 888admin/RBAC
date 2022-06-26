using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryEF
{
    /// <summary>
    /// 管理员
    /// </summary>
    [Table("Admin")]
    public class Admin:BaseInfo
    {
        [Key]
        public int AdminId { get; set; }
        /// <summary>
        /// 管理员账号
        /// </summary>
        public string UserName { get; set; }
        //管理员密码
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        //最后登录的时间
        public DateTime LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        public Boolean IsLock { get; set; }

    }
}

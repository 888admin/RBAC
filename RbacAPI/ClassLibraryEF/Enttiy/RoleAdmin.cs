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
    /// 管理员角色关系表
    /// </summary>
    [Table("RoleAdmin")]
    public class RoleAdmin
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 角色表
        /// </summary>
        public int RoleId { get; set; } 
        /// <summary>
        /// 管理员表
        /// </summary>
        public int AdmimId { get; set; } 

    }
}

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
    /// 角色菜单关系表
    /// </summary>
    [Table("RoleMeun")]
    public class RoleMenu
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 菜单表
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 角色表
        /// </summary>
        public int RoleId { get; set; }
    }
}

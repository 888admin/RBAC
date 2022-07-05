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
        public int MenuId { get; set; }
        public int RoleId { get; set; }
    }
}

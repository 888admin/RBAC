using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEF
{
    /// <summary>
    /// 通用
    /// </summary>
    public class BaseInfo
    {
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; } 
        public int CreateId { get; set; } 
        public bool IsDelete { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class MenuCreateDto
    {
        public int value { get; set; }

        public string label { get; set; }

        public List<MenuCreateDto> children { get; set; } = new List<MenuCreateDto>();
    }
}

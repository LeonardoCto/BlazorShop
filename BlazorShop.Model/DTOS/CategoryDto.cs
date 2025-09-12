using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Model.DTOS
{
    public class CategoryDto
    {

        public int Id { get; set; } 
        public string Name { get; set; } 
        public string IconCss { get; set; }
    }
}

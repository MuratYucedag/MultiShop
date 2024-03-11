using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.AboutDtos
{
    public class UpdateAboutDto
    {
        public string AboutId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.BrandDtos
{
    public class UpdateBrandDto
    {
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}

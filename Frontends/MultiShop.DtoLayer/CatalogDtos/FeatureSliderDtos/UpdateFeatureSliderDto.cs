using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos
{
    public class UpdateFeatureSliderDto
    {
        public string FeatureSliderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

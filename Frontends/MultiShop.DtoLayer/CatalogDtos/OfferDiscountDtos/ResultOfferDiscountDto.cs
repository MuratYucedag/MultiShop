using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos
{
    public class ResultOfferDiscountDto
    {
        public string OfferDiscountId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonTitle { get; set; }
    }
}

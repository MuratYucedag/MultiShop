using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos
{
    public class GetCargoCustomerByIdDto
    {
        public int cargoCustomerId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string userCustomerId { get; set; }
    }

}
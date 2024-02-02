using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;
        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }
        public void TDelete(int id)
        {
            _cargoCompanyDal.Delete(id);
        }
        public List<CargoCompany> TGetAll()
        {
            return _cargoCompanyDal.GetAll();
        }
        public CargoCompany TGetById(int id)
        {
            return _cargoCompanyDal.GetById(id);
        }
        public void TInsert(CargoCompany entity)
        {
            _cargoCompanyDal.Insert(entity);
        }
        public void TUpdate(CargoCompany entity)
        {
           _cargoCompanyDal.Update(entity);
        }
    }
}

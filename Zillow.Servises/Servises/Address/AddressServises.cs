using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;
using Zillow.Data;

namespace Zillow.Servises.Servises.Address
{
     public class AddressServises: IAddressServises
    {
        private ApplicationDbContext _DB;

        public AddressServises(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public List<AddressVM> GetAll()
        {
            var address = _DB.Addresses.Select(x => new AddressVM()
            {
                CityName = x.CityName,
                CountryName = x.CountryName,
            }).ToList();
            return address;
        }
        public void Create( CreateAddressDTO dto)
        {
            var address = new Zillow.Data.Models.Address();
            address.CityName = dto.CityName;
            address.CountryName = dto.CountryName;
            _DB.Addresses.Add(address);
            _DB.SaveChanges();
        }
        public void Update(UpdateAddressDTO dto)
        {
         var address=   _DB.Addresses.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            address.CountryName = dto.CountryName;
            address.CityName = dto.CityName;
            _DB.Addresses.Update(address);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {
           
            var deleteAddress = _DB.Addresses.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            deleteAddress.IsDelete = true;
            _DB.Addresses.Update(deleteAddress);
            _DB.SaveChanges();
        }
    }
}

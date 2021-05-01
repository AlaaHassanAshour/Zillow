using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;
using Zillow.Data;

namespace Zillow.Servises.Servises.Customer
{
   public class CustomerServises: ICustomerServises
    {
        private ApplicationDbContext _DB;

        public CustomerServises(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public List<CustomerVM> GetAll()
        {
            var customer = _DB.Customer.Select(x => new CustomerVM() {
                Name = x.Name,
              
                Phone = x.Phone,
            }).ToList();
            return customer;
        }
        public void Create(CreateCustomerDTO dto)
        {
            var customer = new Zillow.Data.Models.Customer()
            {
                Name = dto.Name,
                Phone = dto.Phone,
                AddressId=dto.AddressId
             };
            _DB.Customer.Add(customer);
            _DB.SaveChanges();

        }
        public void Update(UpdateCustomerDTO dto)
        {
            var customer = _DB.Customer.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            customer.AddressId = dto.AddressId;
            customer.Name = dto.Name;
            customer.Phone= dto.Phone;
            _DB.Customer.Update(customer);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {
            var deletedCustomer = _DB.Customer.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            deletedCustomer.IsDelete = true;
            _DB.Customer.Update(deletedCustomer);
            _DB.SaveChanges();
        }

    }
}

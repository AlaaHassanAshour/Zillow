using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;

namespace Zillow.Servises.Servises.Customer
{
  public interface ICustomerServises
    {
        public List<CustomerVM> GetAll();
        public void Create(CreateCustomerDTO addcustomerDTO);
        public void Delete(int id);
        public void Update(UpdateCustomerDTO dto);

    }
}

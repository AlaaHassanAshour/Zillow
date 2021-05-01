using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;

namespace Zillow.Servises.Servises.Address
{
   public interface IAddressServises
    {
        public List<AddressVM> GetAll();
        public void Create(CreateAddressDTO dto);
        public void Delete(int id);
        public void Update(UpdateAddressDTO dto);
    }
}

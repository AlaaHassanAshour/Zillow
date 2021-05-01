using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;

namespace Zillow.Servises.Servises.Contract
{
   public interface IContractServies
    {
        public List<ContractVM> GetAll();
        public void Create(CreateContractDTO dto);
        public void Update(UpdateContractDTO dto);
        public void Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;

namespace Zillow.Servises.Servises.RealEstate
{
    public interface IRealEstateServises
    {
       public PagingViewModel GetAll(int page);
        public Task Create(CreateRealEstateDTO dto);
        public void Update(UpdateRealEstateDTO dto);
        public void Delete(int id);
    }
}

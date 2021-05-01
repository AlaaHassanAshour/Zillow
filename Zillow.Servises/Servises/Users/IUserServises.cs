using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;

namespace Zillow.Servises.Servises.Users
{
   public interface IUserServises
    {
        List<UserVM> GetAll();
        Task<bool> Create(CraeteUserDTO dto);
        Task Update(UpdateUserDTO dto);
        void Delete(string id);



    }
}

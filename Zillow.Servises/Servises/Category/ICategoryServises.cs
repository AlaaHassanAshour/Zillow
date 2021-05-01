using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;

namespace Zillow.Servises.Servises.Category
 {
   public interface ICategoryServises
    {
        public List<CategoryVM> GetAll();
        public void Create(CreateCategoryDTO dto);
        public void Update(UpdateCategoryDTO dto);
        public void Delete(int id);
        }
}

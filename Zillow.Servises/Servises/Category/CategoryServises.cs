using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;
using Zillow.Data;

namespace Zillow.Servises.Servises.Category
{
     public  class CategoryServises: ICategoryServises
    {
        private ApplicationDbContext _DB;

        public CategoryServises(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public List<CategoryVM> GetAll()
        {
            var category = _DB.Categorys.Select(x => new CategoryVM()
            {
                Decrption = x.Decrption,
                Name = x.Name,
            }).ToList();
            return category;     
        }
        public void Create(CreateCategoryDTO dto)
        {
            var category = new Zillow.Data.Models.Category()
            {
                Decrption=dto.Decrption,
                Name=dto.Name,
                
            };
            _DB.Categorys.Add(category);
            _DB.SaveChanges();
        }
        public void Update(UpdateCategoryDTO dto) {
            var category = _DB.Categorys.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            category.Name = dto.Name;
            category.Decrption = dto.Decrption;
            _DB.Categorys.Update(category);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {

            var deletecategory = _DB.Categorys.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            deletecategory.IsDelete = true;
            _DB.Categorys.Update(deletecategory);
            _DB.SaveChanges();
        }
    }
}

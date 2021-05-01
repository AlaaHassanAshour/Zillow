using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;
using Zillow.Data;

namespace Zillow.Servises.Servises.Contract
{
    public class ContractServies: IContractServies
    {
        private ApplicationDbContext _DB;
        public ContractServies(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public List<ContractVM> GetAll()
        {
            var contract = _DB.Contracts.Include(x => x.RealEstate).Include(x => x.Customer).Select(x => new ContractVM()
            {
                Price = x.Price,
                Type = x.Type,
               Customer=new CustomerVM()
               {
                   Id=x.Customer.Id,
                   Name=x.Customer.Name,
                   Phone=x.Customer.Phone,
               },
               RealEstate=new RealEstateVM()
               {
                   Name=x.RealEstate.Name,
                   Decrption=x.RealEstate.Decrption,
               }
            }).ToList();
            return contract;
        }
        public void Create(CreateContractDTO dto)
        {
            var conract = new Zillow.Data.Models.Contract();
            conract.Price = dto.Price;
            conract.Type= dto.Type;
            conract.CustomerId= dto.CustomerId;
            conract.RealEstateId= dto.RealEstateId;
            _DB.Contracts.Add(conract);
            _DB.SaveChanges();
        }
        public void Update(UpdateContractDTO dto ) {
            var conract = _DB.Contracts.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            conract.Price = dto.Price;
            conract.Type = dto.Type;
            conract.RealEstateId = dto.RealEstateId;
            conract.CustomerId = dto.CustomerId;
            _DB.Contracts.Update(conract);
            _DB.SaveChanges();

        }
        public void Delete(int id)
        {
            var conract = _DB.Contracts.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            conract.IsDelete = true;
            _DB.Contracts.Update(conract);
            _DB.SaveChanges();
        }
    }
}
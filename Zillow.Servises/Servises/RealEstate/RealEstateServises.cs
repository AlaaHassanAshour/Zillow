using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;
using Zillow.Data;
using Zillow.Servises.Servises.File;

namespace Zillow.Servises.Servises.RealEstate
{
    public class RealEstateServises : IRealEstateServises
    {
        private ApplicationDbContext _DB;
        private IFileServises _IFileServises;
        public RealEstateServises(ApplicationDbContext DB, IFileServises IFileServises)
        {
            _DB = DB;
            _IFileServises = IFileServises;
        }
        public PagingViewModel GetAll(int page)
        {
            var pagse = Math.Ceiling(_DB.RealEstates.Count() / 10.0);
            if (page < 1 || pagse > page)
            {
                page = 1;
            }
            var Skip = (page - 1) * 10;

            var realEstate = _DB.RealEstates.Include(x => x.Address).Include(x => x.Category)
                .Include(x => x.Contracts).Include(x => x.Imeges).Select(x => new RealEstateVM()
                {
                    Decrption = x.Decrption,
                    Name = x.Name,
                    Category = new CategoryVM()
                    {
                        Id = x.Id,
                        Decrption = x.Decrption,
                        Name = x.Name,
                    },
                    Address = new AddressVM()
                    {
                        Id = x.Address.Id,
                        CityName = x.Address.CityName,
                        CountryName = x.Address.CountryName,
                    },
                    Imeges = x.Imeges.Select(x => new ImegeVM()
                    {
                        Id = x.Id,
                        ImegPath = x.ImegPath
                    }).ToList(),
                    Imege = x.Imeges.Select(x => x.ImegPath).ToList()
                    ,
                    Contracts = x.Contracts.Select(x => new ContractVM()
                    {
                        Id = x.Id,
                        Price = x.Price,
                        Type = x.Type
                    }).ToList()
                }).Skip(Skip).Take(10).ToList();
            var paginResalt = new PagingViewModel();
            paginResalt.Data = realEstate;
            paginResalt.CuraentPage = (int)pagse;
            paginResalt.NummberOfBage = page;
            return paginResalt;
        }
        public async Task Create(CreateRealEstateDTO dto)
        {
            var realEstate = new Zillow.Data.Models.RealEstate();
            realEstate.AddressId = dto.AddressId;
            realEstate.CategoryId = dto.CategoryId;
            realEstate.Decrption = dto.Decrption;
            realEstate.Name = dto.Name;
            _DB.RealEstates.Add(realEstate);
            _DB.SaveChanges();

            foreach (var item in dto.Imeges)
            {
                var imegName = await _IFileServises.SaveFile(item, "Images");
                var imeg = new Zillow.Data.Models.Imege();
                imeg.RealEstateId = realEstate.Id;
                imeg.ImegPath = imegName;
                _DB.Imeges.Add(imeg);

            }
            _DB.SaveChanges();
        }
        public void Update(UpdateRealEstateDTO dto)
        {
            var realEstate = _DB.RealEstates.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            realEstate.Decrption = dto.Decrption;
            realEstate.Name = dto.Name;
            realEstate.CategoryId = dto.CategoryId;
            realEstate.AddressId = dto.AddressId;
            _DB.RealEstates.Update(realEstate);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {
            var realEstate = _DB.RealEstates.SingleOrDefault(x => x.Id == id);
            realEstate.IsDelete = true;
            _DB.RealEstates.Update(realEstate);
            _DB.SaveChanges();
        }
    }
}


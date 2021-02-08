using Newtonsoft.Json;
using Prodyna.Models.Domain;
using Prodyna.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prodyna.Business
{
    public class ProdynaService : IProdynaService
    {
        private ProdynaModel _dbContext = new ProdynaModel();

        private bool StoreJson(List<Models.Domain.Vesti> vesti)
        {
            string json = JsonConvert.SerializeObject(vesti.ToArray());
            var path = AppDomain.CurrentDomain.BaseDirectory + @"Export\vesti.json";

            try
            {
                System.IO.File.WriteAllText($"{path}", json);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public bool AddVest(Models.Domain.Vesti vest)
        {

            var newVest = new Models.EF.Vesti()
            {
                Description = vest.Description,
                CreatedTimeStamp = vest.CreatedTimeStamp,
                Category = vest.Category,
                Author = vest.Author,
                Name = vest.Name
            };

            _dbContext.Vesti.Add(newVest);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding Vest failed, Details: {ex.Message}, StackTrace: {ex.StackTrace}");
            }

            var refresh = GetAllVesti();

            StoreJson(refresh);

            return true;

        }

        public List<Models.Domain.Vesti> GetAllVesti()
        {


            var res = _dbContext.Vesti.Select(x => new Models.Domain.Vesti()
            {
                Author = x.Author,
                Category = x.Category,
                CreatedTimeStamp = x.CreatedTimeStamp,
                Description = x.Description,
                Id = x.Id,
                Name = x.Name
            });

            var result = res.ToList();


            return result;
        }

        public Models.Domain.Vesti GetVest(int id)
        {
            var res = _dbContext.Vesti.Where(x=>x.Id == id).Select(x => new Models.Domain.Vesti()
            {
                Author = x.Author,
                Category = x.Category,
                CreatedTimeStamp = x.CreatedTimeStamp,
                Description = x.Description,
                Id = x.Id,
                Name = x.Name
            });

            var result = res.FirstOrDefault();

            return result;
        }

        public bool UpdateVest(Models.Domain.Vesti vestUpdate)
        {
            var vestFromDb = _dbContext.Vesti.Where(x=> x.Id == vestUpdate.Id).FirstOrDefault();

            if(vestFromDb == null)
            {
                throw new Exception($"Updating Vest failed, FAKE NEWS");
            }

            vestFromDb.Description = vestUpdate.Description;
            vestFromDb.Category = vestUpdate.Category;
            vestFromDb.Author = vestUpdate.Author;
            vestFromDb.Name = vestUpdate.Name;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Updating Vest failed, Details: {ex.Message}, StackTrace: {ex.StackTrace}");
            }

            return true;
        }
    }
}

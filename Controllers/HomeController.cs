using Prodyna.Business;
using Prodyna.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodyna.Controllers
{
    public class HomeController : Controller
    {
        IProdynaService prodynaService = new ProdynaService();

        public ActionResult Index()
        {
            var res = prodynaService.GetAllVesti();

           
            
            var indexViewModel = new SveVestiViewModel();

            foreach (var item in res)
            {
                indexViewModel.SveVesti.Add(new VestiViewModel()
                {
                    Name = item.Name,
                    Id = item.Id,
                    Description = item.Description,
                    Author = item.Author,
                    Category = item.Category,
                    FormatTimeStamp = "News published at: " + item.CreatedTimeStamp.Value.Year + "-" + item.CreatedTimeStamp.Value.Month + "-" + item.CreatedTimeStamp.Value.Day + "-" + item.CreatedTimeStamp.Value.Hour + "-" + item.CreatedTimeStamp.Value.Minute + "-" + item.CreatedTimeStamp.Value.Second
                });
            }

            return View(indexViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult SubmitForm(VestiViewModel vestiViewModel)
        {
            var vest = new Models.Domain.Vesti()
            {
                Author = vestiViewModel.Author,
                Name = vestiViewModel.Name,
                Id = vestiViewModel.Id,
                Category = vestiViewModel.Category, 
                Description = vestiViewModel.Description
            };


            if(vestiViewModel.Id != 0)
            {
                var res = prodynaService.UpdateVest(vest);
            }
            else
            {
                vest.CreatedTimeStamp = DateTime.Now;

                var res = prodynaService.AddVest(vest);
            }

            var resAfterUpdate = prodynaService.GetAllVesti();

            var indexViewModel = new SveVestiViewModel();

            foreach (var item in resAfterUpdate)
            {
                indexViewModel.SveVesti.Add(new VestiViewModel()
                {
                    Name = item.Name,
                    Id = item.Id,
                    Description = item.Description,
                    Author = item.Author,
                    Category = item.Category,
                    FormatTimeStamp = "News published at: " + item.CreatedTimeStamp.Value.Year + "-" + item.CreatedTimeStamp.Value.Month + "-" + item.CreatedTimeStamp.Value.Day + "-" + item.CreatedTimeStamp.Value.Hour + "-" + item.CreatedTimeStamp.Value.Minute + "-" + item.CreatedTimeStamp.Value.Second

                });
            }

            return View("~/Views/Home/index.cshtml", indexViewModel);
        }


        public ActionResult AddNews()
        {
            var newVm = new VestiViewModel()
            {
            };

            return View(newVm);
        }

        public ActionResult UpdateNews(string Id)
        {
            var res = prodynaService.GetVest(Convert.ToInt32(Id));

            var newVm = new VestiViewModel()
            {
                Name = res.Name,
                Id = res.Id,
                Description = res.Description,
                Author = res.Author,
                Category = res.Category,
                FormatTimeStamp = "News published at: " + res.CreatedTimeStamp.Value.Year + "-" + res.CreatedTimeStamp.Value.Month + "-" + res.CreatedTimeStamp.Value.Day + "-" + res.CreatedTimeStamp.Value.Hour + "-" + res.CreatedTimeStamp.Value.Minute + "-" + res.CreatedTimeStamp.Value.Second
               
            };

            return View(newVm);
        }
    }
}
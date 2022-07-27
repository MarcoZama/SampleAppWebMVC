using Microsoft.AspNetCore.Mvc;
using SampleAppWeb.Uow;
using SampleAppWeb.Uow.Models;
using System.Text.Json;

namespace SampleAppWeb.Controllers
{
    public class TouristController : Controller
    {
        protected readonly ITouristRepository _touristRepository;



        public TouristController(ITouristRepository touristRepository)
        {
            _touristRepository = touristRepository;
        }

        public async Task<IActionResult> Index()
        {  
            var tourists = await _touristRepository.Get();
            return View(tourists);
        }



        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetById(int touristID)
        {
            var newTourist = await _touristRepository.GetById(touristID);
            return View(newTourist);
        }



         
        public async Task<ActionResult> Create()
        {
            Random r = new Random();
            int genRand = r.Next(1000000, 10000000);
            var tourist = new TouristAddRequest()
            {
                TouristEmail = $"test-{genRand.ToString()}@gmail.com",
                TouristLocation = "Milan",
                TouristName = "Marco"
            };
            var newTourist = await _touristRepository.Insert(tourist);
            return View(newTourist);
        }


        public async Task<ActionResult> Edit()
        {
            Random r = new Random();
            int genRand = r.Next(1000000, 10000000);
            int updateRandom = r.Next(1, 10000);
            var tourist = new TouristEditRequest()
            {
                Id = updateRandom,
                TouristEmail = $"test-{genRand.ToString()}@gmail.com",
                TouristLocation = "Milan",
                TouristName = "Marco"
            };
            var newTourist = await _touristRepository.Update(tourist);
            return View(newTourist);
        }

  
        public async Task<ActionResult> Delete(int touristID)
        {
            Random r = new Random();
            
            int deleteRandom = r.Next(1, 10000);
            var newTourist = await _touristRepository.Delete(deleteRandom);
            return View(newTourist);
        }

    }
}

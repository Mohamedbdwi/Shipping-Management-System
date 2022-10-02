using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shipping_Project.Models;
using Shipping_Project.Repository.Weight;

namespace Shipping_Project.Controllers
{
    [Authorize(Roles = "SuperAdmin, Employee")]
    public class WeightController : Controller
    {
        private readonly IWeight weight;

        public WeightController(IWeight weight)
        {
            this.weight = weight;
        }
        public IActionResult Index()
        {
            Weights weightModel = weight.GetWeight();
            return View(weightModel);
        }


        public IActionResult Edit()
        {

            Weights weightModel = weight.GetWeight();

            return View(weightModel);
        }


        
        [HttpPost]
        public IActionResult SaveEdit(Weights newWeight)
        {
            if (ModelState.IsValid)
            {
                
                weight.Update(newWeight);
                return RedirectToAction("Index","Dashboard");

            }
            
            return View("Edit", newWeight);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SG.Distributeur.Automatique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SG.Distributeur.Automatique.Controllers
{
    public class RecetteController : Controller
    {
        // GET: RecetteController
        public ActionResult Index()
        {
            return View(distributeurAutomatique.recettes);
        }

        // GET: RecetteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        
        [HttpPost]
        public ActionResult GetPrix(IFormCollection formcollection)
        {
             var prix = distributeurAutomatique.recettes.First(x => x.Id == int.Parse(formcollection["Id"])).GetPrix();
            TempData["Message"] = prix.ToString()+" euros";

            return RedirectToAction("Index");
        }
        
    }
}

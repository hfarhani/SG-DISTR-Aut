using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SG.Distributeur.Automatique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SG.Distributeur.Automatique.Controllers
{

    public class ProduitController : Controller
    {
        // GET: ProduitController
        public ActionResult Index()
        {

             return View(distributeurAutomatique.produits);
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                distributeurAutomatique.produits.Add(new ProduitPrix() { Nom = collection["Nom"], Prix = double.Parse(collection["Prix"]) });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}

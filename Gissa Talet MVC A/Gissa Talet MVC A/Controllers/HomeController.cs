﻿using Gissa_Talet_MVC_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gissa_Talet_MVC_A.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            var model = GetListToSession();            
            return View(model);
        }        
        // GET: SessionTimeout
        public ActionResult SessionTimeout() // skickar användaren vidare till nästa sida ifall dom tar för långt tid på sig, default 20min
        {
            return View();
        }
        // GET: NewPage
        public ActionResult NewPage() // Rensar sidan och slumpar nytt hemligt nummer
        {
            GetListToSession().Initialize();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? number) // POST metod för att kolla ifall gissningen ligger inom tillåtna värden innan det skickas in till klassen
        {
            if (Session.IsNewSession)
            {
                return View("SessionTimeout");
            }

            var model = GetListToSession();

            if (!number.HasValue)
            {
                ModelState.AddModelError("number", "Du måste ange ett heltal!");
            }
            else if (number < 1 || number > 100)
            {
                ModelState.AddModelError("number", "Gissningen misslyckades, rätta till felet och försök igen.");
                ModelState.AddModelError("number", "Talet måste vara mellan 1 och 100");
            }
            else
            {
                model.MakeGuess(number.Value);
            }
            return View(model);
        }

        private SecretNumber GetListToSession() // skapar en ref objekt av ett Session Objekt till att lagra gissningar
        {
            var guessList = Session["savedList"] as SecretNumber;

            if (guessList == null)
            {
                guessList = new SecretNumber();
                Session["savedList"] = guessList;
            }
            return guessList;
        }


    }
}
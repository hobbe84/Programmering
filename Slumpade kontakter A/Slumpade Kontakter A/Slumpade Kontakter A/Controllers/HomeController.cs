using Slumpade_Kontakter_A.Models;
using Slumpade_Kontakter_A.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Slumpade_Kontakter_A.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        
        // Konstruktor
        public HomeController()
            : this(new XmlRepository())
        {
        }

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        
        // GET: Home
        public ActionResult Index()
        {            
            return View(_repository.GetContact());
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Email, Date")]Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddContact(contact);
                    _repository.Save();

                    TempData["success"] = string.Format("{0} {1} sparades",contact.FirstName, contact.LastName);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["error"] = string.Format("Misslyckades att spara {0} {1}. Försök igen!",contact.FirstName,contact.LastName);
            }
            return View(contact);
        }
        // GET: Edit Contact
        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);                
            }
            var contact = _repository.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        // POST: Edit Contact
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_POST(Guid id)
        {
            var contactUpdate = _repository.GetContact(id);

            if (contactUpdate == null)
            {
                return HttpNotFound();
            }
            if (TryUpdateModel(contactUpdate, string.Empty, new string[] {"FirstName", "LastName", "Email"}))
            {
                try
                {
                    _repository.EditContact(contactUpdate);
                    _repository.Save();
                    TempData["success"] = string.Format("{0} {1} ändrades",contactUpdate.FirstName, contactUpdate.LastName);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["error"] = "Misslyckades spara ändringarna. Försök igen!";
                }                
            }
            return View(contactUpdate);
        }
        // GET: Delete Guid/id
        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _repository.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        //POST: Delete / Guid/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var contactDelete = new Contact { Id = id };
                _repository.DeleteContact(contactDelete);
                _repository.Save();
                TempData["success"] = string.Format("Kontakten togs bort");
            }
            catch (Exception)
            {
                TempData["error"] = "Misslyckades att ta bort kontakten. Försök igen!";
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("Index");
        }
        
    }
}
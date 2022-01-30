using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppInPreparazione.Helpers;
using WebAppInPreparazione.Models.Entities;
using WebAppInPreparazione.Models.Views;

namespace WebAppInPreparazione.Controllers
{
    public class DipendentiController : Controller
    {
        // GET: Dipendenti
        public ActionResult Index()
        {
            var model = DatabaseHelper.GetAllDipendenti();
            return View(model);
        }

        // GET: Dipendenti/Details/5
        public ActionResult Details(int id)
        {
            var model = DatabaseHelper.GetDipendenteById(id);
            return View(model);
        }

        // GET: Dipendenti/Create
        public ActionResult Create()
        {
            var model = new DipendenteViewModel();
            model.ListaAziende = DatabaseHelper.GetAllAzienda();
            return View(model);
        }

        // POST: Dipendenti/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dipendente model)
        {
            try
            {
                if(!ModelState.IsValid || model.IdAzienda < 1)
                {
                    var msgKo = "Completa tutti i campi<br>";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    var msgKoAggregate = errors.Select(t => t.ErrorMessage).Aggregate((x, y) => $"{x}<br>{y}");
                    ViewData["MsgKo"] = msgKo + msgKoAggregate;
                    var viewModel = new DipendenteViewModel(model, DatabaseHelper.GetAllAzienda());
                    return View(viewModel);
                }
                DatabaseHelper.SaveDipendente(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["MsgKo"] = "Errore nell'inserimento";
                var viewModel = new DipendenteViewModel(model, DatabaseHelper.GetAllAzienda());
                return View();
            }
        }

        // GET: Dipendenti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dipendenti/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dipendenti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dipendenti/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

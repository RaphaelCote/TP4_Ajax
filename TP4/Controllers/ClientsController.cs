using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

using TP4.Data;
using TP4.Models;
using TP4.ViewModels;

namespace TP4.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public List<SelectListItem> ListeAbonnements;
        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {

            return View(GetClientsVM());
        }

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            foreach (Abonnement a in _context.Abonnements)
            {
                ListeAbonnements.Add(new SelectListItem()
                {
                    Value = a.AbonnementId.ToString(),
                    Text = a.Type,

                });
            }
            ClientCreateVM client = new()
            {
                ListesAbonnement = ListeAbonnements
            };
            return PartialView("_CreatePartial", client);
        }

        // POST: ClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreateVM nouveauClient)
        {
            if (ModelState.IsValid)
            {
                Client clientACreer = new();
            }
            return PartialView("_ClientsListePartial");
        }

        // GET: ClientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientsController/Edit/5
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            _context.Clients.Remove(_context.Clients.FirstOrDefault(c => c.ClientId == id));

            return PartialView("_ClientsListPartial", GetClientsVM());
        }

        public List<ClientsIndexVM> GetClientsVM()
        {
            List<Client> Clients = _context.Clients.Include("Abonnement").ToList();

            List<ClientsIndexVM> ClientsVM = new List<ClientsIndexVM>();

            foreach (Client c in Clients)
            {
                ClientsVM.Add(new ClientsIndexVM()
                {
                    ClientId = c.ClientId,
                    Nom = c.Nom,
                    Age = c.Age,
                    Courriel = c.Courriel,
                    NoTelephone = c.NoTelephone,
                    TypeAbonnement = c.Abonnement.Type
                });
            }

            return ClientsVM;
        }
    }
}

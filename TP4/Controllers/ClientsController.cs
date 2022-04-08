using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public ActionResult Create()
        {
            ListeAbonnements = new();
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
        public ActionResult Create([FromBody] ClientCreateVM nouveauClient)
        {
            if (ModelState.IsValid)
            {
                Client clientACreer = new()
                {
                    ClientId = 0,
                    Nom = nouveauClient.Nom,
                    Age = Int32.Parse(nouveauClient.Age),
                    NoTelephone = nouveauClient.NumeroTelephone,
                    Courriel = nouveauClient.Courriel,
                    AbonnementId = (int)nouveauClient.TypeAbonnementId
                };

                _context.Clients.Add(clientACreer);
                _context.SaveChanges();

                return PartialView("_ClientsListPartial", GetClientsVM());
            }

            ListeAbonnements = new();
            foreach (Abonnement a in _context.Abonnements)
            {
                ListeAbonnements.Add(new SelectListItem()
                {
                    Value = a.AbonnementId.ToString(),
                    Text = a.Type,

                });
            }
            nouveauClient.TypeAbonnementId = nouveauClient.TypeAbonnementId;
            nouveauClient.ListesAbonnement = ListeAbonnements;
            Response.StatusCode = 400;
            return PartialView("_CreatePartial", nouveauClient);
        }

        [HttpPost]
        [Route("{controller}/{action}/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            _context.Clients.Remove(_context.Clients.FirstOrDefault(c => c.ClientId == id));
            _context.SaveChanges();

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

            ClientsVM.Reverse();

            return ClientsVM;
        }
    }
}

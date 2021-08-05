using AutoMapper;
using Engie_Test.Entitites;
using Engie_Test.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Engie_Test.Controllers
{
    public class PowerPlantController : Controller
    {

        private readonly Data.MainDbContext _context;
        private readonly IMapper _mapper;
        // GET: PowerPlantController


        public PowerPlantController(Data.MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string powerPlantUC, int? providerId, bool? enabled, int? page)
        {
            ViewBag.powerPlantUC = ViewBag.providerId = ViewBag.enabled = null;

            ViewBag.ProvidersList = await _context.Providers.ToListAsync();            

            IQueryable<PowerPlant> query = _context.PowerPlants.AsQueryable();           

            if (!String.IsNullOrEmpty(powerPlantUC))
            {
                ViewBag.powerPlantUC = powerPlantUC;
                query = query.Where(powerPlant => powerPlant.PowerPlantUC.Contains(powerPlantUC));
            }

            if (providerId.HasValue)
            {
                ViewBag.providerId = providerId;
                query = query.Where(powerPlant => powerPlant.ProviderId == providerId);
            }

            if (enabled.HasValue)
            {
                ViewBag.enabled = enabled;
                query = query.Where(powerPlant => powerPlant.Enabled == enabled.Value);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);           

            var pagedList = await query.ToPagedListAsync(pageNumber, pageSize);

            return  View(pagedList);
        }       

        // GET: PowerPlantController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var powerPlant = await _context.PowerPlants.FindAsync(id);

            var powerPlantViewModel = _mapper.Map<PowerPlantViewModels>(powerPlant);

            return View(powerPlantViewModel);
        }

        // GET: PowerPlantController/Create
        public async  Task<IActionResult> Create()
        {          

            ViewBag.ProvidersList = await _context.Providers.ToListAsync();
            return View();
        }

        // POST: PowerPlantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(PowerPlantViewModels powerPlantViewModels)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  var powerPlant =  _mapper.Map<PowerPlant>(powerPlantViewModels);

                 var insert =  _context.Add(powerPlant);

                   await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
               
            }
            catch
            {
                ModelState.AddModelError("", @"Não foi possível inserir os dados.");
            }
            return View();
        }

        // GET: PowerPlantController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var powerPlant = await _context.PowerPlants.FindAsync(id);
            ViewBag.ProvidersList = await _context.Providers.ToListAsync();

            var powerPlantViewModel = _mapper.Map<PowerPlantViewModels>(powerPlant);       
            


            return View(powerPlantViewModel);
        }

        // POST: PowerPlantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PowerPlantViewModels powerPlantViewModels)
        {
            try
            {
                var powerPlant = _mapper.Map<PowerPlant>(powerPlantViewModels);

                _context.PowerPlants.Update(powerPlant);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PowerPlantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PowerPlantController/Delete/5
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

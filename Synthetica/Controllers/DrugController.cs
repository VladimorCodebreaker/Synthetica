using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Synthetica.Data.IServices;
using Synthetica.Data.Static;
using Synthetica.Models;
using Synthetica.Data.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Synthetica.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class DrugController : Controller
    {
        private readonly IDrugService _service;

        public DrugController(IDrugService service)
        {
            _service = service;
        }

        // GET: /<Index>/
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var drugs = await _service.GetAllAsync(d => d.Pharmacy);

            return View(drugs);
        }

        // Get: /<Search>/
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allDrugs = await _service.GetAllAsync(p => p.Pharmacy);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allDrugs.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allDrugs);
        }

        // GET: /<Details>/
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var drug = await _service.GetDrugByIdAsync(id);

            return View(drug);
        }

        // GET: /<Create>/
        public async Task<IActionResult> Create()
        {
            var drugInfo = await _service.GetNewDrugsDropdownsValues();

            ViewBag.Pharmacies = new SelectList(drugInfo.Pharmacies, "Id", "Name");
            ViewBag.Producers = new SelectList(drugInfo.Producers, "Id", "Name");
            ViewBag.Substances = new SelectList(drugInfo.Substances, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DrugVM drug)
        {
            if (!ModelState.IsValid)
            {
                var drugInfo = await _service.GetNewDrugsDropdownsValues();

                ViewBag.Pharmacies = new SelectList(drugInfo.Pharmacies, "Id", "Name");
                ViewBag.Producers = new SelectList(drugInfo.Producers, "Id", "Name");
                ViewBag.Substances = new SelectList(drugInfo.Substances, "Id", "Name");

                return View(drug);
            }

            await _service.AddNewDrugAsync(drug);
            return RedirectToAction(nameof(Index));
        }

        // GET: /<Edit>/
        public async Task<IActionResult> Edit(int id)
        {
            var drugInfo = await _service.GetDrugByIdAsync(id);

            if (drugInfo == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            var response = new DrugVM()
            {
                Id = drugInfo.Id,
                Image = drugInfo.Image,
                Name = drugInfo.Name,
                Description = drugInfo.Description,
                Price = drugInfo.Price,
                DrugCategory = drugInfo.DrugCategory,
                PharmacyId = drugInfo.PharmacyId,
                ProducerId = drugInfo.ProducerId,
                SubstanceIds = drugInfo.Substance_Drugs.Select(n => n.SubstanceId).ToList(),
            };

            var drugDropdownsData = await _service.GetNewDrugsDropdownsValues();
            ViewBag.Pharmacies = new SelectList(drugDropdownsData.Pharmacies, "Id", "Name");
            ViewBag.Producers = new SelectList(drugDropdownsData.Producers, "Id", "Name");
            ViewBag.Substances = new SelectList(drugDropdownsData.Substances, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DrugVM drug)
        {
            if (id != drug.Id)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            if (!ModelState.IsValid)
            {
                var drugDropdownsData = await _service.GetNewDrugsDropdownsValues();

                ViewBag.Pharmacies = new SelectList(drugDropdownsData.Pharmacies, "Id", "Name");
                ViewBag.Producers = new SelectList(drugDropdownsData.Producers, "Id", "Name");
                ViewBag.Substances = new SelectList(drugDropdownsData.Substances, "Id", "Name");

                return View(drug);
            }

            await _service.UpdateDrugAsync(drug);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


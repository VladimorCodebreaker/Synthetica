using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Synthetica.Data.IServices;
using Synthetica.Data.Static;
using Synthetica.Models;
using System.Numerics;
using Synthetica.Data.ViewModels;

namespace Synthetica.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class SubstanceController : Controller
    {
        private readonly ISubstanceService _service;

        public SubstanceController(ISubstanceService service)
        {
            _service = service;
        }

        // GET: /<Index>/
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var substances = await _service.GetAllAsync();

            return View(substances);
        }

        // GET: /<Create>/
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubstanceVM substance)
        {
            if (!ModelState.IsValid)
            {
                return View(substance);
            }

            await _service.AddNewSubstanceAsync(substance);

            return RedirectToAction(nameof(Index));
        }

        // GET: /<Details>/
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var substance = await _service.GetByIdAsync(id);

            if (substance == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(substance);
        }

        // GET: /<Edit>/
        public async Task<IActionResult> Edit(int id)
        {
            var substance = await _service.GetByIdAsync(id);

            if (substance == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(substance);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,SubstanceVM substance)
        {
            if (!ModelState.IsValid)
            {
                return View(substance);
            }

            await _service.UpdateSubstanceAsync(substance);

            return RedirectToAction(nameof(Index));
        }

        // GET: /<Delete>/
        public async Task<IActionResult> Delete(int id)
        {
            var substance = await _service.GetByIdAsync(id);

            if (substance == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(substance);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var substance = await _service.GetByIdAsync(id);

            if (substance == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}


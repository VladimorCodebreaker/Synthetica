using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Synthetica.Data.Static;
using Synthetica.Data.IServices;
using Synthetica.Models;
using Synthetica.Data.ViewModels;

namespace Synthetica.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PharmacyController : Controller
    {
        private readonly IPharmacyService _service;

        public PharmacyController(IPharmacyService service)
        {
            _service = service;
        }

        // GET: /<Index>/
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var pharmacies = await _service.GetAllAsync();

            return View(pharmacies);
        }

        // GET: /<Create>/
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PharmacyVM pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return View(pharmacy);
            }

            await _service.AddNewPharmacyAsync(pharmacy);

            return RedirectToAction(nameof(Index));
        }

        // GET: /<Details>/
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var pharmacy = await _service.GetByIdAsync(id);

            if (pharmacy == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(pharmacy);
        }

        // GET: /<Edit>/
        public async Task<IActionResult> Edit(int id)
        {
            var pharmacy = await _service.GetByIdAsync(id);

            if (pharmacy == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(pharmacy);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PharmacyVM pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return View(pharmacy);
            }

            await _service.UpdatePharmacyAsync(pharmacy);

            return RedirectToAction(nameof(Index));
        }

        // GET: /<Delete>/
        public async Task<IActionResult> Delete(int id)
        {
            var pharmacy = await _service.GetByIdAsync(id);

            if (pharmacy == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(pharmacy);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmacy = await _service.GetByIdAsync(id);

            if (pharmacy == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}


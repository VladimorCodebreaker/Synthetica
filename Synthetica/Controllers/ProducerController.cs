using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Synthetica.Models;
using Synthetica.Data.IServices;
using Synthetica.Data.Static;
using Synthetica.Data.ViewModels;

namespace Synthetica.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducerController : Controller
    {
        private readonly IProducerService _service;

        public ProducerController(IProducerService service)
        {
            _service = service;
        }

        // GET: /<Index>/
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var producers = await _service.GetAllAsync();

            return View(producers);
        }

        // GET: /<Details>/
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producer = await _service.GetByIdAsync(id);

            if (producer == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(producer);
        }

        // GET: /<Create>/
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProducerVM producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.AddNewProducerAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        // GET: /<Edit>/
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _service.GetByIdAsync(id);

            if (producer == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(producer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProducerVM producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            if (id == producer.Id)
            {
                await _service.UpdateProducerAsync(producer);

                return RedirectToAction(nameof(Index));
            }

            return View(producer);
        }

        // GET: /<Delete>/
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _service.GetByIdAsync(id);

            if (producer == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(producer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producer = await _service.GetByIdAsync(id);

            if (producer == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}


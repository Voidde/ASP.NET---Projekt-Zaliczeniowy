using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projekt.Models;

namespace Projekt.Controllers
{

    [Authorize(Roles = "Admin")]
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;
        public PlaceController(AppDbContext context,IPlaceService placeService)
        {
            _placeService = placeService;
        }
        [Authorize(Roles = "Admin")]
        // GET: PlaceController
        public IActionResult Index()
        {
            return View(_placeService.FindAll());
        }

        [Authorize(Roles = "Admin")]
        // GET: PlaceController/Details/5
        public IActionResult Details(int? id)
        {
            var place = _placeService.FindBy(id);
            return place is null ? NotFound() : View(place);
        }
        [Authorize(Roles = "Admin")]
        // GET: PlaceController/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: PlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PlaceId,PlaceName,City,PostalCode,Address,AddressNr,PlaceDescription")] Place place)
        {
            if (ModelState.IsValid)
            {
                _placeService.Save(place);
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }
        [Authorize(Roles = "Admin")]
        // GET: PlaceController/Edit/5
        public IActionResult Edit(int? id)
        {
            var place = _placeService.FindBy(id);
            return place is null ? NotFound() : View(place);
        }
        [Authorize(Roles = "Admin")]
        // POST: PlaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PlaceName,City,PostalCode,Address,AddressNr,PlaceDescription")] Place place)
        {
            if (ModelState.IsValid)
            {
                _placeService.Update(place);
                return RedirectToAction(nameof(Index));
            }
            return View(place); 
        }
        [Authorize(Roles = "Admin")]
        // GET: PlaceController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var place = _placeService.FindBy(id);
            return place is null ? NotFound() : View(place);
        }
        [Authorize(Roles = "Admin")]
        // POST: PlaceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfrimed(int id)
        {
            if (_placeService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("This Place does not exist,can't delete");
        }

    }
}

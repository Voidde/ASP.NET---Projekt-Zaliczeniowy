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
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;
        public ArtistController(AppDbContext context,IArtistService artistService)
        {
            _artistService = artistService;
        }
        [Authorize(Roles = "Admin")]
        // GET: ArtistController
        public IActionResult Index()
        {
           return View(_artistService.FindAll());
        }
        [Authorize(Roles = "Admin")]
        // GET: ArtistController/Details/5
        public IActionResult Details(int? id)
        {
            var artist = _artistService.FindBy(id);
            return artist is null ? NotFound() : View(artist);
        }
        [Authorize(Roles = "Admin")]
        // GET: ArtistController/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: ArtistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ArtistId,Name,Surname,Nickname")]Artist artist)
        {
            if (ModelState.IsValid)
            {
                _artistService.Save(artist);
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            var artist = _artistService.FindBy(id);
            return artist is null ? NotFound() : View(artist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit([Bind("ArtistId,Name,Surname,Nickname")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _artistService.Update(artist);
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        [Authorize(Roles = "Admin")]
        // GET: ArtistController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var artist = _artistService.FindBy(id);
            return artist is null ? NotFound() : View(artist);
        }

        [Authorize(Roles = "Admin")]
        // POST: ArtistController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (_artistService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("This Artist does not exist, can't delete.");
        }

    }
}

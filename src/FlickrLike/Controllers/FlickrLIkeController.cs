using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FlickrLike.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace FlickrLike.Controllers
{
    [Authorize]
    public class FlickrLikeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FlickrLikeController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        //GET FlickrLike/Index
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View(_db.Images
                .Where(image => image.User.Id == userId)
                .ToList());
        }

        //GET FlickrLike/Create
        public IActionResult Create()
        {
            return View();
        }
        //POST FlickrLike/Create
        [HttpPost]
        public async Task<IActionResult> Create(string Name, IFormFile picture)
        {
            byte[] photoArray = new byte[0];
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            if (picture.Length > 0)
            {
                using (var fileStream = picture.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    photoArray = ms.ToArray();
                }
            }
            Image newImage = new Image(Name, photoArray, currentUser);
            _db.Images.Add(newImage);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET FlickrLike/Edit
        public IActionResult Edit(int id)
        {
            Image thisImage = _db.Images.FirstOrDefault(im => im.Id == id);
            return View(thisImage);
        }
        [HttpPost]
        public IActionResult Edit(Image image, IFormFile picture)
        {
            byte[] photoArray = new byte[0];

            if (picture.Length > 0)
            {
                using (var fileStream = picture.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    photoArray = ms.ToArray();
                }
            }
            image.Photo = photoArray;
            _db.Entry(image).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FlickrLike.Models;
using Microsoft.AspNetCore.Identity;

namespace FlickrLike.Controllers
{
    public class FlickrLikeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FlickrLikeController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        //GET /Index
        public IActionResult Index()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlickrLike.Controllers;
using FlickrLike.Models;
using Xunit;
using Microsoft.AspNetCore.Identity;

namespace FlickrLike.Tests.ControllerTests
{
    public class ImageControllerTest
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        [Fact]
        public void Get_ViewResult_Create_Test()
        {
            //Arrange
            FlickrLikeController controller = new FlickrLikeController(_userManager, _db);

            //Act
            var result = controller.Create();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ModelList_Index_Test()
        {
            //Arrange
            FlickrLikeController controller = new FlickrLikeController(_userManager, _db);
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<Image>>(result);

        }
    }
}

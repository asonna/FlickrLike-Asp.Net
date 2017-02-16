using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlickrLike.Models;
using Xunit;

namespace FlickrLike.Tests
{
    public class ImageTest
    {
        [Fact]
        public void GetNameTest()
        {
            //Arrange
            var image = new Image();
            image.Name = "Marshmallow Cat";

            //Act
            var result = image.Name;

            //Assert
            Assert.Equal("Marshmallow Cat", result);
        }
    }
}

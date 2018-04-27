using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using comp2007w2018finalB.Controllers;
using Moq;
using comp2007w2018finalB.Models;
using System.Linq;
using System.Web.Mvc;

namespace comp2007w2018finalB.Tests.Controllers
{
    [TestClass]
    public class BreweriesControllerTest
    {
        BreweriesController controller;
        Mock<IMockBreweryRepository> mock;
        List<Brewery> breweries;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockBreweryRepository>();

            breweries = new List<Brewery>
            {
                new Brewery { BreweryId = 1, Name = "One", City = "Barrie", Url = "http://one.ca", Logo = "one.gif" },
                new Brewery { BreweryId = 2, Name = "Two", City = "Barrie", Url = "http://two.ca", Logo = "two.gif" },
                new Brewery { BreweryId = 2, Name = "Three", City = "Barrie", Url = "http://three.ca", Logo = "three.gif" }
            };

            mock.Setup(m => m.Breweries).Returns(breweries.AsQueryable());

            controller = new BreweriesController(mock.Object);
        }

        [TestMethod]

        public void IndexViewLoads()
        {


            //act
            var actual = controller.Index();

            // assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]

        public void IndexValidLoadsBreweries()
        {


            var actual = (List<Brewery>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(breweries, actual);
        }

        // Create
        [TestMethod]

        public void CreateViewLoads()
        {


            var actual = (ViewResult)controller.Create();

            // assert
            Assert.AreEqual("Create", actual.ViewName);
        }

        // Create Valid
        [TestMethod]

        public void CreateValid()
        {
            // arrange
             Brewery a= new Brewery
            {

                Name = "New Brewery"

            };

            // act
            var actual = (RedirectToRouteResult)controller.Create(a);

            //assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);

        }

        // Create Invalid
        [TestMethod]

        public void CreateInvalid()
        {
            // arrange
            Brewery a = new Brewery
            {

                Name = "New breweries"

            };

            controller.ModelState.AddModelError("key", "create error");

            // act
            var actual = (ViewResult)controller.Create(a);

            //assert
            Assert.AreEqual("Create", actual.ViewName);

        }


    }

}

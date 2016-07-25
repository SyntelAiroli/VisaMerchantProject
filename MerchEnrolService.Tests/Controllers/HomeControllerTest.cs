using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchEnrolServiceWebUI;
using MerchEnrolServiceWebUI.Controllers;
using MerchEnrolServiceWebUI.Models;

namespace MerchEnrolService.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        Merchant merchant1 = null;
        Merchant merchant2 = null;

        List<Merchant> merchants = null;

        

        MerchantController controller = new MerchantController();

        [TestMethod]
        public void Details()
        {
            ViewResult result = controller.Details(1) as ViewResult;
           // Assert.AreEqual(result.Model,)
                }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

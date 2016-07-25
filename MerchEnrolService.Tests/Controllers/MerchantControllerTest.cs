using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchEnrolServiceWebUI.Models;
using MerchEnrolServiceWebUI.Controllers;
using System.Web.Mvc;
using System.Runtime.InteropServices;

namespace MerchEnrolService.Tests.Controllers
{
    /// <summary>
    /// Summary description for MerchantControllerTest
    /// </summary>
    [TestClass]
    public class MerchantControllerTest
    {

        Merchant lstMerchant1 = null;
        Merchant lstMerchant2 = null;
        List<Merchant> merchants = null;

        public MerchantControllerTest()
        {
            lstMerchant1 = new Merchant
            {
                Id = 4,
                MerchantName = "Bank-E",
                AddedBy = "Joe bloggs",
                Country = "Englend",
                MerchantProfit = 10000,
                DateAdded = "01/01/2016",
                NoOfOutlets = 15
            };

            lstMerchant2 = new Merchant
            {
                Id = 3,
                MerchantName = "Member-A",
                AddedBy = "Ray Brando",
                Country = "Italy",
                MerchantProfit = 243789,
                DateAdded = "11/01/2016",
                NoOfOutlets = 1300
            };

            merchants = new List<Merchant>
            {
                lstMerchant1,
                lstMerchant2
            };

        }
   
        MerchantRepository lstMerchantRepository = new MerchantRepository();
        private FileLogger errLog = new FileLogger();
        [TestMethod]
        public void Details()
        {
            try
            {
                using (MerchantController controller = new MerchantController())
                {
                    ViewResult result = controller.Details(10) as ViewResult;
                    Assert.AreEqual(result.Model, lstMerchant1);
                }
            }
            catch (Exception ex )
            {

                errLog.Handle(ex.Message.ToString());
            }
        }

        [TestMethod]
        public void Create()
        {
            try
            {
                Merchant lstNewMerchant = new Merchant
                {
                    Id = 6,
                    MerchantName = "Bank-A",
                    AddedBy = "George Mason",
                    Country = "USA",
                    MerchantProfit = 500000,
                    DateAdded = "12/02/2016",
                    NoOfOutlets = 20000
                };
                using (MerchantController controller = new MerchantController())
                {
                    controller.Create(lstNewMerchant);
                    List<Merchant> lstMerchants = lstMerchantRepository.GetAllMerchants(lstNewMerchant);
                    CollectionAssert.Contains(lstMerchants, lstNewMerchant);
                }
            }

            catch (Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
            }
        }

        [TestMethod]
        public void Edit()
        {
            try
            {
                Merchant lstEditMerchant = new Merchant
                {
                    Id = 6,
                    MerchantName = "Bank-A",
                    AddedBy = "George Mason",
                    Country = "USA",
                    MerchantProfit = 500000,
                    DateAdded = "12/02/2016",
                    NoOfOutlets = 20000
                };
                using (MerchantController controller = new MerchantController())
                {
                    controller.Edit(lstEditMerchant.Id, lstEditMerchant);
                    List<Merchant> lstMerchants = lstMerchantRepository.GetAllMerchants(lstEditMerchant);
                    CollectionAssert.Contains(lstMerchants, lstEditMerchant);
                }
            }

            catch (Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
            }

        }

        [TestMethod]
        public void Delete()
        {
            try
            {
                Merchant lstDeleteMerchant = new Merchant
                {
                    Id = 9,
                    MerchantName = "Bank-A",
                    AddedBy = "George Mason",
                    Country = "USA",
                    MerchantProfit = 500000,
                    DateAdded = "12/02/2016",
                    NoOfOutlets = 20000
                };
                using (MerchantController controller = new MerchantController())
                {
                    controller.Delete(lstDeleteMerchant.Id, lstDeleteMerchant);
                    List<Merchant> lstMerchants = lstMerchantRepository.GetAllMerchants(lstDeleteMerchant);
                    CollectionAssert.DoesNotContain(lstMerchants, lstDeleteMerchant);
                }
            }

            catch (Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
            }
        }

    }
}

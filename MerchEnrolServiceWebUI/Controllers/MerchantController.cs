using MerchEnrolServiceWebUI.Enum;
using MerchEnrolServiceWebUI.Models;
using System;
using System.Web.Mvc;
using System.Net;
using MerchEnrolServiceWebUI.Interfaces;

namespace MerchEnrolServiceWebUI.Controllers
{
    public class MerchantController : Controller
    {
        private IMerchantRepository lstMerchRepository; 
        public MerchantController()
        {
            this.lstMerchRepository = new MerchantRepository();
        }
        Merchant lstMerchant = new Merchant();
        private FileLogger errLog = new FileLogger();

        public ActionResult Index(string searchBy, string search)
        {
            try
            {
                lstMerchant.TextSearch = search;
                lstMerchant.MerchantSearchBy = searchBy == null ? (SearchBy)System.Enum.Parse(typeof(SearchBy), "Name", true) : (SearchBy)System.Enum.Parse(typeof(SearchBy), searchBy, true);
                return View(lstMerchRepository.GetAllMerchants(lstMerchant));
            }
            catch (Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
                return View("Error");
            }

        }


        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                lstMerchant = lstMerchRepository.GetMerchantById(Convert.ToInt32(id));
                if (lstMerchant == null)
                    return HttpNotFound();
                return View(lstMerchant);
            }
            catch (Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
                return View("Error");
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Merchant merchant)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (lstMerchRepository.AddMerchant(merchant) > 0)
                    {
                        ViewBag.Duplicate = "Merchant name " + merchant.MerchantName + " already exist in our system.";
                    }
                    else
                    {
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View(merchant);
            }
            catch (Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
                return View("Error");
            }
        }


        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                lstMerchant = lstMerchRepository.GetMerchantById(Convert.ToInt32(id));
                if (lstMerchant == null)
                    return HttpNotFound();
                return View(lstMerchant);
            }
            catch (Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
                return View("Error");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Merchant merchant)
        {
            try
            {
                if (id != null)
                {
                    merchant.Id = Convert.ToInt32(id);
                    if (ModelState.IsValid)
                    {
                        if (lstMerchRepository.UpdateMerchant(merchant) > 0)
                        {
                            ViewBag.Duplicate = "Merchant name " + merchant.MerchantName + " already exist in our system.";
                        }
                        else
                        {
                            ModelState.Clear();
                            return RedirectToAction("Index");
                        }
                    }
                }
                return View(merchant);
            }
            catch(Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
                return View("Error");
            }
        }


        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                lstMerchant = lstMerchRepository.GetMerchantById(Convert.ToInt32(id));
                if (lstMerchant == null)
                    return HttpNotFound();
                return View(lstMerchant);

            }
            catch(Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
                return View("Error");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, Merchant merchant)
        {
            try
            {
                if (id != null)
                {
                    merchant.Id = Convert.ToInt32(id);
                    lstMerchant = lstMerchRepository.GetMerchantById(Convert.ToInt32(id));
                    if (lstMerchant == null)
                        return HttpNotFound();
                    lstMerchRepository.DeleteMerchant(lstMerchant);
                    return RedirectToAction("Index");
                }
                return View(merchant);
            }
            catch(Exception ex)
            {
                errLog.Handle(ex.Message.ToString());
                return View("Error");
            }

        }

    }
}

using SaminProject.Library;
using SaminProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaminProject.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        private UnitOfWork unitOfWork = new UnitOfWork();

        [Authenticate]
        public ActionResult Index()
        {
            try
            {
                List<News> list = unitOfWork.NewsRepository.Get().ToList();
                return View(list);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }
        public ActionResult Create(int? Id)
        {
            try
            {
                if (Id == null)
                    return View();
                else
                {
                    News model = unitOfWork.NewsRepository.GetByID(Id);

                    if (model == null || model.ID == null)
                    {
                        TempData["Error"] = "رکورد مورد نظر شما یافت نشد";
                        return View();
                    }

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [Authenticate, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(News pModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = " خطا در اطلاعات وارد شده کاربر لطفا مجددا تلاش نمایید";
                    return View(pModel);
                }
                if (pModel.ContentFile != null && pModel.ContentFile.ContentLength / 1024 >= 200)
                {
                    TempData["Error"] = "حجم فایل انتخابی نباید بیشتر از 200kb باشد";
                    return View(pModel);
                }
                if (pModel.ID == null)
                {
                    MemoryStream ms = new MemoryStream();
                    pModel.ContentFile.InputStream.CopyTo(ms);
                    pModel.Logo = ms.ToArray();
                    unitOfWork.NewsRepository.Insert(pModel);
                }
                else
                {
                    //Get Customer
                    News model = unitOfWork.NewsRepository.GetByID(pModel.ID);
                    if (model == null)
                    {
                        TempData["Error"] = "رکورد مورد نظر شما یافت نشد";
                        return View(pModel);
                    }
                    if (pModel.ContentFile != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pModel.ContentFile.InputStream.CopyTo(ms);
                        model.Logo = ms.ToArray();
                    }

                    //Edit DataBase Data
                    model.Title = pModel.Title;
                    model.Content = pModel.Content;
                    unitOfWork.NewsRepository.Update(model);
                }

                unitOfWork.Save();
                TempData["Success"] = "عملیات با موفقیت به اتمام رسید";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [Authenticate, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int? Id)
        {
            try
            {
                var list = new List<News>();
                News model = unitOfWork.NewsRepository.GetByID(Id);
                if (model == null)
                {
                    TempData["Error"] = "رکورد مورد نظر شما یافت نشد";
                    return RedirectToAction("Index");
                }

                //Remove Item From DataBase
                unitOfWork.NewsRepository.Delete(model);
                unitOfWork.Save();

                //Get List For View
                TempData["Success"] = "عملیات با موفقیت به اتمام رسید";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
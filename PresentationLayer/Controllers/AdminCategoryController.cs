using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuYuMVC.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        public ActionResult Index(int? id)
        {
            //var categoryvalues = cm.GetAll();
            //return View(categoryvalues);
            List<SelectListItem> headingcategory = (from x in hm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.HeadingName,
                                                      Value = x.HeadingID.ToString()
                                                  }).ToList();
            List<SelectListItem> headingcategory2 = (from x in hm.GetListByCategoryId(id)
                                                  select new SelectListItem
                                                  {
                                                      Text = x.HeadingName,
                                                      Value = x.HeadingID.ToString()
                                                  }).ToList();
            ViewBag.vlc = headingcategory;
            return View(cm.GetAll());
        }
        public ActionResult GetCategoryList()
        {//kategorileri veritabanından alıyoruz

            // var categoryvalues = cm.GetList();//bu metod CategoryManager'dan geliyor
            var categoryvalues = cm.GetAll();
            // return View(categoryvalues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        //sayfada butona tıklandığında, herhangi bir şey post edildiğinde çalışır
        public ActionResult AddCategory(Category p)
        {//cm CategoryManager sınıfından türettiğimiz nesne
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList");
                //ekleme işlemini gerçekleştirdikten sonra GetCategoryList'e yönlendir
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        //Güncellenecek bilgilerin güncelleme sayfasına taşınma işlemi
        //Güncelleme işlemin kendisi

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }

    }


}

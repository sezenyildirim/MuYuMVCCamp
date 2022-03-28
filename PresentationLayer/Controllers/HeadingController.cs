using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MuYuMVC.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager();
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index(int? id)
        {

           
            if (id!=null)
            {
                List<Heading> headingcategory2 = hm.GetListByCategoryId(id);
                                                       
              
                return View(headingcategory2);

            }
            else
            {

                List<Heading> headingcategory =  hm.GetList();
                var headingvalues2 = hm.GetList();

                return View(headingcategory);
            }
        }
        [HttpGet]
        public ActionResult AddHeading()
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()//listeden seçilecek olan bir değer
                                                  select new SelectListItem //entity linq sorgusu
                                                  { //dropdownlist için
                                                      Text =x.CategoryName,//display member
                                                      Value =x.CategoryID.ToString()//value member
                                                  }).ToList();
            ViewBag.vlc = valuecategory;//viewbag verileri controllerdan view'a aktarmak için kullanılan mvc nesnesidir
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterLastname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlw = valuewriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.AddHeading(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
          
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpTask.Models;

namespace EmpTask.Controllers
{
    public class PersonalDetailController : Controller
    {
        // GET: PersonalDetail
        public ActionResult Index()
        {
   
            PersonalDetailBL bl = new PersonalDetailBL();
            List<PersonalDetail> personalDetails = bl.PersonalDetails();
           
            return View(personalDetails);
        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        
        public ActionResult Create(FormCollection form)//form as paramete
        {
         
            PersonalDetail p = new PersonalDetail();
            p.Name = form["Name"];
            p.MobileNo= form["MobileNo"];
            p.Age = int.Parse(form["Age"]);
            p.Address = form["Address"];
            
            PersonalDetailBL bl = new PersonalDetailBL();
            if (bl.Create(p))
            {
                return RedirectToAction("Index");
            }
            return View();

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            PersonalDetailBL bl = new PersonalDetailBL();
            PersonalDetail p = bl.DetailsById(id);
            return View(p);
        }
       
        //public ActionResult Edit()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Edit(PersonalDetail personalDetail)
        {
            PersonalDetailBL bl = new PersonalDetailBL();
            if (bl.Update(personalDetail))
            {
                return RedirectToAction("Index");
            }

            return View(personalDetail);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int Id)
        {
            PersonalDetailBL bl = new PersonalDetailBL();
            PersonalDetail p = bl.DetailsById(Id);
            return View(p);
        }
        //[HttpGet]
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int Id)
        {
            PersonalDetailBL bl = new PersonalDetailBL();
            if (bl.Delete(Id))
            {
                return RedirectToAction("Index");
            }
            PersonalDetail p = bl.DetailsById(Id);
            return View(p);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            PersonalDetailBL bl = new PersonalDetailBL();
            PersonalDetail p = bl.DetailsById(id);
            return View(p);
        }

        public ActionResult Home()
        {
            QualificationBL bl = new QualificationBL();
            List<Qualification> qualifications = bl.qualificationsDetail();

            return View(qualifications);
        }

        [HttpGet]
        //[ActionName("Create")]
        public ActionResult CreateQual()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQual(FormCollection form)//form as paramete
        {

            Qualification p = new Qualification();
            p.Name = form["Name"];
            p.Mark = int.Parse(form["Mark"]);
           
            QualificationBL bl = new QualificationBL();
            if (bl.CreateQual(p))
            {
                return RedirectToAction("Home");
            }
            return View();

        }

        [HttpGet]
       // [ActionName("Delete")]
        public ActionResult DeleteQual(int Id)
        {
            QualificationBL bl = new QualificationBL();
            Qualification p = bl.QualDetailsById(Id);
            return View(p);
        }
        //[HttpGet]
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        [HttpPost]
        [ActionName("DeleteQual")]
        public ActionResult Delete_Qual(int Id)
        {
            QualificationBL bl = new QualificationBL();
            if (bl.DeleteQual(Id))
            {
                return RedirectToAction("Home");
            }
            Qualification p = bl.QualDetailsById(Id);
            return View(p);
        }
        [HttpGet]
        public ActionResult QualEdit(int Id)
        {
            QualificationBL bl = new QualificationBL();
            Qualification p = bl.QualDetailsById(Id);
            return View(p);
        }

        //public ActionResult Edit()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult QualEdit(Qualification qualification)
        {
            QualificationBL bl = new QualificationBL();
            if (bl.UpdateQual(qualification))
            {
                return RedirectToAction("Home");
            }

            return View(qualification);
        }
        [HttpGet]
        public ActionResult QualDetailsById(int Id)
        {
            QualificationBL bl = new QualificationBL();
            Qualification p = bl.QualDetailsById(Id);
            return View(p);
        }

    }
}
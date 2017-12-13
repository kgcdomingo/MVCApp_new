using PhysicianDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicianDirectory.Controllers
{
    public class PhysicianController : Controller
    {
        // GET: Physician
        public ActionResult PersonalInformation()
        {
            var PerInfo = from e in physicians
                          orderby e.Id
                          select e;
            return View(PerInfo);



        }
        public ActionResult ContactInformation()
        {
            var ConInfo = from e in contactInfor
                          orderby e.Id
                          select e;
            return View(ConInfo);



        }
        public ActionResult SpecializationInformation()
        {
            var SpecInfo = from e in specializations
                           orderby e.Id
                           select e;
            return View(SpecInfo);



        }

        public static List<Physician> physicians = new List<Physician>()
       {
           new Physician
           {
               Id = 1, FirstName = "Michael", MiddleName = "Marasigan", LastName="Dionglay", BirthDate= DateTime.Now, Gender="Male", Height= 171, Weight= 65

           }
       };
        public static List<ContactInfo> contactInfor = new List<ContactInfo>()
         { new ContactInfo { Id = 1, HomeAddress = "Address", HomePhone = 099999, OfficeAddress="Office Address", OfficePhone= 0999, CellphoneNumber=0999, EmailAdd= "michael.dionglay@pointwest.com.ph" } };
        public static List<Specialization> specializations = new List<Specialization>()
         { new Specialization { Id =1, Name="Opthalmologist", Description = "Opthalmologist Description"}};




        // GET: Employee/Edit/5
        public ActionResult Edit(ulong ID)
        {


            var per = physicians.Where(p => p.Id == ID).FirstOrDefault();
            return View(per);

        }
        [HttpPost]
        public ActionResult Edit(ulong ID, FormCollection collection)
        {
            try
            {
                var phy = physicians.Single(p => p.Id == ID);
                if (TryUpdateModel(phy))
                {

                    return RedirectToAction("Index");
                }
                return View(phy);
            }
            catch
            {
                return View();
            }

        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, string next)
        {
            try
            {
                if (next != null)
                {
                    if (ModelState.IsValid)
                    {
                        Physician input = new Physician();
                        ContactInfo contact = new ContactInfo();
                        Specialization special = new Specialization();
                        input.FirstName = collection["FirstName"];
                        input.MiddleName = collection["MiddleName"];
                        input.LastName = collection["LastName"];
                        DateTime BirthDate;
                        DateTime.TryParse(collection["BirthDate"], out BirthDate);
                        input.BirthDate = BirthDate;
                        input.Gender = collection["Gender"];
                        string Height = collection["Height"];
                        input.Height = Int32.Parse(Height);
                        string Weight = collection["Weight"];
                        input.Weight = Int32.Parse(Weight);
                        physicians.Add(input);
                        return RedirectToAction("Create1");

                    }

                }
                return View();

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Create1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create1(FormCollection collection, string next)
        {
            try
            {
                if (next != null)
                {
                    if (ModelState.IsValid)
                    {
                        ContactInfo contact = new ContactInfo();
                        contact.HomeAddress = collection["HomeAddress"];
                        string HomePhone = collection["HomePhone"];
                        contact.HomePhone = ulong.Parse(HomePhone);
                        contact.OfficeAddress = collection["OfficeAddress"];
                        string OfficePhone = collection["OfficePhone"];
                        contact.OfficePhone = ulong.Parse(OfficePhone);
                        contact.EmailAdd = collection["EmailAdd"];
                        contactInfor.Add(contact);
                        return RedirectToAction("Create2");
                        //
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create2(FormCollection collection, string next)
        {
            try
            {
                Specialization special = new Specialization();
                special.Name = collection["Name"];
                special.Description = collection["Description"];
                specializations.Add(special);
                return RedirectToAction("PersonalInformation");
            }

            catch
            {
                return View();
            }
        }
        /*[NonAction]
       public List<Physician> GetPhysicianList()
       {
           return new List<Physician> {
       new Physician
       {Id = 1,FirstName = "Michael",MiddleName = "Marasigan",LastName = "Dionglay",BirthDate = DateTime.Now,Gender = "Male",Height = 171,Weight = 65,ContactInfo = new List<ContactInfo>() { new ContactInfo { PhysicianId = 1, HomeAddress = "Address", HomePhone = 099999, OfficeAddress = "Office Address", OfficePhone = 0999, CellphoneNumber = 0999, EmailAdd = "michael.dionglay@pointwest.com.ph" } },
       Specialization = new List<Specialization>() { new Specialization { PhysicianId = 1, Name = "Opthalmologist", Description = "Opthalmologist Description" } }
           }
       };
       }*/
        // GET: Employee/Delete/5
        public ActionResult Delete(ulong ID)
        {
            var del = physicians.Where(p => p.Id == ID).FirstOrDefault();
            return View(del);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(ulong ID, FormCollection collection)
        {
            try
            {
                var per = physicians.FirstOrDefault(p => p.Id == ID);
                var con = contactInfor.FirstOrDefault(p => p.Id == ID);
                var spe = specializations.FirstOrDefault(p => p.Id == ID);
                physicians.Remove(per);
                contactInfor.Remove(con);
                specializations.Remove(spe);

                return RedirectToAction("PersonalInformation");
            }

            catch
            {
                return View();
            }
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GFClaim.Models;

namespace GFClaim.Controllers
{
    // Patient controller 用的是最基本方法，其VIEW也是VS上自动生成的VIEW的修改而成
    public class PatientsController : Controller
    {
        ApplicationDbContext _dbContext;
        
        public PatientsController ()
	    {
            _dbContext  = new ApplicationDbContext();
        }

        // 这里必须dispose _dbContext
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }
        // GET: Patients
        public ActionResult Index()
        {
            var patients = _dbContext.Patients;
            return View(patients);
        }

        public ActionResult New()
        {
            Patient patient = new Patient();
            return View(patient);
        }

        public ActionResult Edit(int id)
        {
            var patient = _dbContext.Patients.SingleOrDefault(p => p.Id == id);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }
        // POST
        [HttpPost]
        public ActionResult Save(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            if (patient.Id == 0)
            {
                _dbContext.Patients.Add(patient);
            }
            else
            {
                // 这里不用singleOrDefault, 当id找不到时，会raise exception
                var patientInDb = _dbContext.Patients.Single(p => p.Id == patient.Id);
                patientInDb.FirstName = patient.FirstName;
                patientInDb.LastName = patient.LastName;
                patientInDb.Gender = patient.Gender;
                patientInDb.Birthday = patient.Birthday;
                patientInDb.SSN = patient.SSN;
                patientInDb.InsurName = patient.InsurName;
                patientInDb.InsurGroupNum = patient.InsurGroupNum;
                patientInDb.InsurCardNum = patient.InsurCardNum;
                patientInDb.Address1 = patient.Address1;
                patientInDb.Address2 = patient.Address2;
                patientInDb.City = patient.City;
                patientInDb.State = patient.State;
                patientInDb.Zipcode = patient.Zipcode;
                patientInDb.Phone = patient.Phone;
                patientInDb.Email = patient.Email;
            }

            _dbContext.SaveChanges();
            // return View("Index", "Patients");  曾犯错
            return RedirectToAction("Index", "Patients");
        }

        public ActionResult Details(int id)
        {
            var patient = _dbContext.Patients.SingleOrDefault(p => p.Id == id);
            if (patient == null)
                return HttpNotFound();

            return View(patient);
        }

        public ActionResult Delete(int id)
        {
            var patient = _dbContext.Patients.SingleOrDefault(p => p.Id == id);
            if (patient == null)
                return HttpNotFound();
            _dbContext.Patients.Remove(patient);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Patients");
        }

    }
}
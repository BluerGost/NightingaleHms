using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NightingaleHms.Models;
using NightingaleHms.ViewModel;

namespace NightingaleHms.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationDbContext _context;

        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Doctor
        public ActionResult Index()
        {
            throw new NotImplementedException();
            //return View();
        }
        public ActionResult CreateDiagnosis()
        {         
            var viewModel = new DiagnosisFormViewModel()
            {
                Patients = _context.Patients.ToList(),
                Doctors = _context.Doctors.ToList()
            };
            return View("DiagnosisForm",viewModel);
        }

        [HttpPost]
        public ActionResult SaveDiagnosis(Diagnosis diagnosis)
        {
            //when form validation fails
            if (!ModelState.IsValid)
            {
                var viewModel = new DiagnosisFormViewModel(diagnosis)
                {
                    Patients = _context.Patients.ToList(),
                    Doctors = _context.Doctors.ToList()
                };
                return View("DiagnosisForm",viewModel);
            }


            if (diagnosis.DiagnosisId == 0)//save new diagnosis
                _context.Diagnoses.Add(diagnosis);
            else//edit
            {
                var diagnosisInDb = _context.Diagnoses.Single(d => d.DiagnosisId == diagnosis.DiagnosisId);

                //editing the new values in the diagnosis model.
                diagnosisInDb.DiagnosisId = diagnosis.DiagnosisId;
                diagnosisInDb.Symptoms = diagnosis.Symptoms;
                diagnosisInDb.DiagnosisProvided = diagnosis.DiagnosisProvided;
                diagnosisInDb.DateOfDiagnosis = diagnosis.DateOfDiagnosis;
                diagnosisInDb.IsFollowUpRequired = diagnosis.IsFollowUpRequired;
                diagnosisInDb.DateOfFollowUp = diagnosis.DateOfFollowUp;
                //Navigation Property(FK)
                diagnosisInDb.PatientId = diagnosis.PatientId;
                diagnosisInDb.DoctorId = diagnosis.DoctorId;
                // diagnosisInDb.BillId = diagnosis.Bill;
            }

            //saving all the changes into the database.
            _context.SaveChanges();

            //getting billId
            int billId = diagnosis.DiagnosisId;


            //redirecting to CreateBill Action with the BillFormViewModel.
            return RedirectToAction("CreateBill", new {billId});
        }

        public ActionResult CreateBill(int? billId)
        {
            //billId doesn't exist(forcefully used This CreateBill link).
            if (billId == null || billId <= 0)
                return HttpNotFound();

            var billViewModel = new BillFormViewModel()
            {
                BillId = billId//DiagnosisId is the FK and PK in the Bills table(Column name is BillId).
            };
            return View("BillForm",billViewModel);
        }

        [HttpPost]
        public ActionResult SaveBill(Bill bill)
        {
            //when form validation fails
            if (!ModelState.IsValid)
            {
                var billViewModel = new BillFormViewModel(bill);
                return View("BillForm", billViewModel);
            }

            //getting bill instance from DB.
            var billInDb = _context.Bills.SingleOrDefault(b => b.BillId == bill.BillId);

            //new billId(save to db)
            if (billInDb==null)
                _context.Bills.Add(bill);
            else//old billId(edit in Db)
            {
                billInDb.Amount = bill.Amount;
                billInDb.IsCardPayment = bill.IsCardPayment;
                billInDb.CardNumber = bill.CardNumber;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Doctor");
        }
    }
}
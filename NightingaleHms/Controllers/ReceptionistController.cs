using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NightingaleHms.Models;
using NightingaleHms.ViewModel;
using System.Data.Entity;


namespace NightingaleHms.Controllers
{
    public class ReceptionistController : Controller
    {
        private ApplicationDbContext _context;

        public ReceptionistController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Receptionist
        public ActionResult Index()
        {
           throw  new NotImplementedException();
            
        }

        public ActionResult AllPatients()
        {
            var patient = _context.Patients
                .Include(p => p.Sex)
                .Include(p => p.BloodType)
                .Include(p => p.Plan)
                .Include(p => p.State).ToList();

            return View(patient);
        }

        public ActionResult CreatePatient()
        {
            var viewModel = new PatientFormViewModel()
            {
                States = _context.States.ToList(),
                Plans = _context.Plans.ToList(),
                BloodTypes = _context.BloodTypes.ToList(),
                Sexes = _context.Sexes.ToList()
            };
            return View("PatientForm",viewModel);
        }

        public ActionResult EditPatient(int patientId)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.PatientId == patientId);

            //if patient is not found in the database.
            if (patient==null)
            {
                return HttpNotFound();
            }

            var viewModel = new PatientFormViewModel(patient)
            {
                //Assigning List From Database Table
                States = _context.States.ToList(),
                Plans = _context.Plans.ToList(),
                BloodTypes = _context.BloodTypes.ToList(),
                Sexes = _context.Sexes.ToList()
            };

            return View("PatientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePatient(Patient patient)
        {
            //if validation fails
            if (!ModelState.IsValid)
            {
                var viewModel = new PatientFormViewModel(patient)
                {                    
                    States = _context.States.ToList(),
                    Plans = _context.Plans.ToList(),
                    BloodTypes = _context.BloodTypes.ToList(),
                    Sexes = _context.Sexes.ToList()
                };

                return View("PatientForm", viewModel);
            }


            if (patient.PatientId == 0)//new user(add)
            {
                _context.Patients.Add(patient);
            }
            else//old user(edit)
            {
                var patientInDb = _context.Patients.Single(p => p.PatientId == patient.PatientId);

                //Edit the change in the Database.
                patientInDb.FirstName = patient.FirstName;
                patientInDb.LastName = patient.LastName;
                patientInDb.Phone = patient.Phone;
                patientInDb.Age = patient.Age;
                patientInDb.Email = patient.Email;
                patientInDb.SexId = patient.SexId;
                patientInDb.BloodTypeId = patient.BloodTypeId;
                patientInDb.PlanId = patient.PlanId;
                patientInDb.StateId = patient.StateId;
            }

            //save the changes into the database.
            _context.SaveChanges();

            return RedirectToAction("AllPatients", "Receptionist");
        }
    }
}
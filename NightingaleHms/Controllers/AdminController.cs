using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NightingaleHms.Models;
using NightingaleHms.ViewModel;


namespace NightingaleHms.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Admin
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        //Get: Admin/AllUser
        public ActionResult AllDoctors()
        {
            var doctors = _context.Doctors.Include(d => d.State).Include(d => d.Plan).Include(d => d.Department).ToList();            
            return View(doctors);
        }

        public ActionResult CreateDoctor()//creating doctor for now.
        {
            var viewModel = new DoctorFormViewModel()
            {
                Departments = _context.Departments.ToList(),
                Plans = _context.Plans.ToList(),
                States = _context.States.ToList()
            };

            return View("DoctorForm",viewModel);
        }

        public ActionResult EditDoctor(int doctorId)
        {
            var doctor = _context.Doctors.Single(d => d.DoctorId == doctorId);

            //if doctor not found in the database.
            if (doctor == null)
                return HttpNotFound();

            var viewModel =  new DoctorFormViewModel(doctor)
            {
                Departments = _context.Departments.ToList(),
                Plans = _context.Plans.ToList(),
                States = _context.States.ToList()
            };
            return View("DoctorForm",viewModel);
        }

        [HttpPost]
        public ActionResult SaveDoctor(Doctor doctor)
        {
            //If Validation Fails
            if (!ModelState.IsValid)
            {
                var viewModel = new DoctorFormViewModel(doctor)
                {
                    Departments = _context.Departments.ToList(),
                    Plans = _context.Plans.ToList(),
                    States = _context.States.ToList()
                };
                return View("DoctorForm", viewModel);
            }

            if (doctor.DoctorId == 0) //new doctor
                _context.Doctors.Add(doctor);

            else//not new user.(edit information)
            {
                var doctorInDb = _context.Doctors.Single(d => d.DoctorId == doctor.DoctorId);

                doctorInDb.FirstName = doctor.FirstName;
                doctorInDb.LastName = doctor.LastName;
                doctorInDb.YearOfExperience = doctor.YearOfExperience;
                doctorInDb.DepartmentId = doctor.DepartmentId;
                doctorInDb.PlanId = doctor.PlanId;
                doctorInDb.StateId = doctor.StateId;
            }

            //save changes to the database.
            _context.SaveChanges();

            return RedirectToAction("AllDoctors", "Admin");
        }


        public ActionResult CreateDepartment()
        {
            var department = new Department();
            
            return View("DepartmentForm",department);
        }
        public ActionResult EditDepartment(int departmentId)
        {
            //getting the department that matches the passed departmentId from the database.
            var department = _context.Departments.SingleOrDefault(d => d.DepartmentId == departmentId);

            if (department == null)
                return HttpNotFound();

            return View("DepartmentForm",department);
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            //If Validation Fails
            if (!ModelState.IsValid)
            {
                return View("DepartmentForm", department);
            }


            //if validation Success.
            if (department.DepartmentId == 0) //new department
                _context.Departments.Add(department);
            else
            {
                var departmentInDb = _context.Departments.Single(d => d.DepartmentId == department.DepartmentId);


                //assigning new values to the department.
                departmentInDb.Name = department.Name;
                departmentInDb.Description = department.Description;
            }

            _context.SaveChanges();

            //redirecting to AllDepartments Action.
            return RedirectToAction("AllDepartments","Admin");
        }

        public ActionResult AllDepartments()
        {
            //getting the department that matches the passed departmentId from the database.
            var departments = _context.Departments.ToList();

           

            return View("AllDepartments", departments);
        }

        //-------------Plan-------------------
        public ActionResult CreatePlan()
        {
            var plan = new Plan();
            
            return View("PlanForm", plan);
        }

        public ActionResult EditPlan(int planId)
        {
            //getting the plan that matches the passed planId from the database.
            var plan = _context.Plans.SingleOrDefault(p => p.PlanId== planId);

            if (plan == null)
                return HttpNotFound();

            return View("PlanForm", plan);
        }

        [HttpPost]
        public ActionResult SavePlan(Plan plan)
        {
            //If Validation Fails
            if (!ModelState.IsValid)
            {
                return View("PlanForm", plan);
            }


            //if validation Success.
            if (plan.PlanId == 0) //new department
                _context.Plans.Add(plan);
            else
            {
                var planInDb = _context.Plans.Single(p => p.PlanId == plan.PlanId);

                //assigning new values to the department.
                planInDb.Name = plan.Name;
            }

            _context.SaveChanges();

            //redirecting to AllDepartments Action.
            return RedirectToAction("AllPlans", "Admin");
        }

        public ActionResult AllPlans()
        {
            //getting the department that matches the passed departmentId from the database.
            var plans = _context.Plans.ToList();



            return View("AllPlans", plans);
        }


        //---------------State---------------------
        public ActionResult CreateState()
        {
            var state = new State();

            return View("StateForm", state);
        }

        public ActionResult EditState(int stateId)
        {
            //getting the plan that matches the passed planId from the database.
            var state = _context.States.SingleOrDefault(s => s.StateId == stateId);

            if (state == null)
                return HttpNotFound();

            return View("StateForm", state);
        }

        [HttpPost]
        public ActionResult SaveState(State state)
        {
            //If Validation Fails
            if (!ModelState.IsValid)
            {
                return View("StateForm", state);
            }


            //if validation Success.
            if (state.StateId == 0) //new department
                _context.States.Add(state);
            else
            {
                var stateInDb = _context.States.Single(s => s.StateId == state.StateId);

                //assigning new values to the department.
                stateInDb.Name = state.Name;
            }

            _context.SaveChanges();

            //redirecting to AllDepartments Action.
            return RedirectToAction("AllStates", "Admin");
        }

        public ActionResult AllStates()
        {
            //getting the department that matches the passed departmentId from the database.
            var states = _context.States.ToList();



            return View("AllStates", states);
        }

    }
}
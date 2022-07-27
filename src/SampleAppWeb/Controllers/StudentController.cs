using Microsoft.AspNetCore.Mvc;
using SampleAppWeb.EntityFramework;
using SampleAppWeb.Models;
using SampleAppWeb.Uow;
using System.Data;

namespace SampleAppWeb.Controllers
{
    public class StudentController : Controller
    {
        protected readonly IStudentRepository _studentRepository;
        protected readonly UnitOfWork _unitOfWork;


        public StudentController(IStudentRepository studentRepository, UnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public ViewResult Index()
        {
            var students = _unitOfWork.StudentRepository.Get();
            // return View(students.ToPagedList(pageNumber, pageSize));
            var vm = new StudentsViewModel()
            {
                Students = students.ToList(),
                Title = "PROVA Title"
            };
            return View(vm);
        }

        //
        // GET: /Student/Details/5

        public ViewResult Details(int id)
        {
            Student student = _studentRepository.GetStudentByID(id);
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("LastName, FirstName, EnrollmentDate, Address")] CreateStudentViewModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentDatabase = new Student()
                    {
                        Address = student.Address,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        EnrollmentDate = student.EnrollmentDate
                    };

                    _studentRepository.InsertStudent(studentDatabase);
                    _studentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id)
        {
            Student student = _studentRepository.GetStudentByID(id);
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
           [Bind("LastName, FirstName, EnrollmentDate")]
         Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.UpdateStudent(student);
                    _studentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Student student = _studentRepository.GetStudentByID(id);
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Student student = _studentRepository.GetStudentByID(id);
                _studentRepository.DeleteStudent(id);
                _studentRepository.Save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _studentRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}

using Code_360.Models;
using Code_360.Models.Guarantorx;
using Code_360.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuarantorRepository _guarantorRepository;



        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IStudentRepository studentRepository, IGuarantorRepository guarantorRepository, IWebHostEnvironment hostingEnvironment)
        {
            _studentRepository = studentRepository;
            this.hostingEnvironment = hostingEnvironment;

            _guarantorRepository = guarantorRepository;

        }

        [Route("")]
        [Route("/home")]
        [Route("/index")]
        public ViewResult Index()
        {
            return View();
        }
        [Route("dashboard")]
        [AllowAnonymous]
        public ViewResult Dashboard()
        {
            var model = _studentRepository.GetAllStudent();
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Student_Details(int? id)
        {
            Student student = _studentRepository.GetStudent(id.Value);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id.Value);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                Student = student,
                PageTitle = "Student Details"
            }; 
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        private string ProcessGuarantorsFile(GurantorViewModel Gmodel)
        {
            string uniqueFileName = null;
            return uniqueFileName;
        } 

        //methods gets all guarantors
        [HttpGet]
        public ViewResult GuarantorsIndex()
        {
            return View(_guarantorRepository.GetAllGuarantor());
        }

        [Route("GuarantorsCreate/{id?}")]
        [HttpGet]
        public ViewResult GuarantorsCreate(int id)
        {
            GurantorViewModel g = new GurantorViewModel();
            g.StudentId = id;
            return View(g);
        }

        [Route("GuarantorsCreate/{id?}")]
        [HttpPost]
        public IActionResult GuarantorsCreate(GurantorViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessGuarantorsFile(model);
                Guarantors newGuarantors = new Guarantors
                {
                    GurantorName = model.GurantorName,
                    Gender = model.Gender,
                    Address = model.Address,
                    Nationality = model.Nationality,
                    HomePhone = model.HomePhone,
                    OfficePhone = model.OfficePhone,
                    GurantorEmail = model.GurantorEmail,
                    CompanyName = model.CompanyName,
                };
                _guarantorRepository.AddGuarantors(newGuarantors);
                return RedirectToAction("index");
            }
            return View();
        }





        [HttpPost]
        public IActionResult Create(StudentViewModel studentModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = ProcessUploadedFile(studentModel);
                Student newStudent = new Student
                {
                    
                    Name = studentModel.Name,
                    Gender = studentModel.Gender,
                    DateOfBirth = studentModel.DateOfBirth,
                    Address = studentModel.Address,
                    Nationality = studentModel.Nationality,
                    Phone = studentModel.Phone,
                    Photo = fileName,
                    MaritalStatus = studentModel.MaritalStatus,
                    AddmissionType = studentModel.AddmissionType,
                    NextOfKinName = studentModel.NextOfKinName,
                    NextOfKinEmail = studentModel.NextOfKinEmail,
                    NextOfKinPhone = studentModel.NextOfKinPhone,
                    NextOfKinDocumentUrl = studentModel.NextOfKinDocumentUrl,
                    BVN = studentModel.BVN
                };
                _studentRepository.AddStudent(newStudent);
                return RedirectToAction("GuarantorsCreate", "Home", new { Id = newStudent.Id });
            }
            return View();
        }

        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _studentRepository.RemoveStudent(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student = _studentRepository.GetStudent(id);
            UpdateStudent update = new UpdateStudent
            {
                Id = student.Id,
                Name = student.Name,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                Nationality = student.Nationality,
                Phone = student.Phone,
                ExistingPhotoPath = student.Photo,
                MaritalStatus = student.MaritalStatus,
                AddmissionType = student.AddmissionType,
                NextOfKinName = student.NextOfKinName,
                NextOfKinEmail = student.NextOfKinEmail,
                NextOfKinPhone = student.NextOfKinPhone,
                NextOfKinDocumentUrl = student.NextOfKinDocumentUrl,
                BVN = student.BVN
            };
            return View(update);
        }

        [HttpPost]
        public IActionResult Edit(UpdateStudent studentModel)
        {
            if (ModelState.IsValid)
            {
                Student student = _studentRepository.GetStudent(studentModel.Id);
                student.Name = studentModel.Name;
                student.Gender = studentModel.Gender;
                student.DateOfBirth = studentModel.DateOfBirth;
                student.Nationality = studentModel.Nationality;
                student.Phone = studentModel.Phone;
                student.MaritalStatus = studentModel.MaritalStatus;
                student.AddmissionType = studentModel.AddmissionType;
                student.NextOfKinName = studentModel.NextOfKinName;
                student.NextOfKinEmail = studentModel.NextOfKinEmail;
                student.NextOfKinPhone = studentModel.NextOfKinPhone;
                student.NextOfKinDocumentUrl = studentModel.NextOfKinDocumentUrl;
                student.BVN = studentModel.BVN;
                if (studentModel.Photo != null)
                {
                    if (studentModel.ExistingPhotoPath != null)
                    {
                        string filepath = Path.Combine(hostingEnvironment.WebRootPath, "images", studentModel.ExistingPhotoPath);
                        System.IO.File.Delete(filepath);
                    }
                    student.Photo = ProcessUploadedFile(studentModel);
                }

                _studentRepository.UpdateStudent(student);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadedFile(StudentViewModel studentModel)
        {
            string fileName = null;
            if (studentModel != null)
            {
                string UploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "_" + studentModel.Photo.FileName;
                string filePath = Path.Combine(UploadFolder, fileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    studentModel.Photo.CopyTo(fileStream);
                }
            }

            return fileName;
        }
    }
}

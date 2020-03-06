using Code_360.Models.Guarantorx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models
{
    public class StudentRepository : IStudentRepository, IGuarantorRepository
    {
        private StudentDbContext studentDbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        public Student AddStudent(Student _student)
        {
            studentDbContext.Students.Add(_student);
            studentDbContext.SaveChanges();
            return _student;
        }

        public Guarantors AddGuarantors(Guarantors guarantors)
        {
            studentDbContext.Guarantors.Add(guarantors);
            studentDbContext.SaveChanges();
            return guarantors;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return studentDbContext.Students;
        }

        public IEnumerable<Guarantors> GetAllGuarantor()
        {
            return studentDbContext.Guarantors;
        }


        public Student GetStudent(int Id)
        {
            return studentDbContext.Students.Find(Id);
        }

        public Guarantors GetGuarantor(int id)
        {
            return studentDbContext.Guarantors.Find(id);
        }


        public Student RemoveStudent(int Id)
        {
            Student student = studentDbContext.Students.Find(Id);
            if (student != null)
            {
                studentDbContext.Students.Remove(student);
                studentDbContext.SaveChanges();
            }
            return student;
        }


        Guarantors IGuarantorRepository.Remove(int Id)
        {
            Guarantors guarantors = studentDbContext.Guarantors.Find(Id);
            if(guarantors != null)
            {
                studentDbContext.Guarantors.Remove(guarantors);
                studentDbContext.SaveChanges();
            }
            return guarantors;
        }



        public Student UpdateStudent(Student studentUpdate)
        {
            var student = studentDbContext.Students.Attach(studentUpdate);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            studentDbContext.SaveChanges();
            return studentUpdate;
        }

        public Guarantors UpdateGuarantors(Guarantors guarantorsChanges)
        {
            var guarantor = studentDbContext.Guarantors.Attach(guarantorsChanges);
            guarantor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            studentDbContext.SaveChanges();
            return guarantorsChanges;
        }

       
    }
}

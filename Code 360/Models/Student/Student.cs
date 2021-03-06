﻿using Code_360.Models.Batches;
using Code_360.Models.EmployMentx;
using Code_360.Models.Paymentx;
using Code_360.Models.Projectox;
using Code_360.Models.StudentGurantorxx;
using Code_360.Models.StudentInBatches;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public MaritalStatus? MaritalStatus { get; set; }
        [Required]
        public AddmissionType? AddmissionType { get; set; }
        [Required]
        public string NextOfKinName { get; set; }
        [Required]
        [EmailAddress]
        public string NextOfKinEmail { get; set; }
        [Required]
        public string NextOfKinPhone { get; set; }
        public string NextOfKinDocumentUrl { get; set; }
        [Required]
        public long BVN { get; set; }
        public List<StudentGuarantor> StudentGuarantors { get; set; }

        public List<StudentInBatch> StudentBatches { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Employment> StudentCompanies { get; set; }

        public List<Project> Projects { get; set; }

    }
}

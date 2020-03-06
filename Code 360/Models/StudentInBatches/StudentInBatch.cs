using Code_360.Models.Batches;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.StudentInBatches
{
    public class StudentInBatch
    {
        [Key]
        public int Id { get; set; }

        public StudentInBatchStatus Status { get; set; }

        public Grades Grade { get; set; }

        public Batch Batch { get; set; }

        public Student Student { get; set; }

        public int StudentId { get; set; }

        //for every student would be in a particular batch
        public int BatchId { get; set; }
    }
}

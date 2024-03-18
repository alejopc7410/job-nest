using JNFinalProject.Data;
using System.ComponentModel.DataAnnotations;

namespace JNFinalProject.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [MaxLength(int.MaxValue)]
        public string EmployerId { get; set; }
        [MaxLength(50)]
        public string Position { get; set; }
        [MaxLength(int.MaxValue)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }
        [MaxLength(50)]
        public string Company { get; set; }

        // multiple applications for one job
        public ICollection<Application> Applications { get; set; }

    }
}

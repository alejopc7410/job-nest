using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JNFinalProject.Data
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        public string ApplicationDate { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicantId { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Job Job { get; set; }
    }
}

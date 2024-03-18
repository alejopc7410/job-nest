using JNFinalProject.Models;
using static System.Net.Mime.MediaTypeNames;

namespace JNFinalProject.Data.JNDAL
{
    public class ApplicationRepository
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();

        public List<JobVM> GetApplicationsList(string applicantId)
        {
            List<Job> jobsList = applicationDbContext.Job.ToList();
            List<Application> applicationsList = applicationDbContext.Application.ToList();

            var jobsVM = (
                from application in applicationDbContext.Application
                join job in applicationDbContext.Job on application.JobId equals job.JobId
                where application.ApplicantId == applicantId
                select new JobVM
                {
                    ApplicationId = application.ApplicationId,
                    Position = job.Position,
                    Company = job.Company,
                    Location = job.Location,
                    Description = job.Description,
                    ApplicationDate = application.ApplicationDate
                }
            ).ToList();
            return jobsVM;
        }

        public List<ApplicantVM> GetApplicants(string employerId)
        {
            //var user = applicationDbContext.Users.ToList();
            //var applicants = applicationDbContext.Job.Where(x => x.EmployerId == employerId).ToList();
            //var application = applicationDbContext.Application.Select(appl => new ApplicantVM
            //{
            //    ApplicantId = appl.ApplicantId,
            //    ApplicantName = user.FirstOrDefault(x => x.Id == ),
            //    ApplicationDate = appl.ApplicationDate,
            //});

            var applicants = (
                from application in applicationDbContext.Application
                join job in applicationDbContext.Job on application.JobId equals job.JobId
                join user in applicationDbContext.Users on application.ApplicantId equals user.Id
                where job.EmployerId == employerId
                select new ApplicantVM
                {
                    ApplicationId = application.ApplicationId,
                    ApplicantId = application.ApplicantId,
                    ApplicantName = $"{user.FirstName} {user.LastName}",
                    ApplicationDate = application.ApplicationDate,  
                    JobApplied = job.Position

                }).ToList();

            return applicants;
        }

        public bool DeleteApplication(int applicationId)
        {
            var application = applicationDbContext.Application.FirstOrDefault(x => x.ApplicationId == applicationId);
            if(application != null)
            {
                applicationDbContext.Application.Remove(application);
                // here a line of code to remove the record from the view of the employer
                applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteApplicant(int applicationId)
        {
            var application = applicationDbContext.Application.FirstOrDefault(x => x.ApplicationId == applicationId);
            if (application != null)
            {
                applicationDbContext.Application.Remove(application);
                applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

using JNFinalProject.Data;
using JNFinalProject.Models;

namespace JNFinalProject.Data
{
    public class JobPostRepository
    {
        ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();

        
        public List<Job> GetJobs()
        {
            var jobs = ApplicationDbContext.Job.ToList();
            return jobs;
        }

        public HaveApplied GetJobById(int jobId, string applicantId)
        {
            var job = new HaveApplied
            {
                job = ApplicationDbContext.Job.FirstOrDefault(x => x.JobId == jobId),
                applied = ApplicationDbContext.Application.Any
                            (appl => appl.ApplicantId == applicantId && appl.JobId == jobId)
            };
            return job;
        }
        
        public bool AddJob(Job job)
        {
            if(job != null)
            {
                ApplicationDbContext.Job.Add(job);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        
        public bool DeleteJob(int jobId)
        {
            var job = ApplicationDbContext.Job.FirstOrDefault(x => x.JobId == jobId);

            if(job != null)
            {
                ApplicationDbContext.Job.Remove(job);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditJob(Job job)
        {
            var jobToEdit = ApplicationDbContext.Job.FirstOrDefault(x => x.JobId == job.JobId);
            if(jobToEdit != null)
            {
                jobToEdit.Position = job.Position;
                jobToEdit.Location = job.Location;
                jobToEdit.Company = job.Company;
                jobToEdit.Description = job.Description;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        
        public List<Job> GetEmployerJobs(string employerId)
        {
            var jobs = ApplicationDbContext.Job.Where(x => x.EmployerId == employerId).ToList();
            return jobs;
        }
        
        public bool ApplyJob(Application application)
        {
            if(application != null)
            {
                ApplicationDbContext.Application.Add(application);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        
        
    }
}

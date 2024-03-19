using JNFinalProject.Models;
using System.Reflection;

namespace JNFinalProject.Data
{
    public class JobPostService
    {
        JobPostRepository repository = new JobPostRepository();

        public List<Job> GetJobs()
        {
            var jobs = repository.GetJobs();
            return jobs;
        }
        
        public List<Job> GetEmployerJobs(string employerId)
        {
            var jobs = repository.GetEmployerJobs(employerId);
            return jobs;
        }

        public HaveApplied GetJobById(int jobId, string applicantId)
        {
            return repository.GetJobById(jobId, applicantId);
        }
        
        public bool AddJob(Job job)
        {
            return repository.AddJob(job);           
        }
        
        public bool Editjob(Job job)
        {
            return repository.EditJob(job);
        }
        
        public bool DeleteJob(int jobId)
        {
            return repository.DeleteJob(jobId);
        }
        
        public bool ApplyJob(Application application)
        {
            return repository.ApplyJob(application);
        }
    }
}

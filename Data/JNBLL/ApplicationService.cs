using JNFinalProject.Data.JNDAL;
using JNFinalProject.Models;

namespace JNFinalProject.Data.JNBLL
{
    public class ApplicationService
    {
        ApplicationRepository applicationRepository = new ApplicationRepository();

        public List<JobVM> GetApplicationsList(string applicantId)
        {
            return applicationRepository.GetApplicationsList(applicantId);
        }
        
        public List<ApplicantVM> GetApplicants(string employerId)
        {
            return applicationRepository.GetApplicants(employerId);
        }
        
        public bool DeleteApplication(int applicationId)
        {
            return applicationRepository.DeleteApplication(applicationId);
        }
        
        public bool DeleteApplicant(int applicationId)
        {
            return applicationRepository.DeleteApplicant(applicationId);
        }
    }
}

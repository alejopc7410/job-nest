using JNFinalProject.Data;
using JNFinalProject.Data.JNBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JNFinalProject.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        ApplicationService applicationService = new ApplicationService();

        public ApplicationUser CurrentUser { get; set; }

        public ApplicationController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "Applicant")]
        public IActionResult Applications()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationsList(string applicantId)
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            applicantId = CurrentUser.Id;
            var jobs = applicationService.GetApplicationsList(applicantId);
            return Json(jobs);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetApplicants(string employerId)
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            employerId = CurrentUser.Id;
            var applicants = applicationService.GetApplicants(employerId);
            return Json(applicants);
        }

        [Authorize(Roles = "Recruiter")]
        public IActionResult ApplicantsList()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult DeleteApplication([FromBody] int applicationId)
        {
            var application = applicationService.DeleteApplication(applicationId);
            return Json(application);
        }
        
        [HttpPost]
        public IActionResult DeleteApplicant([FromBody] int applicationId)
        {
            var application = applicationService.DeleteApplicant(applicationId);
            return Json(application);
        }
    }
}

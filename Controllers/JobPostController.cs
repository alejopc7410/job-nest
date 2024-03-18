using JNFinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using JNFinalProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace JNFinalProject.Controllers
{    
    public class JobPostController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        JobPostService jobPostService = new JobPostService();

        public JobPostController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public ApplicationUser CurrentUser { get; set; }

        [Authorize(Roles = "Recruiter")]
        public IActionResult JobForm()
        {
            return View();
        }

        [Authorize(Roles = "Recruiter")]
        public IActionResult JobList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetJobs()
        {
            var jobs = jobPostService.GetJobs();
            return Json(jobs);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetEmployerJobs(string employerId)
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            employerId = CurrentUser.Id;
            var jobs = jobPostService.GetEmployerJobs(employerId);
            return Json(jobs);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetJobById(int jobId)
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            string applicantId = CurrentUser.Id;
            var job = jobPostService.GetJobById(jobId, applicantId);
            return Json(job);
        }

        [HttpPost]
        public async Task<IActionResult> AddJob([FromBody] Job job)
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            string employerId = CurrentUser.Id;
            job.EmployerId = employerId;
            var addedJob = jobPostService.AddJob(job);
            return Json(addedJob);
        }
        
        [HttpPost]
        public async Task<IActionResult> ApplyJob([FromBody] Application application)
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            string applicantId = CurrentUser.Id;
            application.ApplicantId = applicantId;
            application.ApplicationDate = DateTime.Now.ToString("MMMM dd, yyyy");
            var applicationJob = jobPostService.ApplyJob(application);
            return Json(applicationJob);
        }
        
        [HttpPost]
        public IActionResult EditJob([FromBody] Job job)
        {
            var updatedJob = jobPostService.Editjob(job);
            return Json(updatedJob);
        }
        
        [HttpPost]
        public IActionResult DeleteJob([FromBody] int jobId)
        {
            var job = jobPostService.DeleteJob(jobId);
            return Json(job);
        }


        /*[Authorize(Roles = "Applicant")]
        public async Task<IActionResult> RandomPageAsync()
        {
            // Get the current user
            CurrentUser = await _userManager.GetUserAsync(User);

            // Check if the user is authenticated
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }
                // Get user's firstName
            string firstName = CurrentUser.FirstName;

            // Get user's email (assuming it's stored as a claim)
            string email = CurrentUser.Email;

            // Access other custom claims as needed
            // For example:
            //string role = user.FindFirstValue(ClaimTypes.Role);

            // Use the user information as needed
            TempData["FirstName"] = firstName;
            TempData["Email"] = email;

            return View();
        }*/
    }
}

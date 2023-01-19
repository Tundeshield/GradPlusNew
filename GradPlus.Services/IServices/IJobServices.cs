using System;
using GradPlus.Data.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradPlus.Services.Models;
using GradPlus.Services.Models.JobDTOS;
using GradPlus.Services.Models.JobSeekerDTOS;

namespace GradPlus.Services.IServices
{
    public interface IJobServices
    {
        IList<Job> GetJobs();//To get all the list of jobs
        Job GetJob(int? id);//To get the detail of a single job list
        void PostJob(Job job); //To post a new Job
        void EditJob(Job job, int id);//To edit a job
        void DeleteJob(int id); //To delete a job
        bool SaveJob(SavedJob savedJob); //To save job for later use
        bool ApplyJob(string jobseekerId, int jobId);
        IList<Job> SearchJobs(string searchPhrase);
        IList<Job> GetJobCategoryJobs(int id);
        IList<JobCategory> GetJobCategories();
        //Create Job Category
        void CreateJobCategory( JobCategory jobCategory);
        //This method will edit a job details
        void EditJobCategory( JobCategory jobCategory, int? id);
        //DeleteJobCategory
        
        void DeleteJobCategory(int id);


        void DeleteCompanyCategory(int id);
        JobCategory GetJobCategory(int? id);

        //Add Job 
        void AddJob(JobEmployerCategory jobEmployerCategory, string id);

        IList<Job> GetEmployerJobs(int employerID);
        JobApplicantsDto GetJobApplicants(int jobId);
        IList<Job> GetSavedJobs(string userId);

    }
}

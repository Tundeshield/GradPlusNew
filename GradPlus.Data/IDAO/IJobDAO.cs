using System;
using GradPlus.Data.Models.Domain;
using GradPlus.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data.IDAO
{
    public interface IJobDAO
    {
        //This method will get all list of Jobs
        IList<Job> GetJobs(GradPlusContext context);

        //This method will get a job
        Job GetJob(GradPlusContext context, int? id);

        //This method will create a Job post
        void PostJob(GradPlusContext context, Job job);

        //Add job to collection of jobCategory

        void AddJobToCollection(GradPlusContext context, int jobCategoryID, Job job);

        //This method will edit a job details
        void EditJob(GradPlusContext context, Job job, int? id);

        //This method will delete a job
        void DeleteJob(GradPlusContext context, int id);

        //This method will be added as favourite job

         void SaveJob(GradPlusContext context, SavedJob savedJob);
       

        //This method will allow the jobseeker to apply the jobs
        void ApplyJob(GradPlusContext context, JobApplication jobApplication);

        //This method will get job categories
        IList<JobCategory> GetJobCategories(GradPlusContext context);
        //GetJob category
        JobCategory GetJobCategory(GradPlusContext context, int? id);
        //EditJobCategory

        //Create Job Category
        void CreateJobCategory(GradPlusContext context, JobCategory jobCategory);
        //This method will edit a job details
        void EditJobCategory(GradPlusContext context, JobCategory jobCategory, int? id);
        //DeleteJobCategory
        //This method will delete a job
        void DeleteJobCategory(GradPlusContext context, int id);

        //This Method will get the jobs from a particular category
        IList<Job> GetCategoryJobs(GradPlusContext context, int? id);
        void DeleteCompanyCategory(GradPlusContext context, int? id);
        
        //Search for Jobs
        IList<Job> SearchJobs(GradPlusContext context, string searchPhrase);

        //Get an employers jobs
        IList<Job> GetEmployerJobs(GradPlusContext context, int employerID);

        //This gets applications for a particular job
        IList<JobApplication> GetJobApplications(GradPlusContext context, int? jobId);

        // Deletes Job application
        void DeleteJobApplication(GradPlusContext context, int? jobApplicationID);
    }
}

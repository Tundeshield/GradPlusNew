using System;
using GradPlus.Data.Models.Domain;
using GradPlus.Data.Repository;
using GradPlus.Data.IDAO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace GradPlus.Data.DAO
{
    public class JobDAO : IJobDAO
    {
        public IList<Job> GetJobs(GradPlusContext context)
        {
            //The implementation will return all the jobs from the database in the form of a list
            
            return context.Jobs.ToList();
        }

        public Job GetJob(GradPlusContext context, int? id)
        {
            //This implementation will return a single job from the list
            var job = context.Jobs.Where(x => x.ID == id).FirstOrDefault();
            job.JobCategory = context.JobCategories.Where(x => x.ID == job.JobCategoryId).ToList();

            return job;

        }

        public void PostJob(GradPlusContext context, Job job)
        {
            //This implementation will create a post job method
            context.Jobs.Add(job);
            context.SaveChanges();

        }

        public void EditJob(GradPlusContext context, Job job, int? id)
        {
            //Find the Job
            var editJob = context.Jobs.Where(e => e.ID == id).FirstOrDefault();
            //edit the details of the job
            editJob.JobTitle = job.JobTitle;
            editJob.Description = job.Description;
            editJob.Salary = job.Salary;
            editJob.Location = job.Location;
            editJob.ComapanyEmail = job.ComapanyEmail;
            editJob.CompanyWebsite = job.CompanyWebsite;
            editJob.CompanyName = job.CompanyName;
            editJob.CompanyAddress = job.CompanyAddress;

            context.SaveChanges();
        }

        public void DeleteJob(GradPlusContext context, int id)
        {
            //delete the job with specific id
            context.Jobs.Remove(context.Jobs.Find(id));
            context.SaveChanges();
        }

       

        public IList<Job> GetCategoryJobs(GradPlusContext context, int? id)
        {

            var jobs = context.Jobs.Where(x => x.JobCategoryId == id);

            return jobs.ToList();
        }

        public IList<Job> SearchJobs(GradPlusContext context, string searchPhrase)
        {
            var jobs= context.Jobs.Where(e => e.JobTitle.Contains(searchPhrase) || e.Description.Contains(searchPhrase)
            || e.Location.Contains(searchPhrase) || e.CompanyName.Contains(searchPhrase)).ToList();
            return jobs;
        }

        public IList<JobCategory> GetJobCategories(GradPlusContext context)
        {
            List<JobCategory> cat = new List<JobCategory>();

            var categories = context.JobCategories.ToList();
            if(categories.Any())
            {
                foreach (var category in categories)
                {
                    category.Jobs = context.Jobs.Where(x => x.JobCategoryId == category.ID).ToList();
                    category.JobsCount = category.Jobs.Count;
                    cat.Add(category);
                }
            }



            return cat;
        }

        public IList<Job> GetEmployerJobs(GradPlusContext context, int employerID)
        {
            context.Employers.Include(j => j.Jobs).ToList();

            var employer = context.Employers.Where(j=>j.ID==employerID).FirstOrDefault();
            var jobs=employer.Jobs;
            return (IList<Job>)jobs;
        }

        public IList<JobApplication> GetJobApplications(GradPlusContext context, int? jobId)
        {
            var jobApplications = context.JobApplications.Where(e => e.JobID == jobId).ToList();
            return jobApplications;
        }

        public void DeleteJobApplication(GradPlusContext context, int? jobApplicationID)
        {
            var jobApplication = context.JobApplications.Where(j => j.ID == jobApplicationID).FirstOrDefault();
            context.JobApplications.Remove(jobApplication);
            context.SaveChanges();
        }

        public void SaveJob(GradPlusContext context, SavedJob savedJob)
        {
            context.SavedJobs.Add(savedJob);
            context.SaveChanges();
        }

     

        public void ApplyJob(GradPlusContext context, JobApplication jobApplication)
        {
            context.JobApplications.Add(jobApplication);
            context.SaveChanges();
        }

        public void DeleteCompanyCategory(GradPlusContext context, int? id)
        {
            var category = context.CompanyCategories.Where(c => c.ID == id).FirstOrDefault();
            context.CompanyCategories.Remove(category);
            context.SaveChanges();
        }

        public JobCategory GetJobCategory(GradPlusContext context, int? id)
        {
            return context.JobCategories.ToList().Find(x => x.ID == id);
        }

        public void CreateJobCategory(GradPlusContext context, JobCategory jobCategory)
        {
            context.JobCategories.Add(jobCategory);
            context.SaveChanges();
        }

        public void EditJobCategory(GradPlusContext context, JobCategory jobCategory, int? id)
        {
            //Find the Job
            var editJobCategory = context.JobCategories.Where(e => e.ID == id).FirstOrDefault();
            //edit the details of the job
            editJobCategory.Name = jobCategory.Name;
            editJobCategory.Description = jobCategory.Description;
            context.SaveChanges();
        }

        public void DeleteJobCategory(GradPlusContext context, int id)
        {
            var category = context.JobCategories.Where(c => c.ID == id).FirstOrDefault();
            context.JobCategories.Remove(category);
            context.SaveChanges();
        }

        public void AddJobToCollection(GradPlusContext context, int jobCategoryID, Job job)
        {
            var category = context.JobCategories.Where(c => c.ID == jobCategoryID).FirstOrDefault();
            category.Jobs.Add(job);
            context.SaveChanges();
        }
    }
}

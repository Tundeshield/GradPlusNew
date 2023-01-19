using GradPlus.Data.IDAO;
using GradPlus.Data.Models.Domain;
using GradPlus.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GradPlus.Data.DAO
{
    public class UserDAO : IUserDAO
    {
        //Add and employer object to Employers
        public void AddEmployer(GradPlusContext context, Employer employer)
        {
            context.Employers.Add(employer);
            //context.SaveChanges();
        }
        //Add a jobseeker object to jobseekers
        public void AddJobSeeker(GradPlusContext context, JobSeeker jobSeeker)
        {
            context.JobSeekers.Add(jobSeeker);
            context.SaveChanges();
        }

        public void CreateCompanyCategory(GradPlusContext context, CompanyCategory companyCategory)
        {
            context.CompanyCategories.Add(companyCategory);
            context.SaveChanges();
        }

        public void DeleteCompanyCategory(GradPlusContext context, int? id)
        {
            var companyCategory = context.CompanyCategories.Where(e => e.ID == id).FirstOrDefault();
            context.CompanyCategories.Remove(companyCategory);
            context.SaveChanges();
        }

        public void DeleteEmployer(GradPlusContext context, string id)
        {
            var employer = context.Employers.Where(e => e.IdentityID == id).FirstOrDefault();
            context.Employers.Remove(employer);
            context.SaveChanges();
            
        }

        public void DeleteJobSeeker(GradPlusContext context, string id)
        {
            var jobSeeker = context.JobSeekers.Where(j => j.IdentityID == id).FirstOrDefault();
            context.JobSeekers.Remove(jobSeeker);
            context.SaveChanges();
        }

        public void EditCompanyCategory(GradPlusContext context,int? id, CompanyCategory company)
        {
            var companyCat = context.CompanyCategories.Where(j => j.ID == id).FirstOrDefault();
            companyCat.Name = company.Name;
            context.SaveChanges();
        }

        //Edit Employer
        public void EditEmployer(GradPlusContext context, string id, Employer employer)
        {
           //Get employer
           var dbEmployer= context.Employers.Where(e => e.IdentityID == id).FirstOrDefault();

            //Update employer object
            dbEmployer.CompanyName = employer.CompanyName;
            dbEmployer.CompanyDescription = employer.CompanyDescription;
            dbEmployer.Website = employer.Website;
            dbEmployer.EmployeeCount = employer.EmployeeCount;
            dbEmployer.YearFounded = employer.YearFounded;
            dbEmployer.Email = employer.Email;
            dbEmployer.Profile_Img = employer.Profile_Img;

            //save employer
            context.SaveChanges();
        }

        //Edit JobSeeker
        public void EditJobSeeker(GradPlusContext context, string id, JobSeeker jobSeeker)
        {
            //Get JobSeeker
            var dbJobSeeker = context.JobSeekers.Where(e => e.IdentityID == id).FirstOrDefault();
            dbJobSeeker.Profile_Img = jobSeeker.Profile_Img;
            dbJobSeeker.FirstName = jobSeeker.FirstName;
            dbJobSeeker.LastName = jobSeeker.LastName;
            dbJobSeeker.Email = jobSeeker.Email;
            dbJobSeeker.CoverLetterFile = jobSeeker.CoverLetterFile;
            dbJobSeeker.ResumeFile = jobSeeker.ResumeFile;

            //Save Job seeker
            context.SaveChanges();
        }

        public List<CompanyCategory> GetCompanyCategories(GradPlusContext context)
        {
           return context.CompanyCategories.ToList();
        }

        public string GetCoverLetterPath(GradPlusContext context, string id)
        {
            return context.JobSeekers.Where(d => d.IdentityID == id).Select(v => v.CoverLetterFile).FirstOrDefault();
        }

        //Get single Employer by Id
        public Employer GetEmployer(GradPlusContext context, int id)
        {
            Employer employer = context.Employers.Where(e => e.ID == id).FirstOrDefault();
            return employer;
        }

        public IList<Employer> GetEmployers(GradPlusContext context)
        {
            return context.Employers.ToList();
        }

        //Get a job seeker by id
        public JobSeeker GetJobSeeker(GradPlusContext context, string id)
        {
            JobSeeker jobseeker = context.JobSeekers.Where(j => j.IdentityID == id).FirstOrDefault();
            return jobseeker;
        }

        //Get all Jobseekers
        public IList<JobSeeker> GetJobSeekers(GradPlusContext context)
        {
            return context.JobSeekers.ToList();
        }

        //Get Resume File
        public string GetResumePath(GradPlusContext context, string id)
        {
            return context.JobSeekers.Where(d => d.IdentityID == id).Select(v => v.ResumeFile).FirstOrDefault();
        }

        //Get a job seeker's job applications.
        public List<JobApplication> GetUserAppliedJobs(GradPlusContext context, string Id)
        {
            context.JobSeekers.Include(g => g.JobApplications).ToList();
            JobSeeker jobseeker = context.JobSeekers.Where(j => j.IdentityID == Id).FirstOrDefault();
            return (List<JobApplication>)jobseeker.JobApplications;
        }

        //Get users saved jobs
        public List<SavedJob> GetUserSavedJobs(GradPlusContext context, string id)
        {
            List<SavedJob> savedJobsList = new List<SavedJob>();
            var result = context.SavedJobs.Where(x => x.JobSeekerID == id).ToList();

            foreach (var item in result)
            {
                SavedJob savedJob = new SavedJob();
                savedJob.ID = item.ID;
                savedJob.JobID = item.JobID;               
                savedJobsList.Add(savedJob);
            }
            return savedJobsList;
        }


        public CompanyCategory GetCompanyCategory(GradPlusContext context, int? id)
        {
            CompanyCategory category = context.CompanyCategories.Where(j => j.ID == id).FirstOrDefault();
            return category;
        }

        public void AddToCollection(GradPlusContext context, string employerId, Job job)
        {
            var employer = context.Employers.Where(e => e.IdentityID == employerId).FirstOrDefault();
            employer.Jobs.Add(job);
            context.SaveChanges();
        }

      

        //public IList<JobApplicationDTO> SearchByJobTitle(GradPlusContext context, string text, int userId)
        //{
        //    List<JobApplicationDTO> searchJob = new List<JobApplicationDTO>();
        //    var result = context.Jobs.Where(p => p.JobTitle.Contains(text)).ToList();
        //    foreach (var item in result)
        //    {
        //        JobApplicationDTO appliedJobsList1 = new JobApplicationDTO();
        //        appliedJobsList1.Id = item.ID;
        //        appliedJobsList1.JobTitle = item.JobTitle;
        //        appliedJobsList1.Description = item.Description;
        //        //appliedJobsList1.JobCategory = item.JobCategory;
        //        appliedJobsList1.Salary = item.Salary;

        //        appliedJobsList1.IsApplied = IsApplied(context, item.ID, userId);
        //        appliedJobsList1.IsSaved = IsSaved(context, item.ID, userId);
        //        appliedJobsList1.JobApplicationId = context.JobApplications.Where(c => c.ID == item.ID && c.JobSeekerID == userId).Select(v => v.JobID).FirstOrDefault();
        //        searchJob.Add(appliedJobsList1);
        //        //.Add(appliedJobsList1);
        //    }
        //    return searchJob;
        //}

        //public bool IsApplied(GradPlusContext context, int jobId, int userId)
        //{
        //    var result = context.JobApplications.ToList().Find(a => a.ID == jobId && a.JobApplicationID == userId);
        //    if (result == null)
        //        return false;
        //    else
        //        return true;
        //}

        //public bool? IsSaved(GradPlusContext context, int jobId, string UserId)
        //{
        //    var result = context.SavedJobs.ToList().Find(a => a.ID == jobId && a.JobSeekerID == UserId);
        //    if (result == null)
        //        return false;
        //    else
        //        return true;
        //}

    }
}

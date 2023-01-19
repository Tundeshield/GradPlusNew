using System;
using GradPlus.Data.Models.Domain;
using GradPlus.Data.Repository;
using GradPlus.Data.IDAO;
using GradPlus.Data.DAO;
using GradPlus.Services.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradPlus.Services.Models;
using GradPlus.Services.Models.JobDTOS;
using GradPlus.Services.Models.JobSeekerDTOS;

namespace GradPlus.Services.Services
{
    public class JobServices : IJobServices
    {
        IJobDAO jobDAO;
        IUserDAO userDAO;
        public JobServices()
        {
            jobDAO = new JobDAO();
            userDAO = new UserDAO();
        }
        public IList<Job> GetJobs()
        {
            using(var context = new GradPlusContext())
            {
                return jobDAO.GetJobs(context);
            }
        }

        public Job GetJob(int? id)
        {
            using(var context = new GradPlusContext())
            {
                return jobDAO.GetJob(context, id);
            }
        }

        public void PostJob(Job postJobDTO)
        {
            Job newJob = new Job()
            {
                JobTitle = postJobDTO.JobTitle,
                 Description = postJobDTO.Description,
                 Salary = postJobDTO.Salary,
                ComapanyEmail = postJobDTO.ComapanyEmail,
            CompanyWebsite = postJobDTO.CompanyWebsite,
            CompanyName = postJobDTO.CompanyName,
            CompanyAddress = postJobDTO.CompanyAddress,
            Location=postJobDTO.Location,
            JobCategoryId = postJobDTO.JobCategoryId,
            EmployerId = postJobDTO.EmployerId
        };

            using(var context = new GradPlusContext())
            {
                jobDAO.PostJob(context, newJob); //post Job
                context.SaveChanges();
            }
        }

        public void EditJob(Job postJobDTO, int id)
        {
            using(var context = new GradPlusContext())
            {
                Job job = new Job();
                job.JobTitle = postJobDTO.JobTitle;
                job.Description = postJobDTO.Description;
                job.Salary = postJobDTO.Salary;
                job.Location = postJobDTO.Location;
                job.ComapanyEmail = postJobDTO.ComapanyEmail;
                job.CompanyWebsite = postJobDTO.CompanyWebsite;
                job.CompanyName = postJobDTO.CompanyName;
                job.CompanyAddress = postJobDTO.CompanyAddress;
                jobDAO.EditJob(context, job, id);
                context.SaveChanges();
            }
        }

        public void DeleteJob(int id)
        {
            using(var context = new GradPlusContext())
            {
                jobDAO.DeleteJob(context, id);
            }
        }

        public IList<Job> SearchJobs(string searchPhrase)
        {
            using (var context = new GradPlusContext())
            {
               return jobDAO.SearchJobs(context, searchPhrase);//To search for a job              
            }
        }

        public IList<Job> GetJobCategoryJobs(int id)
        {
            using (var context = new GradPlusContext())
            {
                return jobDAO.GetCategoryJobs(context, id);//To search for a job              
            }
        }

        public IList<JobCategory> GetJobCategories()
        {
            using (var context = new GradPlusContext())
            {
                return jobDAO.GetJobCategories(context);           
            }
        }

        public void SaveJob(string JobseekerId, int jobId)
        {
            using (var context = new GradPlusContext())
            {
                SavedJob saveJob = new SavedJob { JobID = jobId, JobSeekerID = JobseekerId };
                jobDAO.SaveJob(context, saveJob);
            }
        }

        public bool ApplyJob(string jobseekerId, int jobId)
        {
            using (var context = new GradPlusContext())
            {
                JobApplication application = new JobApplication { JobID = jobId, JobSeekerID = jobseekerId, JobAppliedDate = DateTime.Now };

                if (!CheckIfJobHasBeenAppliedForUser(application))
                {
                    jobDAO.ApplyJob(context, application);
                    return true;
                }
                return false;

            } 
        }

        public void DeleteCompanyCategory(int id)
        {
            using(var context=new GradPlusContext())
            {
                jobDAO.DeleteCompanyCategory(context, id);
            }
        }

        public JobCategory GetJobCategory(int? id)
        {
            using (var context = new GradPlusContext())
            {
                return jobDAO.GetJobCategory(context, id);
            }
        }

        public void CreateJobCategory(JobCategory jobCategory)
        {
            JobCategory newJobcat = new JobCategory()
            {
                Name = jobCategory.Name,
                Description = jobCategory.Description,
                
            };

            using (var context = new GradPlusContext())
            {
                jobDAO.CreateJobCategory(context, newJobcat); //post Job
                context.SaveChanges();
            }
        }

        public void EditJobCategory(JobCategory jobCategory, int? id)
        {
            using (var context = new GradPlusContext())
            {
                JobCategory jobCat = new JobCategory();
                jobCat.Name = jobCategory.Name;
                jobCat.Description = jobCategory.Description;
                
                jobDAO.EditJobCategory(context, jobCat, id);
                context.SaveChanges();
            }
        }

        public void DeleteJobCategory(int id)
        {
            using (var context = new GradPlusContext())
            {
                jobDAO.DeleteJobCategory(context, id);
            }
        }
        //Add Job to collection
        public void AddJob(JobEmployerCategory jobEmployerCategory, string id)
        {
            Job job = new Job()
            {
                JobTitle = jobEmployerCategory.JobTitle,
                Location = jobEmployerCategory.Location,
                Description = jobEmployerCategory.Description,
                CompanyName = jobEmployerCategory.CompanyName,
                ComapanyEmail = jobEmployerCategory.ComapanyEmail,
                CompanyAddress = jobEmployerCategory.CompanyAddress,
                CompanyWebsite = jobEmployerCategory.CompanyWebsite
            };

            using (var context = new GradPlusContext())
            {
                jobDAO.PostJob(context, job);
              JobCategory category=  jobDAO.GetJobCategory(context, jobEmployerCategory.JobCategoryID);
                jobDAO.AddJobToCollection(context, category.ID, job);
                Employer employer = userDAO.GetEmployer(context, jobEmployerCategory.EmployerID);
                userDAO.AddToCollection(context, employer.IdentityID, job);
                context.SaveChanges();
            }

        }

        public IList<Job> GetEmployerJobs(int employerID)
        {
            using (var context = new GradPlusContext())
            {
               return jobDAO.GetEmployerJobs(context, employerID); //post Job
                context.SaveChanges();
            }
        }

        public bool SaveJob(SavedJob savedJob)
        {
            if (!CheckIfJobIsSavedForUser(savedJob))
            {

                SavedJob job = new SavedJob
                {
                    JobID = savedJob.JobID,
                    JobSeekerID = savedJob.JobSeekerID,
                };

                using (var context = new GradPlusContext())
                {
                    jobDAO.SaveJob(context, job);
                    context.SaveChanges();
                }
                return true;
            }
            return false;
        }

        private bool CheckIfJobIsSavedForUser(SavedJob savedJob)
        {
            using (var context = new GradPlusContext())
            {
                return context.SavedJobs.Where(x=> x.JobSeekerID == savedJob.JobSeekerID && x.JobID == savedJob.JobID).Any();
            }
        }

        private bool CheckIfJobHasBeenAppliedForUser(JobApplication savedJob)
        {
            using (var context = new GradPlusContext())
            {
                return context.JobApplications.Where(x => x.JobSeekerID == savedJob.JobSeekerID && x.JobID == savedJob.JobID).Any();
            }
        }

        public JobApplicantsDto GetJobApplicants(int jobId)
        {
            JobApplicantsDto result = new JobApplicantsDto();
            using (var context = new GradPlusContext())
            {
                var job =  jobDAO.GetJob(context, jobId); //post Job

                var applications = jobDAO.GetJobApplications(context, jobId);

                result.Job = job;
                result.JobApplicants = new List<JobApplicantDto>();
                if (applications.Any())
                {
                    foreach (var applicant in applications)
                    {
                        var user = context.JobSeekers.First(x => x.IdentityID == applicant.JobSeekerID);
                        result.JobApplicants.Add(new JobApplicantDto
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            CoverLetter = user.CoverLetterFile,
                            JobSeekerId = user.IdentityID,
                            Picture = user.Profile_Img,
                            Resume = user.ResumeFile
                        });
                    }
                }

            }
            return result;
        }

        public IList<Job> GetSavedJobs(string userId)
        {
            List<Job> result = new List<Job>();
            using (var context = new GradPlusContext())
            {
                var savedJobs = context.SavedJobs.Where(x=> x.JobSeekerID == userId).Select(x=> x.JobID).ToList();

                result = jobDAO.GetJobs(context).Where(x => savedJobs.Contains(x.ID)).ToList();

            }
            return result;
        }

    }
}

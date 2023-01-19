using GradPlus.Data;
using GradPlus.Data.DAO;
using GradPlus.Data.Models.Domain;
using GradPlus.Data.Repository;
using GradPlus.Services.DTO;
using GradPlus.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Services
{
    public class UserServices : IUserServices
    {
        private UserDAO userDAO;

        public UserServices()
        {
            userDAO = new UserDAO();
        }

        //Add Employer
        public void AddEmployer(Employer employer)
        {
           
            using (var context = new GradPlusContext())
            {              
                try
                {
                    userDAO.AddEmployer(context, employer);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
            }
        }

        //Add Job seeker
        public void AddJobSeeker(JobSeeker jobSeeker)
        {
            using (var context = new GradPlusContext())
            {
                userDAO.AddJobSeeker(context,jobSeeker);
            }
        }

        public void CreateCompanyCategory(CompanyCategory companyCategory)
        {
            using (var context = new GradPlusContext())
            {
                userDAO.CreateCompanyCategory(context, companyCategory);
            }
        }

        public void DeleteCompanyCategory(int id)
        {
            using (var context = new GradPlusContext())
            {
                userDAO.DeleteCompanyCategory(context, id);
            }
        }

        //Delete Employer
        public void DeleteEmployer(string id)
        {
            using (var context = new GradPlusContext())
            {
                userDAO.DeleteEmployer(context,id);
            }
        }

        //Delete Jobseeker
        public void DeleteJobSeeker(string id)
        {
            using (var context = new GradPlusContext())
            {
                userDAO.DeleteJobSeeker(context, id);
            }
        }

        public void EditCompanyCategory(int id, CompanyCategory company)
        {
            var companyCat = new CompanyCategory()
            {
                Name = company.Name
            };
            using (var context = new GradPlusContext())
            {
                userDAO.EditCompanyCategory(context,id,companyCat);
            }
        }

        //Edit Employer service
        public void EditEmployer(string id, EditEmployerDTO employerDTO)
        {
            var newEmployer = new Employer()
            {
                Email = employerDTO.Email,
                Profile_Img = employerDTO.Profile_Img,
                CompanyName = employerDTO.CompanyName,
                CompanyDescription = employerDTO.CompanyDescription,
                Website = employerDTO.Website,
                EmployeeCount = employerDTO.EmployeeCount,
                YearFounded = employerDTO.YearFounded
            };
            using (var context = new GradPlusContext())
            {
                userDAO.EditEmployer(context, id, newEmployer);
            }
        }
        
        //Edit job seeker
        public void EditJobSeeker(string id, JobSeeker jobSeeker)
        {
            using (var context = new GradPlusContext())
            {
                userDAO.EditJobSeeker(context, id, jobSeeker);
            }
        }

        public List<CompanyCategory> GetCompanyCategories()
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetCompanyCategories(context);
            }
        }

        public CompanyCategory GetCompanyCategory(int? id)
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetCompanyCategory(context, id);
            }
        }

        //Get cover letter of a job applicant
        public string GetCoverLetterPath(string id)
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetCoverLetterPath(context, id);
            }
           
        }

        //Get employer by id
        public Employer GetEmployer(int id)
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetEmployer(context, id);
            }
           
        }

        //Get all employers
        public IList<Employer> GetEmployers()
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetEmployers(context);
            }
        }

        //Get Jobseeker by id
        public JobSeeker GetJobSeeker(string id)
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetJobSeeker(context, id);
            }
        }

        //Get all job seekers
        public IList<JobSeeker> GetJobSeekers()
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetJobSeekers(context);
            }
        }

        //Get user Resume
        public string GetResumePath(string id)
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetResumePath(context, id);
            }
        }

        //Service to get job applications
        public List<JobApplication> GetUserAppliedJobs(string id)
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetUserAppliedJobs(context, id);
            }
        }

        //Service to get user saved jobs
        public List<SavedJob> GetUserSavedJobs(string id)
        {
            using (var context = new GradPlusContext())
            {
                return userDAO.GetUserSavedJobs(context, id);
            }
        }

    }
}

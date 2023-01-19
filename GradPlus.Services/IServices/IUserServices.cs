using GradPlus.Data;
using GradPlus.Data.DAO;
using GradPlus.Data.IDAO;
using GradPlus.Data.Models.Domain;
using GradPlus.Data.Repository;
using GradPlus.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.IServices
{
    public interface IUserServices 
    {
        //Employer IServices
        void AddEmployer(Employer employer);
        Employer GetEmployer(int id);
        IList<Employer> GetEmployers();
        void EditEmployer(string id, EditEmployerDTO employerDTO);
        void DeleteEmployer(string id);

        //JobSeeker IServices
        void AddJobSeeker(JobSeeker jobSeeker);
        JobSeeker GetJobSeeker(string id);
        IList<JobSeeker> GetJobSeekers();
        void EditJobSeeker(string id, JobSeeker jobSeeker);
        void DeleteJobSeeker(string id);

        //Get Employee documents
        string GetResumePath(string id);
        string GetCoverLetterPath(string id);

        //Get list of Job Applications
        List<JobApplication> GetUserAppliedJobs(string id);

        //List of user saved jobs

        List<SavedJob> GetUserSavedJobs(string id);

       

        //List<SavedJob> GetUserSavedJobs(int id);

        //Employer category
        List<CompanyCategory> GetCompanyCategories();
        void CreateCompanyCategory(CompanyCategory companyCategory);
        void EditCompanyCategory(int id, CompanyCategory company);
        void DeleteCompanyCategory(int id);
        CompanyCategory GetCompanyCategory(int? id);

    }
}

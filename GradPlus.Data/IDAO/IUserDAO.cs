using GradPlus.Data.Models.Domain;
using GradPlus.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data.IDAO
{
    public interface IUserDAO
    {
        //Employer IDAO
        void AddEmployer(GradPlusContext context, Employer employer);
        Employer GetEmployer(GradPlusContext context, int id);
        IList<Employer> GetEmployers(GradPlusContext context);
        void EditEmployer(GradPlusContext context, string id, Employer employer);
        void DeleteEmployer(GradPlusContext context, string id);
       

        //JobSeeker IDAO
        void AddJobSeeker(GradPlusContext context, JobSeeker jobSeeker);
        JobSeeker GetJobSeeker(GradPlusContext context, string id);
        IList<JobSeeker> GetJobSeekers(GradPlusContext context);
        void EditJobSeeker(GradPlusContext context, string id, JobSeeker jobSeeker);
        void DeleteJobSeeker(GradPlusContext context, string id);
        string GetResumePath(GradPlusContext context, string id);
        string GetCoverLetterPath(GradPlusContext context, string id);

        //Get list of Job Applications
        List<JobApplication> GetUserAppliedJobs(GradPlusContext context, string id);

        //List of user saved jobs
        List<SavedJob> GetUserSavedJobs(GradPlusContext context, string id);

        void AddToCollection(GradPlusContext context, string employerId, Job job);

        //Employer category
        List<CompanyCategory> GetCompanyCategories(GradPlusContext context);
        void CreateCompanyCategory(GradPlusContext context, CompanyCategory companyCategory);
        void EditCompanyCategory(GradPlusContext context,int? id, CompanyCategory company);
        void DeleteCompanyCategory(GradPlusContext context, int? id);
        CompanyCategory GetCompanyCategory(GradPlusContext context, int? id);


    }
}


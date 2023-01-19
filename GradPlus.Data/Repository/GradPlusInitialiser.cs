using GradPlus.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data.Repository
{
    public class GradPlusInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<GradPlusContext>
    {
        protected override void Seed(GradPlusContext context)
        {
            //Job job1 = new Job()
            //{
            //    CompanyName = "XYZ Company",
            //    CompanyAddress = "Manchester",
            //    ComapanyEmail = "xyz@xyz.com",
            //    CompanyWebsite = "www.xyz.com",
            //    Description = "With the online text generator you can process your personal Lorem Ipsum " +
            //    "enriching it with html elements that define its structure, with the possibility to insert" +
            //    " external links, but not only.Now to compose a text Lorem Ipsum is much more fun!" +
            //    "In fact, inserting any fantasy text or a famous text, be it a poem, a speech, a literary" +
            //    " passage, a song's text, etc., our text generator will provide the random extraction of terms " +
            //    "and steps to compose your own exclusive Lorem Ipsum. Be original, test your imagination." +
            //    ".. our Lorem Ipsum generator will amaze you.Try it now! Copy and Paste!",
            //    Salary = 25000,
            //    JobTitle =" Software Developer"
            //};
            //context.Jobs.Add(job1);

            
          
            context.SaveChanges();
        }
    }
}

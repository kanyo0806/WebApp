using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication.Models
{
    public class DetailsDatabaseInitializer : DropCreateDatabaseIfModelChanges<DetailsContext>
    {
        protected override void Seed(DetailsContext context)
        {
            GetDetails().ForEach(x => context.Detail.Add(x));
        }
        private static List<Details> GetDetails()
        {
            var info = new List<Details>
            {
                new Details
                {
                    IDNumber = "",
                    DateOfBirth = "920725",
                    Gender = "",
                    Citizenship = "",
                    Counter = 0


                },

                 new Details
                {
                    DateOfBirth = "920725",
                    Gender = "",
                    Citizenship = "",
                    Counter = 0


                },
                  new Details
                {
                    DateOfBirth = "920725",
                    Gender = "",
                    Citizenship = "",
                    Counter = 0


                },
            };
            return info;
        }
    }
}
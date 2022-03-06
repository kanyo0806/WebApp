using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebApplication.Models;
using System.Data.Entity;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initialize details database
            //tabase.SetInitializer(new DetailsDatabaseInitializer());
            Database.SetInitializer<DetailsContext>(new DropCreateDatabaseIfModelChanges<DetailsContext>());
            
        }
    }
}
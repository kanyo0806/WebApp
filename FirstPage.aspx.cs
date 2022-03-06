using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using WebApplication.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication
{
    public partial class FirstPage : System.Web.UI.Page
    {
       
        string country = "ZA";
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch.Visible = false;
        }
        

        protected void Search(object sender, EventArgs e)
        {
            
            this. GetData();
        }
        private void GetData()
        {
            string apiUrl = "https://calendarific.com/api/v2";
            object input = new
            {
                ID = txtID.Text.Trim(),
            };
            var year = Convert.ToInt32(txtID.Text.Substring(0, 2));

            string prefix;
            if (year / 10 < 3)
            {
                prefix = "20";
            }
            else
            {
                prefix = "19";
            }
            var fullYear = prefix + year;


            string inputJson = (new JavaScriptSerializer()).Serialize(input);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString(apiUrl + "/holidays" +"/24c5e86734eb44dc4a962826324a5546e74dc42f" + country + fullYear, inputJson);
            gvHolidays.DataSource = (new JavaScriptSerializer()).Deserialize<List<Holidays>>(json);
            gvHolidays.DataBind();
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                btnSearch.Visible = true;
                var id = txtID.Text;

                //CustomValidator(sender, e);
                SaveToDB(id);
                txtID.Text = "";
            }
            
            
            
            
           

        }
        protected void CustomValidator(object source, ServerValidateEventArgs args)
        {
            
            if (txtID.Text == string.Empty)
            {
                CusID.ErrorMessage = "Please enter your ID number";
                args.IsValid = false;
                btnSearch.Visible = false;
            }
            else if (txtID.Text.Length != 13)
            {
                CusID.ErrorMessage = "ID number should be 13 digits";
                args.IsValid = false;
                btnSearch.Visible = false;
            }
            
        }

        private void SaveToDB(string idNumber)
        {
            //get date of birth


            var year = Convert.ToInt32(idNumber.Substring(0, 2));
            var month = Convert.ToInt32(idNumber.Substring(2, 2));
            var day = Convert.ToInt32(idNumber.Substring(4, 2));

            var tempDate = new DateTime(year,month,day);

            
            string prefix;
            if (year / 10 < 3)
            {
                prefix = "20";
            }
            else
            {
                prefix = "19";
            }
            


            var dateOfBirth = prefix + year + "-" + month + "-" + day;


            //get gender
            var gen = idNumber.Substring(6, 4);
            var fullGender = int.Parse(gen) < 5000 ? "Female" : "Male";

            //get citizenship
            var citi = int.Parse(idNumber.Substring(10, 1)) == 0 ? "Yes" : "No";
            int count = 1;

            using (var context = new DetailsContext())
            {
                var details = new Details()
                {
                    IDNumber = idNumber,
                    DateOfBirth = dateOfBirth,
                    Gender = fullGender,
                    Citizenship = citi,
                    Counter = count
                };
                context.Detail.Add(details);
                context.SaveChanges();
            }
        }
    }
}
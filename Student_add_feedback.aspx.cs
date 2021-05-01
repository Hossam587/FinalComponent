using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Student_add_feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void continue3_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            String Feedback = commenttext.Text;
            int cid = Int16.Parse(Cidtext.Text);
            int sid = Int16.Parse(Sidtext.Text);
            SqlCommand isenrolled = new SqlCommand("CheckStudenttakecourse", conn);
            if (Cidtext.Text == "")
            {
                Response.Write("Please enter courseid.");
            }
            else
            {
                isenrolled.Parameters.Add(new SqlParameter("@cid", cid));
            }
            if (Sidtext.Text == "")
            {
                Response.Write("Please enter studentid.");
            }
            else
            {
                isenrolled.Parameters.Add(new SqlParameter("@sid", sid));
            }

            SqlParameter success = isenrolled.Parameters.Add("@success", SqlDbType.Int);
            isenrolled.CommandType = CommandType.StoredProcedure;
            success.Direction = ParameterDirection.Output;
            conn.Open();
            isenrolled.ExecuteNonQuery();
            conn.Close();
            if (success.Value.ToString() == "1")
            {
               
                 SqlCommand addingFeedback = new SqlCommand("addFeedback", conn);
                addingFeedback.Parameters.Add(new SqlParameter("@comment", Feedback));
                if (commenttext.MaxLength <= 100)
                {
                    addingFeedback.Parameters.Add(new SqlParameter("@cid", cid));
                }
                else
                {
                    Response.Write("The maximum characters of comment are 100.");
                }
                     addingFeedback.Parameters.Add(new SqlParameter("@sid", sid));
                    addingFeedback.CommandType = CommandType.StoredProcedure;
                    Response.Write("Your Feedback was added Successfully");
                    addingFeedback.ExecuteNonQuery();

                
           
            }
            else
            {
                Response.Write("Sorry,Can not add feedback,student not enrolled in course.");

            }
            

        }
    }
}
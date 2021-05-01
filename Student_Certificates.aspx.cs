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
    public partial class Student_Certificates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewcertificate1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            int cid = Int16.Parse(courseid1text.Text);
            int sid = Int16.Parse(student1text.Text);
            SqlCommand isenrolledorisfinished = new SqlCommand("EnrollOrFinishcourse", conn);
            if (courseid1text.Text == "")
            {
                Response.Write("Please enter courseid.");
            }
            else
            {
                isenrolledorisfinished.Parameters.Add(new SqlParameter("@cid", cid));
            }
            if (student1text.Text == "")
            {
                Response.Write("Please enter studentid.");
            }
            else
            {
                isenrolledorisfinished.Parameters.Add(new SqlParameter("@sid", sid));
            }
            SqlParameter success = isenrolledorisfinished.Parameters.Add("@success", SqlDbType.Int);
            isenrolledorisfinished.CommandType = CommandType.StoredProcedure;
            success.Direction = ParameterDirection.Output;
            conn.Open();
            isenrolledorisfinished.ExecuteNonQuery();
            conn.Close();
            if (success.Value.ToString() == "1")
            {

                if (courseid1text.Text != "" && student1text.Text != "")
                {
                    Session["cid1"] = cid;
                    Session["sid1"] = sid;
                    Response.Redirect("Student_List_Certificates.aspx");
                }
                else
                {
                    Response.Write("One of the inputs is missing! Please enter all.");
                }
            
            }
            else
            {
                Response.Write("Student not enrolled in course or did not finish course.");
            }

            

        }
    }
}
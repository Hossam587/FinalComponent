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
    public partial class Studentviewassigncontent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void click1_Click(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


             int CourseId = Int16.Parse(CourseIdtext.Text);

            int StudentId = Int16.Parse(StudentIdtext.Text);
            SqlCommand isUser = new SqlCommand("Ifuser", conn);

            if (CourseIdtext.Text == "")
            {
                Response.Write("Please enter courseid.");
            }
            
            if (StudentIdtext.Text == "")
            {
                Response.Write("Please enter studentid.");
            }
            else
            {
                isUser.Parameters.Add(new SqlParameter("@Sid", StudentId));

            }

            SqlParameter success = isUser.Parameters.Add("@success", SqlDbType.Int);
            isUser.CommandType = CommandType.StoredProcedure;

            success.Direction = ParameterDirection.Output;
            conn.Open();
            isUser.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString() == "1")
            {
               
                if (CourseIdtext.Text != "" && StudentIdtext.Text != "")
                {
                    Session["student"] = StudentId;
                    Session["Course"] = CourseId;
                    Response.Redirect("Studentviewassignemtcontent.aspx");
                }
                else
                {
                    Response.Write("One of the inpouts is missing! Please enter all.");
                }
                
                }
            else
            {
                Response.Write("Not A User, please Register");
            }
            
            
           


         }


    }
}
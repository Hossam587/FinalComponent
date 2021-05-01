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
    public partial class Student_view_each_asstype_grade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Continue2_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int assignmentno = Int16.Parse(assignmantnotext.Text);
            String assignmenttype = assignmenttypetext.Text;
            int courseId = Int16.Parse(courseIdtext.Text);
            int studentId = Int16.Parse(studentIdtext.Text);
            SqlCommand checkistaking = new SqlCommand("CheckstudentwithAssandcourse", conn);
            if (assignmantnotext.Text == "")
            {
                Response.Write("Please enter assignment number.");
            }
            else
            {
                checkistaking.Parameters.Add(new SqlParameter("@assignnumber", assignmentno));
            }
            if (assignmenttype == "")
            {
                Response.Write("Please enter assignment type.");

            }
            else
            {
                checkistaking.Parameters.Add(new SqlParameter("@assignType", assignmenttype));
            }

            if (courseIdtext.Text == "")
            {
                Response.Write("Please enter courseid.");
            }
            else
            {
                checkistaking.Parameters.Add(new SqlParameter("@cid", courseId));
            }
            if (studentIdtext.Text == "")
            {
                Response.Write("Please enter studentid.");
            }
            else
            {
                checkistaking.Parameters.Add(new SqlParameter("@sid", studentId));
            }
            SqlParameter success = checkistaking.Parameters.Add("@success", SqlDbType.Int);
            checkistaking.CommandType = CommandType.StoredProcedure;
            success.Direction = ParameterDirection.Output;
            conn.Open();
            checkistaking.ExecuteNonQuery();
            conn.Close();
            if (success.Value.ToString() == "1")
            {
                if (assignmantnotext.Text != "" && courseIdtext.Text != "" && studentIdtext.Text != "" && assignmenttype != "")
                {
                    if (assignmenttypetext.MaxLength <=10) { 
                    Session["assignmentnumber"] = assignmentno;
                    Session["asssignmenttype"] = assignmanttype;
                    Session["CourseId"] = courseId;
                    Session["studentId"] = studentId;
                    Response.Redirect("Student_Assignment_grade.aspx");
                }
                    else
                    {
                        Response.Write("Assignment type exceeded the limit! 10 characters only.");
                    }
            }
                else
                {
                    Response.Write("One of the inputs is missing! Please enter all.");
                }
            }
            else
            {
                Response.Write("User does not take course");
            }


            








        }
    }
}
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
    public partial class Student_Assignment_grade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int assignmentnumber = (int)(Session["assignmentnumber"]);
            Response.Write("The assignmentnumber is"+ assignmentnumber + "< br/>");
            string assignmenttype = (string)(Session["asssignmenttype"]);
            Response.Write("The assignmenttype is" + assignmenttype + "< br/>");
            int courseid = (int)(Session["CourseId"]);
            Response.Write("The Courseid is" + courseid + "< br/>");
            int studentid = (int)(Session["studentId"]);
            Response.Write("The Studentid is" + assignmentnumber + "< br/>");
            SqlCommand viewassgrade = new SqlCommand("viewAssignGrades", conn);
            viewassgrade.Parameters.Add(new SqlParameter("@assignnumber", assignmentnumber));
            viewassgrade.Parameters.Add(new SqlParameter("@assignType", assignmenttype));
            viewassgrade.Parameters.Add(new SqlParameter("@cid", courseid));
            viewassgrade.Parameters.Add(new SqlParameter("@sid", studentid));
            SqlParameter assignmentgrade = viewassgrade.Parameters.Add("@success", SqlDbType.Decimal);
            viewassgrade.CommandType = CommandType.StoredProcedure;
            assignmentgrade.Direction = ParameterDirection.Output;
            Response.Write("The assignment grade is" + assignmentgrade );

            conn.Open();
            viewassgrade.ExecuteNonQuery();
            conn.Close();




        }
    }
}
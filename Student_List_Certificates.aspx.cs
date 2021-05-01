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
    public partial class Student_List_Certificates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand listcertificates = new SqlCommand("viewCertificate", conn);
            listcertificates.CommandType = CommandType.StoredProcedure;
            listcertificates.Parameters.Add(new SqlParameter("@cid",((int) Session["cid1"])));
            listcertificates.Parameters.Add(new SqlParameter("@sid", ((int)Session["sid1"])));
            conn.Open();
            listcertificates.ExecuteNonQuery();
            SqlDataReader rdr = listcertificates.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                 int courseID = rdr.GetInt16(rdr.GetOrdinal("cid"));
                string courseID1 = "";
                Label course = new Label();
                course.Text = courseID1 + courseID + "< br/>";
                form10.Controls.Add(course);
             
                
                int studentID = rdr.GetInt16(rdr.GetOrdinal("sid"));
                string studentID1 = "";
                Label studentid2 = new Label();
                studentid2.Text = studentID1 + studentID + "<br/>";
                form10.Controls.Add(studentid2);

                DateTime cerissuedate = rdr.GetDateTime(rdr.GetOrdinal("issueDate"));
                string cerissuedate1 = "";
                Label Idate = new Label();
                Idate.Text = cerissuedate1 + cerissuedate + "< br/>";
                form10.Controls.Add(Idate);
               
            }




        }
    }
}
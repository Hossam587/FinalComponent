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
    public partial class Studentviewassignemtcontent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Studviewassignment = new SqlCommand("viewAssign", conn);
            Studviewassignment.CommandType = CommandType.StoredProcedure;
            Studviewassignment.Parameters.Add(new SqlParameter("@courseId",((int)Session["Course"])));
            Studviewassignment.Parameters.Add(new SqlParameter("@Sid",((int)Session["student"])));
            conn.Open();
            Studviewassignment.ExecuteNonQuery();
            SqlDataReader rdr = Studviewassignment.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String Assignmentcid = rdr.GetString(rdr.GetOrdinal("cid"));
                Label Assignmentcourseid = new Label();
                Assignmentcourseid.Text = Assignmentcid + "< br/>" ;
                form20.Controls.Add(Assignmentcourseid);

                int Assignmentnumber = rdr.GetInt32(rdr.GetOrdinal("number"));
                String assnumber = "";
                Label Assignmentnumber1 = new Label(); 
                Assignmentnumber1.Text = assnumber + Assignmentnumber + "< br/>";
                form20.Controls.Add(Assignmentnumber1);

                String Assignmenttype = rdr.GetString(rdr.GetOrdinal("type"));
                 Label Assignmenttype1 = new Label();
                Assignmenttype1.Text =Assignmenttype + "< br/>";
                form20.Controls.Add(Assignmenttype1);

                int Assignmentfullgrade = rdr.GetInt32(rdr.GetOrdinal("fullGrade"));
                String assfullgrade = "";
                Label Assignmentfullgrade1 = new Label();
                Assignmentfullgrade1.Text = assfullgrade + Assignmentfullgrade + "< br/>";
                form20.Controls.Add(Assignmentfullgrade1);

                decimal Assignmentweight = rdr.GetDecimal(rdr.GetOrdinal("number"));
                String assweight = "";
                Label Assignmentweight1 = new Label();
                Assignmentweight1.Text = assweight + Assignmentweight + "< br/>";
                form20.Controls.Add(Assignmentweight1);

                DateTime Assignmentdeadline = rdr.GetDateTime(rdr.GetOrdinal("number"));
                String assdeadline = "";
                Label Assignmentdeadline1 = new Label();
                Assignmentdeadline1.Text = assdeadline + Assignmentdeadline + "< br/>";
                form20.Controls.Add(Assignmentdeadline1);

                String Assignmentcontent = rdr.GetString(rdr.GetOrdinal("number"));
                String asscontent = "";
                Label Assignmentcontent1 = new Label();
                Assignmentcontent1.Text = asscontent + Assignmentcontent + "< br/>";
                form20.Controls.Add(Assignmentcontent1);


            }
            

            

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Studentviewassigncontent.aspx");
        }


        }
}
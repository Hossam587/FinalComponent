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
    public partial class StudentsubmitAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submission_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            String Type = Asstypetext.Text;
            int Anumber = Int16.Parse(Assnumbertext.Text);
            int sid = Int16.Parse(sidtext.Text);
            int cid = Int16.Parse(cidtext.Text);
            SqlCommand isenrolled = new SqlCommand("CheckStudenttakecourse", conn);
            SqlCommand isdeadlinepassed = new SqlCommand("checkdeadline ", conn);
            if (sidtext.Text == "")
            {
                Response.Write("Please enter studentid.");
            }
            else
            {
                isenrolled.Parameters.Add(new SqlParameter("@sid", sid));
            }
            if (cidtext.Text == "")
            {
                Response.Write("Please enter courseid.");
            }
            else
            {
                isenrolled.Parameters.Add(new SqlParameter("@cid", cid));
                isdeadlinepassed.Parameters.Add(new SqlParameter("@cid", cid));

            }
            SqlParameter success = isenrolled.Parameters.Add("@success", SqlDbType.Int);
            SqlParameter successdeadline = isdeadlinepassed.Parameters.Add("@success", SqlDbType.Int);

            isenrolled.CommandType = CommandType.StoredProcedure;
            isdeadlinepassed.CommandType = CommandType.StoredProcedure;

            success.Direction = ParameterDirection.Output;
            successdeadline.Direction = ParameterDirection.Output;



            conn.Open();
            isenrolled.ExecuteNonQuery();
            isdeadlinepassed.ExecuteNonQuery();
            conn.Close();
            if(Type == "" )
            {
                Response.Write("Please enter assignment type.");
            }
            if (Assnumbertext.Text == "") {
                Response.Write("Please enter assignment number.");
            }

            if (success.Value.ToString() == "1")

            {
                if (successdeadline.Value.ToString() == "1")
                {
                    if (sidtext.Text != "" && cidtext.Text != "" && Type != "" && Assnumbertext.Text != "")
                    {

                        SqlCommand submitassignment = new SqlCommand("submitAssign", conn);
                        if (Asstypetext.MaxLength <= 10)
                        {
                            submitassignment.Parameters.Add(new SqlParameter("@assignType", Type));
                        }
                        else
                        {
                            Response.Write("Assignment type text exceeded the limit! 10 characters only.");
                        }

                        submitassignment.Parameters.Add(new SqlParameter("@assignnumber", Anumber));
                        submitassignment.Parameters.Add(new SqlParameter("@sid", sid));
                        submitassignment.Parameters.Add(new SqlParameter("@cid", cid));
                        submitassignment.CommandType = CommandType.StoredProcedure;
                        Response.Write("Submitted Successfully");
                        conn.Open();
                        submitassignment.ExecuteNonQuery();
                        conn.Close();



                    }


                    else
                    {
                        Response.Write("One of the inputs is missing! Please enter all.");
                    }
                }
                else
                {
                    Response.Write("Can not submit, Deadline reached.");
                }
            }
            
            else
            {
                Response.Write("Sorry,Can not submit,Not enrolled in the course");

            }
           



        }
    }
}
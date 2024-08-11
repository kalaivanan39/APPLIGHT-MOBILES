using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KNSquare
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OEBVR32\SQLEXPRESS;Initial Catalog=knsquare;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_register", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@username", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = UserName_tb.Text;
            SqlParameter param2 = new SqlParameter("@email", SqlDbType.VarChar);
            cmd.Parameters.Add(param2).Value = EMail_tb.Text;
            SqlParameter param3 = new SqlParameter("@password", SqlDbType.VarChar);
            cmd.Parameters.Add(param3).Value = Password_tb.Text;
            SqlParameter param4 = new SqlParameter("@mobilenum", SqlDbType.VarChar);
            cmd.Parameters.Add(param4).Value = Mobile_tb.Text;
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("Register Success");
                Response.Redirect("Login.aspx");
            }     
            else
            {
                Response.Write("Register Failed");
            }     
            con.Close();
        }
    }
}
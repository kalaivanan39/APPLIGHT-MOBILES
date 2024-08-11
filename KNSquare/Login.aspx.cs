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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OEBVR32\SQLEXPRESS;Initial Catalog=knsquare;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_login1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@username", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = UserName_txt.Text;
            SqlParameter param2 = new SqlParameter("@password", SqlDbType.VarChar);
            cmd.Parameters.Add(param2).Value = Password_txt.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int a = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            if (a > 0)
            {
                Response.Write("Login Success");
            }
            else
            {
                Response.Write("Invalid User");
            }
            con.Close();
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OEBVR32\SQLEXPRESS;Initial Catalog=knsquare;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridViewUser.DataSource = ds.Tables[0];
            GridViewUser.DataBind();
            con.Close();
        }
    }
}
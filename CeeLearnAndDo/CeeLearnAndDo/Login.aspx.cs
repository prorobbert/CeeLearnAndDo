using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeeLearnAndDo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CeeLearnAndDoDB.MDF;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [User] where Username = @Username and Password = @Password", con);
            cmd.Parameters.AddWithValue("@Username", txtusername.Text);
            cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {


                FormsAuthentication.RedirectFromLoginPage(txtusername.Text, true);
                Response.Redirect("/admin/TickerTape.aspx");

            }
            else
            {
                Response.Write("<script>alert('Please enter valid Username and Password')</script>");
            }
        }
    }
}
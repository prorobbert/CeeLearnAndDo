using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeeLearnAndDo.Admin
{
    public partial class SMTP : System.Web.UI.Page
    {
        string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CeeLearnAndDoDB.mdf;Integrated Security=True";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoadSettings(object sender, EventArgs e)
        {


            try
            {

                using (SqlConnection connection = new SqlConnection(ConStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT SMTPserver, Mail, Password, Port FROM SMTPsettings", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string SMTPserver = reader[0].ToString();
                                string Mail = reader[1].ToString();
                                string Password = reader[2].ToString();
                                int Port = Convert.ToInt32(reader[3]);

                                ServerInput.Value = SMTPserver;
                                MailInput.Value = Mail;
                                PasswordInput.Value = Password;
                                PortInput.Value = Convert.ToString(Port);

                            }


                        }
                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('error')</script>");
            }
            
        }


        protected void Update(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand command = new SqlCommand("Update SMTPsettings SET SMTPserver = @smptserver, Mail = @mail, Password = @password, Port = @port WHERE Id = 1", con);
                command.Parameters.AddWithValue("@smptserver", ServerInput.Value);
                command.Parameters.AddWithValue("@mail", MailInput.Value);
                command.Parameters.AddWithValue("@password", PasswordInput.Value);
                command.Parameters.AddWithValue("@port", PortInput.Value);

                con.Open();
                command.ExecuteNonQuery();
            }

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

        }

        protected void Testbutton_Click(object sender, EventArgs e)
        {

        }


        protected void LogOut_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(Request.RawUrl);
        }

        protected void RefreshPage_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}
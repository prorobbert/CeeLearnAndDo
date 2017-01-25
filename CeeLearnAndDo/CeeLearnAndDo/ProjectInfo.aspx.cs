using CeeLearnAndDo.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeeLearnAndDo
{
    public partial class ProjectInfo : System.Web.UI.Page
    {
        CeeLearnAndDoDB db = new CeeLearnAndDoDB();
        string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CeeLearnAndDoDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string ProjectId = Request.QueryString["id"];

                using (SqlConnection connection = new SqlConnection(ConStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Project WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", ProjectId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Title = reader[1].ToString();
                                string Description = reader[2].ToString();
                                string Publisher = reader[3].ToString();
                                string Image = reader[4].ToString();

                                ProjectTitle.Text = Title;
                                ProjectDescription.Text = Description;
                                ProjectImage.Text = "<img id='headshot' runat='server' src='" + Image + "'>";
                                ProjectPublisher.Text = Publisher;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                Response.Write("Rip, ayy error!");
            }
        }
    }
}
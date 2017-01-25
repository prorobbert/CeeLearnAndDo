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
    public partial class Projects : System.Web.UI.Page
    {
        CeeLearnAndDoDB dbObj = new CeeLearnAndDoDB();
        string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CeeLearnAndDoDB.mdf;Integrated Security=True";
        string CurrentSelected;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                if (Session["Selected"] != null)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(ConStr))
                        {
                            using (SqlCommand command = new SqlCommand("SELECT Description FROM Project WHERE Id = @Id", connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@Id", Session["Selected"]);

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        CurrentSelected = reader[0].ToString();
                                    }
                                }
                            }
                        }
                        Description.Value = CurrentSelected;
                        Button1.Enabled = true;
                    }
                    catch
                    {
                        Response.Write("<script>alert('error')</script>");
                    }
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Tickertape Where Id=@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", GridViewProducts.DataKeys[e.RowIndex].Value);
                    connection.Open();
                    command.ExecuteNonQuery();

                    BindData();
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewProducts.EditIndex = e.NewEditIndex;

            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewProducts.SetEditRow(-1);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand command = new SqlCommand("Update Project SET Naam = @Naam, Publisher = @Publisher, Image = @Image WHERE Id = @Id", con);
                command.Parameters.AddWithValue("@Naam", Convert.ToString(e.NewValues["Project_Name"]));
                command.Parameters.AddWithValue("@Publisher", Convert.ToString(e.NewValues["Project_Publisher"]));
                command.Parameters.AddWithValue("@Image", Convert.ToString(e.NewValues["Project_Image"]));
                command.Parameters.AddWithValue("@Id", e.Keys[0]);
                con.Open();
                command.ExecuteNonQuery();

            }
            BindData();

            GridViewProducts.SetEditRow(-1);
        }

        protected void GridViewProducts_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridViewProducts_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT Description FROM Project WHERE Id = @Id", connection))
                    {
                        connection.Open();
                        int IdPlus1 = Convert.ToInt32(e.NewSelectedIndex) + 1;
                        Session["Selected"] = IdPlus1;
                        command.Parameters.AddWithValue("@Id", IdPlus1);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CurrentSelected = reader[0].ToString();
                            }
                        }
                    }
                }
                Description.Value = CurrentSelected;
                Button1.Enabled = true;
            }
            catch
            {
                Response.Write("<script>alert('error')</script>");
            }
        }

        protected void InputBoxButton_Clicked(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand command = new SqlCommand("Update Project SET Description = @Description WHERE Id = @Id", con);
                command.Parameters.AddWithValue("@Description", Description.Value);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(Session["Selected"]));

                con.Open();
                command.ExecuteNonQuery();
            }
            BindData();
        }

        public void BindData()
        {
            GridViewProducts.DataSource = dbObj.GetAdminProject();
            GridViewProducts.DataBind();
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





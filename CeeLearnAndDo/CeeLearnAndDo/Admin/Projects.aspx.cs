using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeeLearnAndDo.Admin
{
    public partial class Projects : System.Web.UI.Page
    {
        CeeLearnAndDoDB dbObj = new CeeLearnAndDoDB();
        string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CeeLearnAndDoDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
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
                SqlCommand cmd = new SqlCommand("UPDATE Tickertape SET Description = @Description WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Description", Convert.ToString(e.NewValues["Tickertape_Description"]));
                cmd.Parameters.AddWithValue("@Id", e.Keys[0]);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            BindData();

            GridViewProducts.SetEditRow(-1);
        }


        protected void InputBoxButton_Clicked(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Tickertape (Description) VALUES (@Description)", con);
                command.Parameters.AddWithValue("@Description", Description.Value);

                con.Open();
                command.ExecuteNonQuery();
            }
            BindData();

        }

        public void BindData()
        {
            GridViewProducts.DataSource = dbObj.GetTickertape();
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

        // protected void RefreshGridview_OnClick(object sender, EventArgs e)
        //{
        //    //UP1.Update();
        //}
    }
}
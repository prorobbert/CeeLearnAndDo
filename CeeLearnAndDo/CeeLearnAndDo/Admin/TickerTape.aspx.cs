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
    public partial class TickerTape : System.Web.UI.Page
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
                using (SqlCommand command = new SqlCommand("DELETE FROM FAQ Where Id=@FAQIdPar", connection))
                {
                    command.Parameters.AddWithValue("@FAQIdPar", GridViewProducts.DataKeys[e.RowIndex].Value);
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
                SqlCommand cmd = new SqlCommand("UPDATE FAQ SET Vraag = @VraagPar, Antwoord = @AntwoordPar WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@VraagPar", Convert.ToString(e.NewValues["Vraag"]));
                cmd.Parameters.AddWithValue("@AntwoordPar", Convert.ToString(e.NewValues["Antwoord"]));
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
                SqlCommand command = new SqlCommand("INSERT INTO FAQ (Vraag, Antwoord) VALUES (@Vraag, @Antwoord)", con);
                //command.Parameters.AddWithValue("@Vraag", Question.Value);
                //command.Parameters.AddWithValue("@Antwoord", Answer.Value);

                con.Open();
                command.ExecuteNonQuery();
            }
            BindData();

        }

        public void BindData()
        {
            //GridViewProducts.DataSource = dbObj.getItems1();
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
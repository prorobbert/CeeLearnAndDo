using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
namespace CeeLearnAndDo
{
    public partial class rss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get connection string from the web.config file
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create SqlConnection object
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = connString;

            // SQL query to retrieve data from database
            string sqlQuery = "SELECT TOP 10 Id, Name, Publisher, Description FROM Project ORDER BY Id DESC";

            // Create SqlCommand object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlQuery;

            // open connection and then binding data into RepeaterRSS control
            sqlConn.Open();
            RepeaterRSS.DataSource = cmd.ExecuteReader();
            RepeaterRSS.DataBind();
            sqlConn.Close();
        }
        protected string RemoveIllegalCharacters(object input)
        {
            // cast the input to a string
            string data = input.ToString();

            // replace illegal characters in XML documents with their entity references
            data = data.Replace("&", "&amp;");
            data = data.Replace("\"", "&quot;");
            data = data.Replace("'", "&apos;");
            data = data.Replace("<", "&lt;");
            data = data.Replace(">", "&gt;");

            return data;
        }
    }
}
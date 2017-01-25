using CeeLearnAndDo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeeLearnAndDo
{
    public partial class ProjectInfo : System.Web.UI.Page
    {
        CeeLearnAndDoDB db = new CeeLearnAndDoDB();

        public ProjectProp project;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string input = Request.QueryString["id"];
                int parint = Int32.Parse(input);
                project = db.GetOneProject(parint);
            }
            catch (Exception)
            {
                Response.Write("Dit product bestaat niet!");
            }
        }
    }
}
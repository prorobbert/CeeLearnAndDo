using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeeLearnAndDo
{
    public partial class Project : System.Web.UI.Page
    {
        CeeLearnAndDoDB db = new CeeLearnAndDoDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListView1.DataSource = db.GetProject();
            ListView1.DataBind();
        }

    }
}
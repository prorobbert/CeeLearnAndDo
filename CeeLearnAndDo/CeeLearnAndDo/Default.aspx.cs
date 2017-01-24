using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeeLearnAndDo
{
    public partial class Default : System.Web.UI.Page
    {
        CeeLearnAndDoDB db = new CeeLearnAndDoDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = db.GetTickertape();
            Repeater1.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Event_Application_Lab_2
{
    public partial class AddNewUserNavigation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTeacher_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewTeacher.aspx");
        }

        protected void btnVolunteer_Click(object sender, EventArgs e)
        {
            tblNotAvailabe.Visible = true;
        }

        protected void btnCoordinator_Click(object sender, EventArgs e)
        {
            tblNotAvailabe.Visible = true;

        }
    }
}
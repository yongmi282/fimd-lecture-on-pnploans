using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PnpLoan.Data;

namespace PnpLoan.Web
{
    public partial class UsingEF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayUsers();
        }

        private void DisplayUsers()
        {
            using (var context = new PnpLoanEntities())
            {
                GridUser.DataSource = context.SecurityUsers.ToList();
                GridUser.DataBind();
            }
        }
    }
}
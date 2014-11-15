using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PnpLoans.Data;

namespace PnpLoans.Web
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayUsers();
        }

        private void DisplayUsers()
        {
            using (var context = new PnpLoansEntities())
            {
                //select lastname, firstname from securityusers
                //Linq
                var query = from u in context.SecurityUsers
                            select new { 
                                            u.Lastname, 
                                            u.Firstname, 
                                            u.Middlename,
                                            u.Email,
                                            u.UserType.Description
                            }; //entity framework

                GridUsers.DataSource = query.ToList();
                GridUsers.DataBind();
            }
        }
    }
}
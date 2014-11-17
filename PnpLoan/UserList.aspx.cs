using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PnpLoan.Data;

namespace PnpLoan.Web
{
    public partial class UserList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["InfoMessage"] != null)
            {
                LitMessage.Text = Session["InfoMessage"].ToString();
                Session["InfoMessage"] = null;
            }
            DisplayUsers();
        }

        private void DisplayUsers()
        {
            using (var context = new PnpLoanEntities())
            {
                //SQL Equivalent
                //select Lastname, Firstname from Security Users

                //LINQ
                var query = from u in context.SecurityUsers
                            select new {
                                         u.SecurityUserId,
                                         u.LastName,
                                         u.FirstName, 
                                         u.MiddleName, 
                                         u.Email, 
                                         u.UserType.Description
 
                                       };

                GridUser.DataSource = query.ToList();
                GridUser.DataBind();
                //GridUser.DataSource = context.SecurityUsers.ToList();
                //GridUser.DataBind();
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string securityId = GridUser.SelectedRow.Cells[1].Text;

            Response.Redirect("EditUser.aspx?ID="+securityId);

        }
    }
}
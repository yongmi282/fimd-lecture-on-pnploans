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

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (GridUser.SelectedRow == null) return;//this will not execute the codes below anymore

            int userId = int.Parse(GridUser
                             .SelectedRow
                             .Cells[1]
                             .Text);

             using (var context = new PnpLoanEntities())
             {
                 var user = context
                     .SecurityUsers
                     .FirstOrDefault(u => u.SecurityUserId == userId);

                 context.SecurityUsers.Remove(user);
                 context.SaveChanges();
             }
             DisplayUsers(); //refresh the datagrid after deleting
             GridUser.SelectedIndex = -1; //this will 'unselect' all other rows previously selected
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PnpLoan.Data;

namespace PnpLoan.Web
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TxtUsername.Enabled = false;// disable updating/editing of username
                DisplayUserType();
                DisplayUserDetails();
            }
        }

        private void DisplayUserDetails()
        {
            int id = int.Parse(Request.QueryString["ID"]);

            using (var context = new PnpLoanEntities())
            {
                //SQL: select * from SecurityUser where SecurityUser ID =
                //LINQ
                var selectQuery = from u in context.SecurityUsers
                                  where u.SecurityUserId == id
                                  select u;

                SecurityUser user = selectQuery.FirstOrDefault();

                TxtLastname.Text = user.LastName;
                TxtFirstname.Text = user.FirstName;
                TxtMiddlename.Text = user.MiddleName;
                TxtUsername.Text = user.UserName;
                TxtEmail.Text = user.Email;
                DdlUserType.SelectedValue = user.UserTypeId.ToString();

            }
        }

        private void DisplayUserType()
        {
            using (var context = new PnpLoanEntities())
            {
                DdlUserType.DataSource = context.UserTypes.ToList();
                DdlUserType.DataValueField = "UserTypeId";
                DdlUserType.DataTextField = "Description";
                DdlUserType.DataBind();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            using(var context = new PnpLoanEntities())
            {
                int userId = int.Parse(Request.QueryString["ID"]);

                //sql version: select top 1 * from SecurityUser
                //             where SecurityUserId=@userId

                //LINQ:
                //var user = (from u in context.SecurityUsers
                //           where u.SecurityUserId == userId)
                //           .FirstOrDefault();

                //Lambda
                var user = context
                    .SecurityUsers
                    .FirstOrDefault(u => u.SecurityUserId == userId);

                user.LastName = TxtLastname.Text;
                user.FirstName = TxtFirstname.Text;
                user.MiddleName = TxtMiddlename.Text;
                user.Email = TxtEmail.Text;
                user.UserTypeId = int.Parse(DdlUserType.SelectedValue);

                context.SaveChanges(); //push the changes to the Database
            }

            Response.Redirect("UserList.aspx");
        }
    }
}
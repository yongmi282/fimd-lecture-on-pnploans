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
            if (true)
            {
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

        }
    }
}
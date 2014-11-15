using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PnpLoans.Data;


namespace PnpLoans.Web
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayUserType();
            }
        }

        private void DisplayUserType()
        {
            using(var context = new PnpLoansEntities())
            {
                DdlUserType.DataSource = context.UserTypes.ToList();
                DdlUserType.DataValueField = "UserTypeId";
                DdlUserType.DataTextField = "Description";
                DdlUserType.DataBind();
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            var validationResult=ValidateInputs();

            string errorHtml="<div>";
            if(validationResult.Count>0) //has errors
            {
                errorHtml+="<ul>";
                foreach (var error in validationResult)
                {
                    errorHtml += "<li>"+error+"</li>";
                }
                errorHtml += "</ul>";

                LitHtml.Text = errorHtml;//from <asp:Literal runat="server" ID="LitHtml" />
            }
            else// no errors
            using(var context = new PnpLoansEntities())
            {
                var user = new SecurityUser();//name of table

                user.CreatedDate = DateTime.Now;
                user.Lastname = TxtLastname.Text;
                user.Firstname = TxtFirstname.Text;
                user.Middlename = TxtMiddlename.Text;
                user.Username = TxtUsername.Text;
                user.Password = TxtPassword.Text;
                user.UserTypeID = int.Parse(DdlUserType.SelectedValue);
                user.Email = TxtEmail.Text;

                context.SecurityUsers.Add(user);
                context.SaveChanges();
            
            }
        }
        private List<string> ValidateInputs()
        {
            var errors = new List<string>();
            if(string.IsNullOrWhiteSpace(TxtFirstname.Text))
            {
                errors.Add("Firstname is required.");
            }
            if(string.IsNullOrWhiteSpace(TxtLastname.Text))
            {
                errors.Add("Lastname is required.");
            }
            if(string.IsNullOrWhiteSpace(TxtMiddlename.Text))
            {
                errors.Add("Middlename is required.");
            }
            if(string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                errors.Add("Password is required.");
            }
            if(string.IsNullOrWhiteSpace(TxtRepeatPassword.Text))
            {
                errors.Add("Please retype password.");
            }
            if(string.IsNullOrWhiteSpace(TxtUsername.Text))
            {
                errors.Add("Username is required.");
            }
            if(string.IsNullOrWhiteSpace(TxtLastname.Text))
            {
                errors.Add("Lastname is required.");
            }
            if(string.IsNullOrWhiteSpace(DdlUserType.SelectedValue))
            {
                errors.Add("Please select from dropdown list.");
            }
            return errors;
        }
        }
    }

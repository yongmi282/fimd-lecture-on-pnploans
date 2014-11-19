using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PnpLoan.Data;
using System.Net.Mail;

namespace PnpLoan.Web
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
            using (var context = new PnpLoanEntities())
            {
                DdlUserType.DataSource = context.UserTypes.ToList();
                DdlUserType.DataValueField = "UserTypeId";
                DdlUserType.DataTextField = "Description";
                DdlUserType.DataBind();
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            var validationResult = ValidateInputs();

            string errorHtml = "";
            if (validationResult.Count > 0) //has errors or no unput from the user
            {
                errorHtml += "<ul>"; // errorHtml = errorHtml + "<ul>"
                foreach (var error in validationResult)
                {
                    errorHtml += "<li>" + error + "</li>";
                }
                errorHtml += "</ul>";

                LiHtml.Text = errorHtml;// LiHtml is container for html code for server side
            }

            else //no erors
            {
                AddUserToDataBase();
                Session["InfoMessage"] = "User" + TxtUsername.Text + "Succesfully Created.";
                //SPAM EMAIL: while(true) SendEmailGreeting(TxtEmail.Text);
                SendEmailGreeting(TxtEmail.Text);// put the email greeting
                Response.Redirect("UserList.aspx");
            }
        }

        private void AddUserToDataBase()
        {
            using (var context = new PnpLoanEntities())
            {
                var user = new SecurityUser();

                user.CreatedDate = DateTime.Now;
                user.LastName = TxtLastname.Text;
                user.FirstName = TxtFirstname.Text;
                user.MiddleName = TxtMiddlename.Text;
                user.UserName = TxtUsername.Text;
                user.Password = Encryption.GetMD5Hash(TxtPassword.Text);
                user.UserTypeId = int.Parse(DdlUserType.SelectedValue);
                user.Email = TxtEmail.Text;

                context.SecurityUsers.Add(user);
                context.SaveChanges();
            }
        }


        private List<string> ValidateInputs()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(TxtLastname.Text))
            {
                errors.Add("Lastname is Required.");
            }

            if (string.IsNullOrWhiteSpace(TxtFirstname.Text))
            {
                errors.Add("Firstname is Required.");
            }

            if (string.IsNullOrWhiteSpace(TxtMiddlename.Text))
            {
                errors.Add("Middlename is Required.");
            }

            if (string.IsNullOrWhiteSpace(TxtUsername.Text))
            {
                errors.Add("Username is Required.");
            }

            if (string.IsNullOrWhiteSpace(DdlUserType.Text))
            {
                errors.Add("Usertype is Required.");
            }

            if (string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                errors.Add("Email is required.");
            }

            if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                errors.Add("Password is Required.");
            }

            if (string.IsNullOrWhiteSpace(TxtRepeatPassword.Text))
            {
                errors.Add("Re-type Password.");
            }

            if (TxtPassword.Text != TxtRepeatPassword.Text)
            {
                errors.Add("Password Mismatch");
            }

            using (var entityContext = new PnpLoanEntities())
            {
                //select * from SecurityUser where Usernmae='encoder1'

                var users = from u in entityContext.SecurityUsers
                            where u.UserName == TxtUsername.Text.Trim()
                            select u;

                if (users.Count() > 0) //count returns the number of rows from the query
                {
                    errors.Add("Username already exist.");
                }

                //LINQ
                var emailCheck = from u in entityContext.SecurityUsers
                                 where u.Email == TxtEmail.Text.Trim()
                                 select u;

                if (emailCheck.Any())
                {
                    errors.Add("Email already exist.");
                }

            }
            return errors;


        }

        private void SendEmailGreeting(string email)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Credentials = new System.Net.NetworkCredential("username@gmail.com", "password");

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            MailMessage mail = new MailMessage();

            mail.Subject = "PNP Loan Welcome Email";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Hello Word this can also be in html form";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            //setting From, To and CC
            mail.From = new MailAddress("loans@PnpLoan.com", "PNP Loans");
            mail.To.Add(new MailAddress(email));

            smtpClient.Send(mail);
            //end of method
            //i will push this to the repository
            //experiment with pushing to a remote repository thru visual studio team explorer

        }
    }

}
using BookSaleFairProject.DataBase;
using DevExpress.Data.Filtering;
using DevExpress.Web;
using DevExpress.Xpo;
using DevExpress.Xpo.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookSaleFairProject.ForgetPassword
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string code = Request.QueryString["token"];
            string newPassword = txtPassword1.Text.Trim();
            string confirmPassword = txtPassword2.Text.Trim();

            if (newPassword != confirmPassword)
            {
                Response.Write("Passwords do not match.");
                return;
            }

            using (UnitOfWork uow = new UnitOfWork())
            {
                var user = uow.FindObject<User>(CriteriaOperator.Parse("PasswordResetToken = ? AND PasswordResetTokenExpiry > ?", code, DateTime.Now));
                if (user != null)
                {
                    user.Password = newPassword; // Consider hashing the password before storing it
                    user.PasswordResetToken = null;
                    user.PasswordResetTokenExpiry = null;
                    uow.CommitChanges();

                    Response.Redirect("../Login.aspx");

                }
                else
                {
                    Response.Write("Invalid or expired verification code.");
                }
            }
        }
    }
}
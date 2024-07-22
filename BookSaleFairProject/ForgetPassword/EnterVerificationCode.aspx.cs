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
    public partial class EnterVerificationCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string enteredCode = txtCode.Text.Trim();

            using (UnitOfWork uow = new UnitOfWork())
            {
                var user = uow.FindObject<User>(CriteriaOperator.Parse("PasswordResetToken = ? AND PasswordResetTokenExpiry > ?", enteredCode, DateTime.Now));
                if (user != null)
                {
                    Response.Redirect("ResetPassword.aspx?token=" + enteredCode);
                }
                else
                {
                    Response.Write("Invalid or expired verification code.");
                }
            }
        }
    }
}
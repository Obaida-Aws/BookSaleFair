using BookSaleFairProject.DataBase;
using DevExpress.Data.Filtering;
using DevExpress.Web;
using DevExpress.Xpo;
using DevExpress.Xpo.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookSaleFairProject.ForgetPassword
{
    public partial class EnterEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string username = txtEmail.Text.Trim();
            using (UnitOfWork uow = new UnitOfWork())
            {
                var user = uow.FindObject<User>(CriteriaOperator.Parse("Username = ? And Email = ?", username, email));
                if (user != null)
                {
                    string verificationCode = new Random().Next(100000, 999999).ToString();
                    user.PasswordResetToken = verificationCode;
                    user.PasswordResetTokenExpiry = DateTime.Now.AddMinutes(2); // Code valid for 10 minutes
                    uow.CommitChanges();

                    SendVerificationCodeEmail(user.Email, verificationCode);
                    Response.Redirect("EnterVerificationCode.aspx");
                }
                else
                {
                    Response.Write("Email not found.");
                }
            }
        }


        private void SendVerificationCodeEmail(string email, string code)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("s11923787@stu.najah.edu", "obaidaaws0594376261"),
                    EnableSsl = true,
                };

                mail.From = new MailAddress("s11923787@stu.najah.edu");
                mail.To.Add(email);
                mail.Subject = "Password Reset Verification Code";
                mail.Body = $"Your verification code is: {code}. This code is valid for 10 minutes.";
                mail.IsBodyHtml = false;

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                
                Response.Write($"Error: {ex.Message}");
            }
        }
    }
}
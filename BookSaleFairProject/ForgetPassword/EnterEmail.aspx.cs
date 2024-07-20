using BookSaleFairProject.DataBase;
using DevExpress.Web;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Response.Redirect("EnterVerificationCode.aspx");
            // Ensure page validation is performed
            /*  if (!ASPxEdit.ValidateEditorsInContainer(this))
              {
                  // If validation fails, do not proceed
                  return;
              }

              string username = txtEmail.Text;


              Session session = XpoDefault.Session ?? new Session();

              // Query for the user
              User user = session.Query<User>().FirstOrDefault(u => u.Username == username );

              if (user != null)
              {
                  FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                     1,                      // Version
                     user.Username,          // User data (username)
                     DateTime.Now,           // Issue time
                     DateTime.Now.AddMinutes(30), // Expiry time
                     false,                  // Is persistent cookie?
                     "your custom data"      // User data (any additional data you want to store)
                  );

                  string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                  HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                  Response.Cookies.Add(authCookie);

                  Session["Username"] = user.Username;

              }
              else
              {
                  // Optionally, add a label or message to inform the user of invalid credentials
                  // lblMessage.Text = "Invalid username or password.";
              }*/
        }
    }
}
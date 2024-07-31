using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using DevExpress.Xpo;
using DevExpress.Web;
using BookSaleFairProject.DataBase;
using DevExpress.Xpo.Logger;
using BCrypt.Net;



namespace BookSaleFairProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (!ASPxEdit.ValidateEditorsInContainer(this))
            {

                return;
            }

            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                Session session = XpoDefault.Session ?? new Session();

                User user = session.Query<User>().FirstOrDefault(u => u.Username == username);

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                       1,
                       user.Username,
                       DateTime.Now,
                       DateTime.Now.AddMinutes(30),
                       false,
                       user.Id.ToString(),
                       user.Type
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    Response.Cookies.Add(authCookie);

                    Session["Username"] = user.Username;

                    Response.Redirect($"HomePage.aspx?userId={user.Id}&userType={user.Type}");
                }
                else
                {
                    Response.Write("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
            
                Response.Write("An error occurred during login. Please try again later.");
           
            }
        }
    }
}

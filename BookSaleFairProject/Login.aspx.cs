using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using DevExpress.Xpo;
using DevExpress.Web;
using BookSaleFairProject.DataBase;



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

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Session session = XpoDefault.Session ?? new Session();

           
            User user = session.Query<User>().FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
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
   
            }
        }
    }
}

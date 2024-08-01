using DevExpress.Utils.IoC;
using DevExpress.Xpo;
using DevExpress.Xpo.Logger;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookSaleFairProject.DataBase;
using DevExpress.Web;
using System.Collections.Generic;
using System.Security.Policy;
namespace BookSaleFairProject
{
    public partial class SignUp : System.Web.UI.Page
    {


        protected void cites_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the selected location label
            //  lblSelectedLocation.Text = "Selected Location: " + gender.SelectedItem.Text;

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Example: Populate ComboBox with default data
                List<string> gender = new List<string>
                {
                    "Male",
                    "Female",

                };

                // Bind data to ASPxComboBox
                genders.DataSource = gender;
                genders.DataBind();
            }

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {


            if (!ASPxEdit.ValidateEditorsInContainer(this))
            {
                // If validation fails, do not proceed
                return;
            }
            string password1 = txtPassword.Text;
            string confirmPassword = txtPassword2.Text;

            if (password1 != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match.";
            }
            else
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    try
                    {
                        // Perform operations using the UnitOfWork
                        string firstName = txtFirstName.Text;
                        string lastName = txtLastName.Text;
                        string email = txtEmail.Text;
                        string username = txtUsername.Text.Trim();
                        string password = txtPassword.Text.Trim();
                        string type = "user";
                        string gender = genders.SelectedItem?.Text;

                        // Hash the password
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                        User newUser = new User(uow)
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Type = type,
                            Username = username,
                            Password = hashedPassword,
                            Email = email,
                            Gender = gender,
                        };

                        uow.Save(newUser);
                        uow.FlushChanges(); // Ensure that the newUser.Id is updated

                        // Add the new user to the Customers table
                        Customer newCustomer = new Customer(uow)
                        {
                            UserId = newUser.Id
                        };

                        uow.Save(newCustomer);

                        // Commit the transaction
                        uow.CommitChanges();

                        Response.Redirect("Login.aspx");
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error, if it is active
                        if (uow.InTransaction)
                        {
                            uow.RollbackTransaction();
                        }
                        lblMessage.Text = "An error occurred: " + ex.Message;
                    }
                }
            }
        }
    }
}

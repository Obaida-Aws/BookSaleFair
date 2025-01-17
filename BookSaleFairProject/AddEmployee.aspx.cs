﻿using DevExpress.Utils.IoC;
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
    public partial class AddEmployee : System.Web.UI.Page
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
                using (Session session = XpoDefault.Session)
                {
                    if (session == null)
                    {
                        throw new Exception("Session is null. Data layer might not be initialized correctly.");
                    }

                    // Perform operations using the session
                    string firstName = txtFirstName.Text;
                    string lastName = txtLastName.Text;
                    string email = txtEmail.Text;
                    string username = txtUsername.Text.Trim();
                    string password = txtPassword.Text.Trim();
                    string type = "employee";
                    string gender = genders.SelectedItem?.Text;

                    User newUser = new User(session)
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Type = type,
                        Username = username,
                        Password = password,
                        Email = email,
                        Gender = gender,
                    };

                    session.Save(newUser);
                    Response.Redirect("Login.aspx");

                }
            }
        }
    }
}

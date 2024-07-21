using BookSaleFairProject.DataBase;
using DevExpress.Web;
using DevExpress.Xpo.Logger;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BookSaleFairProject
{
    public partial class AddNewBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                   // lblMessage.Text = "Book Name is required.";
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                 //   lblMessage.Text = "Invalid price.";
                    return;
                }

                if (!int.TryParse(txtCount.Text, out int count))
                {
                   // lblMessage.Text = "Invalid count.";
                    return;
                }

                using (var uow = new UnitOfWork())
                {
                    Book newBook = new Book(uow)
                    {
                        Title = txtTitle.Text,
                        Author=txtAuthor.Text,
                        Price = price,
                        Count = count,
                        Description= txtDescription.Text,
                    };

                    uow.Save(newBook);
                    uow.CommitChanges();
                }
                
                Response.Redirect("HomePage.aspx");
                txtTitle.Text = "";
                txtPrice.Text = "";
                txtCount.Text = "";
               

            }
            catch (Exception ex)
            {
              //  lblMessage.Text = "Error adding book: " + ex.Message;
            }
        }
    }
}
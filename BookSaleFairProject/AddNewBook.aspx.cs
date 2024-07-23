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

            if (!IsPostBack)
            {
                // Example: Populate ComboBox with default data
                List<string> type = new List<string>
                {
                    "Fiction",
                    "History",
                    "Science",
                    "Children’s Books",
                    "Poetry",
                    "Young Adult (YA)"

                };

                // Bind data to ASPxComboBox
                types.DataSource = type;
                types.DataBind();
            }

        }

        protected void cites_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the selected location label
            //  lblSelectedLocation.Text = "Selected Location: " + gender.SelectedItem.Text;

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
                string selectedType = types.SelectedItem?.Text ?? "";
                using (var uow = new UnitOfWork())
                {
                    Book newBook = new Book(uow)
                    {
                        Title = txtTitle.Text,
                        Author=txtAuthor.Text,
                        Price = price,
                        Count = count,
                        Description= txtDescription.Text,
                        Type= selectedType,
                    };

                    uow.Save(newBook);
                    uow.CommitChanges();
                }
                
                Response.Redirect("HomePage.aspx");
                txtTitle.Text = "";
                txtPrice.Text = "";
                txtCount.Text = "";
                txtAuthor.Text = ""; 
                txtDescription.Text = "";


            }
            catch (Exception ex)
            {
              //  lblMessage.Text = "Error adding book: " + ex.Message;
            }
        }
    }
}
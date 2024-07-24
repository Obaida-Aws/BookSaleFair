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
                List<string> type = new List<string>
                {
                    "Fiction",
                    "History",
                    "Science",
                    "Children’s Books",
                    "Poetry",
                    "Young Adult (YA)"

                };

                types.DataSource = type;
                types.DataBind();
            }

        }

        protected void cites_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                   
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    
                    return;
                }

                if (!int.TryParse(txtCount.Text, out int count))
                {
                  
                    return;
                }
                string selectedType = types.SelectedItem?.Text ?? "";

                string filePath = null;
                string title = txtTitle.Text.Trim();
                string imageName = null;

                if (Upload.HasFile)
                {

                    imageName = $"{title}.jpg";
                    filePath = Page.MapPath("~/Books_Images/" + imageName);
                    Upload.SaveAs(filePath);
                }


                using (var uow = new UnitOfWork())
                {
                    Book newBook = new Book(uow)
                    {
                        Title = txtTitle.Text,
                        Author = txtAuthor.Text,
                        Price = price,
                        Count = count,
                        Description = txtDescription.Text,
                        Type = selectedType,
                        ImageName = imageName
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
                Response.Write("Error adding book: " + ex.Message);
            }
        }
    }
}
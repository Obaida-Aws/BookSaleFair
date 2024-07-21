using DevExpress.Xpo;
using System;
using BookSaleFairProject.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace BookSaleFairProject
{
    public partial class EditBookData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["index"] != null)
                {
                    int index = Convert.ToInt32(Request.QueryString["index"]);
                    LoadBookDetails(index);
                    // Use the index as needed
                    // For example, retrieve data related to this index
                }
            }

        }


        protected void LoadBookDetails(int bookId)
        {
            using (var uow = new UnitOfWork())
            {
                Book book = uow.GetObjectByKey<Book>(bookId);
                if (book != null)
                {
                    txtTitle.Text = book.Title;
                    txtAuthor.Text = book.Author;
                    txtPrice.Text = book.Price.ToString();
                    txtCount.Text = book.Count.ToString();
                    txtDescription.Text = book.Description;
                }
            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string Title = txtTitle.Text;
            string Author = txtAuthor.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int count = Convert.ToInt32(txtCount.Text);
            string Description = txtDescription.Text;
            int bookId = Convert.ToInt32(Request.QueryString["index"]);
            Session session = XpoDefault.Session;
            Book book = session.GetObjectByKey<Book>(bookId);
            if (book != null)
            {
                book.Title = Title;
                book.Author = Author;
                book.Price = price;
                book.Count = count;
                book.Description = Description;
                session.Save(book); // Use session.Save(book) to save changes
                Response.Redirect("Book.aspx");
            }
        }
    }
}
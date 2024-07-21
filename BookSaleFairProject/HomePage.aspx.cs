using BookSaleFairProject.DataBase;
using DevExpress.Web;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookSaleFairProject
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindBooksGrid();
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewBook.aspx");
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = ASPxTextBox1.Text.Trim();

            // Apply filter directly to the ASPxCardView
            ASPxCardView1.FilterExpression = $"Contains([Title], '{searchTerm}')";

            // Rebind data to apply the filter
            ASPxCardView1.DataBind();
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as ASPxButton).CommandArgument);

            // Redirect to EditBookData.aspx with the index as a query parameter
            Response.Redirect($"EditBookData.aspx?index={index}");
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as ASPxButton).CommandArgument);
            // Retrieve the ID from your data source using the index
            var dataSource = ViewState["DataSource"] as List<CardData>;
            int bookIdToDelete = dataSource[index].ID;

            Session session = XpoDefault.Session;
            Book book = session.GetObjectByKey<Book>(bookIdToDelete);
            if (book != null)
            {
                book.Delete();
                //   session.Save(book); // Save the changes
                // we don't need it the delete 
            }
            Response.Redirect(Request.RawUrl);
        }


        protected void BindBooksGrid()
        {
            Session session = XpoDefault.Session;

            if (session == null)
            {
                session = new Session();
                XpoDefault.Session = session;
            }

            XPCollection<Book> booksCollection = new XPCollection<Book>(session);

            // Convert XPCollection to List<CardData>
            var dataSource = booksCollection.Select(book => new CardData
            {
                ID = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            }).ToList();

            ViewState["DataSource"] = dataSource;

            ASPxCardView1.DataSource = dataSource;
            ASPxCardView1.DataBind();
        }




    }


    [Serializable]
    public class CardData
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
    }
}
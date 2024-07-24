using BookSaleFairProject.DataBase;
using DevExpress.Data.Filtering;
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
            // Ensure the popup is hidden initially
            popupCart.ShowOnPageLoad = false;

            if (!IsPostBack)
            {
                // Bind dummy data to the grid inside the popup
                BindPopupGrid();
            }
        }

        protected void BindPopupGrid()
        {
            List<Product> products = new List<Product>
            {
                new Product { orderId = 1, Price = 10.50M, Date = new DateTime(2024, 7, 23) },
                new Product { orderId = 2, Price = 20.75M, Date = new DateTime(2024, 7, 24) },
                new Product { orderId = 3, Price = 15.25M, Date = new DateTime(2024, 7, 25) }
                // Add more dummy data as needed
            };

            gridProducts.DataSource = products;
            gridProducts.DataBind();
        }

        protected void gridProducts_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            // Handle the cancel button click inside the grid
            if (e.ButtonID == "Cancel")
            {
                // Your cancel button logic here, if needed
                popupCart.ShowOnPageLoad = false; // Hide the popup after cancellation
            }
        }



        protected void ASPxok1_Click(object sender, EventArgs e)
        {
            popupCart.ShowOnPageLoad = true;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
        }

        protected void ASPxorder1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowOrders.aspx");
        }



        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewBook.aspx");
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = ASPxTextBox1.Text.Trim();


            ASPxCardView1.FilterExpression = $"Contains([Title], '{searchTerm}')";


            ASPxCardView1.DataBind();
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as ASPxButton).CommandArgument);

            // Redirect to EditBookData.aspx with the index as a query parameter
            Response.Redirect($"EditBookData.aspx?index={index}");
        }

        protected void ASPxMenu2_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            string selectedType = e.Item.Text;
            BindBooksGrid(selectedType);
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


        protected void BindBooksGrid(string bookType = null)
        {
            Session session = XpoDefault.Session;

            if (session == null)
            {
                session = new Session();
                XpoDefault.Session = session;
            }

            XPCollection<Book> booksCollection;

            if (string.IsNullOrEmpty(bookType)|| bookType=="All")
            {
                // Get all books if bookType is null or empty
                booksCollection = new XPCollection<Book>(session);
            }
            else
            {
                // Get books with the specified type
                booksCollection = new XPCollection<Book>(session, CriteriaOperator.Parse("Type = ?", bookType));
            }

            // Convert XPCollection to List<CardData>
            var dataSource = booksCollection.Select(book => new CardData
            {
                ID = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                ImageUrl = string.IsNullOrEmpty(book.ImageName) ? null : $"/Books_Images/{book.ImageName}"
            }).ToList();

            ViewState["DataSource"] = dataSource;

            ASPxCardView1.DataSource = dataSource;
            ASPxCardView1.DataBind();
        }


        [Serializable]
        public class CardData
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public Decimal Price { get; set; }
            public string ImageUrl { get; set; }
        }

        public class Product
        {
            public int orderId { get; set; }
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
           
        }
    }
}
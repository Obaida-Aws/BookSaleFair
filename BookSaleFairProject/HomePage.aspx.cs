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
                new Product { Name = "Product A", Price = 10.50M },
                new Product { Name = "Product B", Price = 20.75M },
                new Product { Name = "Product C", Price = 15.25M }
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

            protected void ASPxMenu2_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            string type = e.Item.Name;
            Console.WriteLine("Hello World! ");

            if (!string.IsNullOrEmpty(type))
            {
                ASPxCardView1.FilterExpression = $"Type = '{type}'";
            }
            else
            {
                
                ASPxCardView1.FilterExpression = "";
            }

            ASPxCardView1.DataBind(); 
            
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
            Response.Redirect($"EditBookData.aspx?index={index}");
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as ASPxButton).CommandArgument);
            var dataSource = ViewState["DataSource"] as List<CardData>;
            int bookIdToDelete = dataSource[index].ID;

            Session session = XpoDefault.Session;
            Book book = session.GetObjectByKey<Book>(bookIdToDelete);
            if (book != null)
            {
                book.Delete();

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

            
            var dataSource = booksCollection.Select(book => new CardData
            {
                ID = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                Type=book.Type

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
        public string Type { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }


}
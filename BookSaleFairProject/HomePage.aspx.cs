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

        private Session _session;
        public string orderID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  BindContentGrid();
                // Check if username is provided in the query string
                if (Request.QueryString["userId"] != null)
                {
                    string userId = Request.QueryString["userId"];
                    // lblWelcomeMessage.Text = $"Welcome, {username}!";
                    string userType = Request.QueryString["userType"];

                    // Check if userType is "user" to show the button
                    if (userType == "user")
                    {
                        ASPxButton2.Visible = false;
                        ASPxButton1.Visible = true;
                        btnAdd.Visible = false;
                    //    btnDelete.Visible = false;


                    }else if(userType == "admin")
                    {
                        ASPxButton3.Visible = true;
                        ASPxButton1.Visible = false;
                    }
                    else
                    {
                        ASPxButton2.Visible = true;
                        ASPxButton1.Visible = false;
                        btnAdd.Visible = true;
                    }
                }

                // Bind the main grid and other initializations
                BindBooksGrid();
                popupCart.ShowOnPageLoad = false;
                ASPxPopupContent.ShowOnPageLoad = false;
                BindPopupGrid(Request.QueryString["userId"]); // Assuming this is for initializing popup grid data

            }
        }

        // when i delete from Order table should i also delete from orderList table ....

        protected void btnActionDelete_Click(object sender, EventArgs e)
        {
            // Determine the row index of the button clicked
            var button = (sender as ASPxButton);
            var container = button.NamingContainer as GridViewDataItemTemplateContainer;
            int visibleIndex = container.VisibleIndex;

            
            List<Product> dataSource = ViewState["DataSource"] as List<Product>;
            int orderId = dataSource[visibleIndex].orderId;


            Session session = XpoDefault.Session;
            Order order = session.GetObjectByKey<Order>(orderId);
            if (order != null)
            {
                order.Delete();
            }
            Response.Redirect(Request.RawUrl);



        }





        protected void btnAccept_Click(object sender, EventArgs e)
        {
            // Handle accept button click
            // Example: You can access the OrderId using gridOrders.GetRowValues and perform your logic
        }
        protected void BindPopupGrid(string userId)
        {
            int userIdInt;
            if (!int.TryParse(userId, out userIdInt))
            {
           
                return;
            }

            Session session = XpoDefault.Session;

            if (session == null)
            {
                session = new Session();
                XpoDefault.Session = session;
            }

            XPCollection<Order> ordersCollection = new XPCollection<Order>(session);

           
            ordersCollection.Criteria = CriteriaOperator.Parse("CustomerId = ?", userIdInt);

            var dataSource = ordersCollection.Select(order => new Product
            {
                orderId = order.Id,
                Price = order.TotalPrice,
                Date = order.Date,
                Status = order.Status
            }).ToList();


            ViewState["DataSource"] = dataSource;
            gridProducts.DataSource = dataSource;
            gridProducts.DataBind();
        }


        protected void gridProducts_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "Cancel")
            {
                popupCart.ShowOnPageLoad = false; 
            }
        }

        // to delete one of my orders from the first popup
 


        protected void ASPxok1_Click(object sender, EventArgs e)
        {
            popupCart.ShowOnPageLoad = true;
        }

        protected void ASPEmp1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            ASPxButton button = sender as ASPxButton;
            if (button != null)
            {
                string orderId = button.CommandArgument;
                orderID = orderId.Trim();
                BindContentGrid(orderId);

                // Response.Redirect($"ShowOrderContent.aspx?orderId={orderId}");

            }
        //    ASPxPopupContent.Width = Unit.Pixel(800);
            ASPxPopupContent.ShowOnPageLoad = true;
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
              
                booksCollection = new XPCollection<Book>(session);
            }
            else
            {
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

        // from OOMM
        private void InitializeSession()
        {
            _session = XpoDefault.Session;
            if (_session == null)
            {
                _session = new Session();
                XpoDefault.Session = _session;
            }

        }



        protected void BindContentGrid(string orderId)
        {
            Session session = XpoDefault.Session;

            if (session == null)
            {
                session = new Session();
                XpoDefault.Session = session;
            }




            if (!int.TryParse(orderId, out int orderIdInt))
            {
                // Handle invalid orderId input
                return;
            }

            // Get order date
            XPCollection<Order> orders = new XPCollection<Order>(session, new BinaryOperator("Id", orderIdInt));
            Order order = orders.FirstOrDefault();

            XPQuery<orderList> query = new XPQuery<orderList>(session);
            List<orderList> orderLists = query.Where(o => o.OrderId == orderIdInt).ToList();
            List<orderContent> orderContentList = new List<orderContent>();

            orderLists.ForEach(o =>
            {
                int bookId = o.BookId;
                XPCollection<Book> books = new XPCollection<Book>(session, new BinaryOperator("Id", bookId));
                Book book = books.FirstOrDefault();

                orderContent orderContent = new orderContent
                {
                    BookId = bookId,
                    Name = book.Title,
                    Price = book.Price,
                    Quantity = o.Quantity,
                    Date = order.Date
                };
                orderContentList.Add(orderContent);
            });

            // Bind the dataSource to the gridOrders
            ViewState["DataSource"] = orderContentList;
            gridOrders.DataSource = orderContentList;
            gridOrders.DataBind();
        }


        protected void btnIncrease_Click(object sender, EventArgs e)
        {
            Session session = XpoDefault.Session;

            if (session == null)
            {
                session = new Session();
                XpoDefault.Session = session;
            }


            ASPxButton button = sender as ASPxButton;
            if (button != null)
            {
                string orderId = button.CommandArgument;
              

            if (!int.TryParse(orderId, out int orderIdInt))
            {
                // Handle invalid orderId input
                return;
            }

            // Fetch the order from the database using orderId
            var order = session.GetObjectByKey<orderList>(orderIdInt);
            if (order != null)
            {
                order.Quantity += 1; // Increase quantity
                    session.Save(order);
            }

                // Rebind the grid to reflect changes
                BindContentGrid(orderId);


            }
        }

        protected void btnDecrease_Click(object sender, EventArgs e)
        {
            Session session = XpoDefault.Session;

            if (session == null)
            {
                session = new Session();
                XpoDefault.Session = session;
            }


            ASPxButton button = sender as ASPxButton;
            if (button != null)
            {
                string orderId = button.CommandArgument;

                if (!int.TryParse(orderId, out int orderIdInt))
            {
                // Handle invalid orderId input
                return;
            }

            // Fetch the order from the database using orderId
            var order = session.GetObjectByKey<orderList>(orderIdInt);
            if (order != null && order.Quantity > 0)
            {
                order.Quantity -= 1; // Decrease quantity
                    session.Save(order);
            }

                // Rebind the grid to reflect changes
                BindContentGrid(orderId);


            }
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

        [Serializable]
        public class Product
        {
            public int orderId { get; set; }
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }

        }
        [Serializable]
        public class orderContent
        {
            public int BookId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
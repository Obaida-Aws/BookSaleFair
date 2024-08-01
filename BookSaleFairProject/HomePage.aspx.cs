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
        public string createdOrderId;
        protected void Page_Load(object sender, EventArgs e)
        {
          //  if (!IsPostBack)
          //  {

                if (Request.QueryString["userId"] != null)
                {
                    string userId = Request.QueryString["userId"];
                    GetFirstName(userId);

                    string userType = Request.QueryString["userType"];


                    if (userType == "user")
                    {
                        ASPxButton2.Visible = false;
                        ASPxButton1.Visible = true;
                        ASPxButton4.Visible = true;
                        btnAdd.Visible = false;

                        



                    }
                    else if (userType == "admin")
                    {
                        ASPxButton3.Visible = true;
                        ASPxButton1.Visible = false;
                        ASPxButton4.Visible = false;
                    }
                    else
                    {
                        ASPxButton2.Visible = true;
                        ASPxButton1.Visible = false;
                        btnAdd.Visible = true;
                        ASPxButton4.Visible = false;
                    }
                }


                BindBooksGrid();
                popupCart.ShowOnPageLoad = false;
                ASPxPopupContent.ShowOnPageLoad = false;
                BindPopupGrid(Request.QueryString["userId"]);
           // }
        }

       







        protected void btnActionDelete_Click(object sender, EventArgs e)
        {
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





        protected void btnCancel_Click(object sender, EventArgs e)
        {
        }

        protected void ASPxCreate_Click(object sender, EventArgs e)
        {
            int customerId = (int?)ViewState["CustomerId"] ?? 0;
            string customerName = ViewState["FirstCustomerName"] as string;

            if (customerId == 0 || string.IsNullOrEmpty(customerName))
            {
                Response.Write("Customer information is not available.");
                return;
            }

            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Order newOrder = new Order(uow)
                    {
                        CustomerId = customerId,
                        CustomerName = customerName,
                        TotalPrice = 0,
                        Status = "Pending",
                        Date = DateTime.Now
                    };

                    uow.Save(newOrder);

                    uow.CommitChanges();

                    int newOrderId = newOrder.Id;

                    Session["createdOrderId"] = newOrderId;

                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred while creating the order: " + ex.Message);
            }
        }


        // for Buy button to add to the orderList table
        protected void btnBuy_Click(object sender, EventArgs e)
        {
            createdOrderId = Session["createdOrderId"]?.ToString();

            if (string.IsNullOrEmpty(createdOrderId))
            {
                Response.Write("Order ID is not available.");
                return;
            }

            Response.Write("new order id -----" + createdOrderId);

            var button = sender as ASPxButton;
            if (button == null)
                return;

            int index;
            if (!int.TryParse(button.CommandArgument, out index))
            {
                Response.Write("Invalid item index.");
                return;
            }

            var dataSource = ViewState["CardsData"] as List<CardData>;

            Response.Write($"DataSource count: {dataSource?.Count}, Index: {index}");

            if (dataSource == null || index < 0 || index >= dataSource.Count)
            {
                Response.Write("Data source is not available or index is out of range.");
                return;
            }

            var selectedProduct = dataSource[index];

            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Response.Write($"Session state before operation: {uow?.Connection?.State}");

                    CriteriaOperator criteria = new BinaryOperator("Id", selectedProduct.ID);
                    XPCollection<Book> booksCollection = new XPCollection<Book>(uow, criteria);
                    bool bookExists = booksCollection.Count > 0;

                    if (!bookExists)
                    {
                        Response.Write("The book ID does not exist.");
                        return;
                    }

               
                    Response.Write($"Session state after query: {uow?.Connection?.State}");

                    orderList newOrderListEntry = new orderList(uow)
                    {
                        BookId = selectedProduct.ID,
                        OrderId = int.Parse(createdOrderId),
                        Quantity = 1
                    };

                    Response.Write($"OrderListEntry state: {newOrderListEntry.BookId}, {newOrderListEntry.OrderId}, {newOrderListEntry.Quantity}");

                    uow.Save(newOrderListEntry);

                    Response.Write($"Session state before committing transaction: {uow?.Connection?.State}");

                    uow.CommitChanges();

                    Response.Write($"Session state after committing transaction: {uow?.Connection?.State}");

                    Response.Redirect(Request.RawUrl);
                }

            }
            catch (InvalidOperationException ex)
            {
                Response.Write("InvalidOperationException occurred while saving the order: " + ex.Message);
                Response.Write("<br/>Stack Trace: " + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred while saving the order: " + ex.Message);
                Response.Write("<br/>Stack Trace: " + ex.StackTrace);
            }
        }


        protected void GetFirstName(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    Response.Write("UserId is not provided.");
                    return;
                }

                int userIdInt;
                if (!int.TryParse(userId, out userIdInt))
                {
                    Response.Write("Invalid userId");
                    return;
                }

                using (Session session = new Session())
                {
                    XPCollection<User> userCollection = new XPCollection<User>(session, new BinaryOperator("Id", userIdInt));
                    var user = userCollection.FirstOrDefault();

                    if (user == null)
                    {
                        Response.Write("User not found");
                        return;
                    }

                    // Store customer information in ViewState
                    ViewState["FirstCustomerName"] = user.FirstName;
                }
            }
            catch (InvalidOperationException ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                Response.Write("An unexpected error occurred: " + ex.Message);
            }
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


            var customer = session.Query<Customer>().FirstOrDefault(c => c.UserId == userIdInt);

            if (customer != null)
            {
                // Store customer information in ViewState
                ViewState["CustomerId"] = customer.Id;
               


                ordersCollection.Criteria = CriteriaOperator.Parse("CustomerId = ?", customer.Id);
                var dataSource = ordersCollection.Select(order => new Product
                {
                    orderId = order.Id,
                    Price = order.TotalPrice,
                    Date = order.Date,
                    Status = order.Status,
                    CustomerName = order.CustomerName
                }).ToList();


                // Store all CustomerNames in ViewState
                var customerNames = dataSource.Select(p => p.CustomerName).Distinct().ToList();
                ViewState["CustomerNames"] = customerNames;

                if (customerNames.Any())
                {
                    ViewState["FirstCustomerName"] = customerNames.First();
                }


                // Store Status values in ViewState
                var statuses = dataSource.Select(p => p.Status).Distinct().ToList();
                ViewState["Statuses"] = statuses;

                ViewState["DataSource"] = dataSource;
                gridProducts.DataSource = dataSource;
                gridProducts.DataBind();
            }
        }


        protected void gridProducts_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "Cancel")
            {
                popupCart.ShowOnPageLoad = false;
            }
        }




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
                ViewState["orderID"] = orderID;
                BindContentGrid(orderId);



            }
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

        // oakdp mcoam lkcamd lkmclk 

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

            var dataSource = ViewState["CardsData"] as List<CardData>;
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

            if (string.IsNullOrEmpty(bookType) || bookType == "All")
            {

                booksCollection = new XPCollection<Book>(session);
            }
            else
            {
                booksCollection = new XPCollection<Book>(session, CriteriaOperator.Parse("Type = ?", bookType));
            }

            var dataSource = booksCollection.Select(book => new CardData
            {
                ID = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                ImageUrl = string.IsNullOrEmpty(book.ImageName) ? null : $"/Books_Images/{book.ImageName}"
            }).ToList();

            ViewState["CardsData"] = dataSource;

            ASPxCardView1.DataSource = dataSource;
            ASPxCardView1.DataBind();
        }

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
                return;
            }

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

            ViewState["DataSource"] = orderContentList;
            gridOrders.DataSource = orderContentList;
            gridOrders.DataBind();
        }


        protected void btnIncrease_Click(object sender, EventArgs e)
        {
            InitializeSession();

            if (ViewState["orderID"] != null)
            {
                orderID = ViewState["orderID"].ToString();

                ASPxButton button = sender as ASPxButton;
                if (button != null)
                {
                    string bookIdStr = button.CommandArgument;
                    if (int.TryParse(bookIdStr, out int bookId))
                    {
                        var orderContent = _session.Query<orderList>().FirstOrDefault(o => o.BookId == bookId && o.OrderId == int.Parse(orderID));
                        if (orderContent != null && orderContent.Quantity > 0)
                        {
                            orderContent.Quantity += 1;
                            _session.Save(orderContent);
                        }

                        BindContentGrid(orderID);
                    }
                    else
                    {
                        Response.Write("Invalid bookId");
                    }
                }
            }
            else
            {

                Response.Write("orderID is null or empty");
            }
        }



        protected void btnDecrease_Click(object sender, EventArgs e)
        {
            InitializeSession();

            if (ViewState["orderID"] != null)
            {
                orderID = ViewState["orderID"].ToString();

                ASPxButton button = sender as ASPxButton;
                if (button != null)
                {
                    string bookIdStr = button.CommandArgument;
                    if (int.TryParse(bookIdStr, out int bookId))
                    {
                        var orderContent = _session.Query<orderList>().FirstOrDefault(o => o.BookId == bookId && o.OrderId == int.Parse(orderID));
                        if (orderContent != null && orderContent.Quantity > 0)
                        {
                            orderContent.Quantity -= 1;
                            _session.Save(orderContent);
                        }

                        BindContentGrid(orderID);
                    }
                    else
                    {
                        Response.Write("Invalid bookId");
                    }
                }
            }
            else
            {

                Response.Write("orderID is null or empty");
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
            public string CustomerName { get; set; }

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
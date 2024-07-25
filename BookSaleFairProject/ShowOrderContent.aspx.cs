using BookSaleFairProject.DataBase;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookSaleFairProject
{
    public partial class ShowOrderContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBooksGrid();
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            // Handle accept button click
            // Example: You can access the OrderId using gridOrders.GetRowValues and perform your logic
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            // Handle reject button click
            // Example: You can access the OrderId using gridOrders.GetRowValues and perform your logic
        }

        protected void BindBooksGrid()
        {
            Session session = XpoDefault.Session;

            if (session == null)
            {
                session = new Session();
                XpoDefault.Session = session;
            }

            XPCollection<Order> ordersCollection = new XPCollection<Order>(session);


            // Convert XPCollection to List<Order>
            var dataSource = ordersCollection.Select(order => new orderContent
            {
                OrderId = order.Id,
                Name = order.CustomerName,
                Price = order.TotalPrice,
                Date = order.Date,
                Status = order.Status
            }).ToList();

            // Bind the dataSource to the gridOrders
            ViewState["DataSource"] = dataSource;
            gridOrders.DataSource = dataSource;
            gridOrders.DataBind();
        }
    }


    [Serializable]
    public class orderContent
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}


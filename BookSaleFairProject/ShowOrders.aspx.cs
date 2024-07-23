using System;
using System.Collections.Generic;
using System.Web.UI;
using DevExpress.Web;

namespace BookSaleFairProject
{
    public partial class ShowOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create dummy data for orders
                List<Order> orders = new List<Order>
                {
                    new Order { OrderId = 1, Name = "John Doe", Price = 100.50m, Date = new DateOnly(2024, 7, 23) },
                    new Order { OrderId = 2, Name = "Jane Smith", Price = 75.25m, Date = new DateOnly(2024, 7, 22) },
                    new Order { OrderId = 3, Name = "Mike Johnson", Price = 150.75m, Date = new DateOnly(2024, 7, 21) }
                    // Add more dummy data as needed
                };

                // Bind the list to the ASPxGridView
                gridOrders.DataSource = orders;
                gridOrders.DataBind();
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
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateOnly Date { get; set; }
    }
}

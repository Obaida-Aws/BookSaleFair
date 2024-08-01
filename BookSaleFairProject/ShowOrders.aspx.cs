using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using System.Web.UI;
using BookSaleFairProject.DataBase;
using DevExpress.Web;
using DevExpress.Xpo;
using System.Web.UI.WebControls;

namespace BookSaleFairProject
{
    public partial class ShowOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  if (!IsPostBack)
          //  {
                BindBooksGrid();
          //  }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            ASPxButton btn = sender as ASPxButton;
            int orderId = int.Parse(btn.CommandArgument);
            UpdateOrderStatus(orderId, "Accepted");
            BindBooksGrid(); // Refresh the grid to reflect the changes
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            ASPxButton btn = sender as ASPxButton;
            int orderId = int.Parse(btn.CommandArgument);
            UpdateOrderStatus(orderId, "Rejected");
            BindBooksGrid();
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

            var dataSource = ordersCollection.Select(order => new myOrder
            {
                OrderId = order.Id,
                Name = order.CustomerName,
                Price = order.TotalPrice,
                Date = order.Date,
                Status = order.Status
            }).ToList();

            ViewState["DataSource"] = dataSource;
            gridOrders.DataSource = dataSource;
            gridOrders.DataBind();
        }

        protected void UpdateOrderStatus(int orderId, string newStatus)
        {
            Session session = XpoDefault.Session;
            if (session == null)
            {
                session = new Session();
                XpoDefault.Session = session;
            }

            Order order = session.GetObjectByKey<Order>(orderId);
            if (order != null)
            {
                order.Status = newStatus;
                order.Save();
                session.Save(order);
            }
        }

        protected void gridOrders_HtmlRowPrepared
            (object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data)
                return;

            var status = e.GetValue("Status")?.ToString();

            var acceptButton = gridOrders.FindRowCellTemplateControl(e.VisibleIndex, null, "Accept") as ASPxButton;
            var rejectButton = gridOrders.FindRowCellTemplateControl(e.VisibleIndex, null, "Reject") as ASPxButton;

            if (status == "Accepted")
            {
                if (acceptButton != null)
                {
                    acceptButton.Visible = false;
                }
                if (rejectButton != null)
                {
                    rejectButton.Visible = false;
                }
            }
            else if (status == "Rejected")
            {
                if (rejectButton != null)
                {
                    rejectButton.Visible = false;
                }
                if (acceptButton != null)
                {
                    acceptButton.Visible = false;
                }
            }
        }
    }

    [Serializable]
    public class myOrder
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}

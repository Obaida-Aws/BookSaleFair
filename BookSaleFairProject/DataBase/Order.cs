using DevExpress.Xpo;
using System;

namespace BookSaleFairProject.DataBase
{
    [Persistent("Orders")]
    public class Order : XPLiteObject
    {
        public Order() : base() { }

        public Order(Session session) : base(session) { }

        [Persistent("id")]
        [Key(true)]
        private int id;
        public int Id
        {
            get { return id; }
        }


        private DateTime date;
        [Persistent("date")]
        public DateTime Date
        {
            get { return date; }
            set { SetPropertyValue(nameof(Date), ref date, value); }
        }



        private decimal totalPrice;
        [Persistent("totalPrice")]
        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { SetPropertyValue(nameof(TotalPrice), ref totalPrice, value); }
        }


        private int customerId;
        [Persistent("customerId")]
        public int CustomerId
        {
            get { return customerId; }
            set { SetPropertyValue(nameof(CustomerId), ref customerId, value); }
        }



        private string customerName;
        [Persistent("customerName")]
        public string CustomerName
        {
            get { return customerName; }
            set { SetPropertyValue(nameof(CustomerName), ref customerName, value); }
        }


        private string status;
        [Persistent("status")]
        public string Status
        {
            get { return status; }
            set { SetPropertyValue(nameof(Status), ref status, value); }
        }


        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }




    }

}
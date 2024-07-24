using DevExpress.Xpo;
using System;

namespace BookSaleFairProject.DataBase
{
    [Persistent("orderList")]
    public class orderList : XPObject
    {
        public orderList() : base() { }

        public orderList(Session session) : base(session) { }

        [Persistent("id")]
        [Key(true)]
        private int id;
        public int Id
        {
            get { return id; }
        }


        private int bookId;
        [Persistent("bookId")]
        public int BookId
        {
            get { return bookId; }
            set { SetPropertyValue(nameof(BookId), ref bookId, value); }
        }


        private int orderId;
        [Persistent("orderId")]
        public int OrderId
        {
            get { return orderId; }
            set { SetPropertyValue(nameof(OrderId), ref orderId, value); }
        }



        private int quantity;
        [Persistent("quantity")]
        public int Quantity
        {
            get { return quantity; }
            set { SetPropertyValue(nameof(Quantity), ref quantity, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }




    }

}
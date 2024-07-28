using DevExpress.Xpo;
using System;

namespace BookSaleFairProject.DataBase
{
    [Persistent("Customers")]

    public class Customer : XPLiteObject
    {
        public Customer() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Customer(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        [Persistent("id")]
        [Key(true)]
        private int id;
        public int Id
        {
            get { return id; }
        }

        private int userId;
        [Persistent("userId")]
        public int UserId
        {
            get { return userId; }
            set { SetPropertyValue(nameof(UserId), ref userId, value); }

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
    }

}
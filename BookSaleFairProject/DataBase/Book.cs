using DevExpress.Xpo;
using System;

namespace BookSaleFairProject.DataBase
{
    [Persistent("Books")]
    public class Book : XPLiteObject
    {
        public Book() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Book(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }
        [Persistent("id")] // This specifies the column name in the database
        [Key(true)]
        private int id;

        public int Id
        {
            get { return id; }
        }

        private string title;
        [Persistent("title")] // This specifies the column name in the database
        public string Title
        {
            get { return title; }
            set { SetPropertyValue(nameof(Title), ref title, value); }
        }

        // author
        private string author;
        [Persistent("author")] // This specifies the column name in the database
        public string Author
        {
            get { return author; }
            set { SetPropertyValue(nameof(Author), ref author, value); }
        }

        private decimal price;
        [Persistent("price")] // This specifies the column name in the database
        public decimal Price
        {
            get { return price; }
            set { SetPropertyValue(nameof(Price), ref price, value); }
        }



        private int count;
        [Persistent("count")] // This specifies the column name in the database
        public int Count
        {
            get { return count; }
            set { SetPropertyValue(nameof(Count), ref count, value); }
        }


        private string description;
        [Persistent("description")] // This specifies the column name in the database
        public string Description
        {
            get { return author; }
            set { SetPropertyValue(nameof(Description), ref description, value); }
        }


        private string type;
        [Persistent("type")] // This specifies the column name in the database
        public string Type
        {
            get { return author; }
            set { SetPropertyValue(nameof(Type), ref type, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
    }


}
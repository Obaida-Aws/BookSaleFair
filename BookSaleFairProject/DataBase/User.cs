using DevExpress.Xpo;
using System;

namespace BookSaleFairProject.DataBase
{
    [Persistent("Users")]
    public class User : XPObject
    {
        public User() : base() { }

        public User(Session session) : base(session) { }

        private string username;
        [Persistent("userName")]
        public string Username
        {
            get { return username; }
            set { SetPropertyValue(nameof(Username), ref username, value); }
        }

        private string password;
        [Persistent("password")]
        public string Password
        {
            get { return password; }
            set { SetPropertyValue(nameof(Password), ref password, value); }
        }


        private string type;
        [Persistent("type")]
        public string Type
        {
            get { return type; }
            set { SetPropertyValue(nameof(Type), ref type, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }

}
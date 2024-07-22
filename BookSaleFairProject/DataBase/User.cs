using DevExpress.Xpo;
using System;

namespace BookSaleFairProject.DataBase
{
    [Persistent("Users")]
    public class User : XPLiteObject
    {
        public User() : base() { }

        public User(Session session) : base(session) { }

        [Persistent("id")]
        [Key(true)]
        private int id; 
        public int Id
        {
            get { return id; }
        }

        private string firstName;
        [Persistent("firstName")]
        public string FirstName
        {
            get { return firstName; }
            set { SetPropertyValue(nameof(FirstName), ref firstName, value); }
        }

        private string lastName;
        [Persistent("lastName")]
        public string LastName
        {
            get { return lastName; }
            set { SetPropertyValue(nameof(LastName), ref lastName, value); }
        }

        private string type;
        [Persistent("type")]
        public string Type
        {
            get { return type; }
            set { SetPropertyValue(nameof(Type), ref type, value); }
        }

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

        private string email;
        [Persistent("email")]
        public string Email
        {
            get { return email; }
            set { SetPropertyValue(nameof(Email), ref email, value); }
        }

        private string gender;
        [Persistent("gender")]
        public string Gender
        {
            get { return gender; }
            set { SetPropertyValue(nameof(Gender), ref gender, value); }
        }


        private string passwordResetToken;
        [Persistent("passwordResetToken")]
        public string PasswordResetToken
        {
            get { return passwordResetToken; }
            set { SetPropertyValue(nameof(PasswordResetToken), ref passwordResetToken, value); }
        }

        private DateTime? passwordResetTokenExpiry;
        [Persistent("passwordResetTokenExpiry")]
        public DateTime? PasswordResetTokenExpiry
        {
            get { return passwordResetTokenExpiry; }
            set { SetPropertyValue(nameof(PasswordResetTokenExpiry), ref passwordResetTokenExpiry, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }

}
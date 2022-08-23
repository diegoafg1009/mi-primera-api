namespace ProyectoFinal.Model
{
    public class User
    {
        private int _userId;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _password;
        private string _email;

        public User()
        {
            _userId = 0;
            _firstName = String.Empty;
            _lastName = String.Empty;
            _userName = String.Empty;
            _password = String.Empty;
            _email = String.Empty;
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }
    }
}
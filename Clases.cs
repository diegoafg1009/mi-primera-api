namespace ProyectoFinal
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
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _lastName = value;
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _userName = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _password = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _email = value;
            }
        }
    }

    public class Product
    {
        private int _productId;
        private string _description;
        private double _purchasePrice;
        private double _salePrice;
        private int _stock;
        private int _userId;

        public Product()
        {
            _productId = 0;
            _description = String.Empty;
            _purchasePrice = 0;
            _salePrice = 0;
            _stock = 0;
            _userId = 0;
        }

        public int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _description = value;
            }
        }

        public double PurchasePrice
        {
            get
            {
                return _purchasePrice;
            }
            set
            {
                if (value > 0)
                    _purchasePrice = value;
            }
        }

        public double SalePrice
        {
            get
            {
                return _salePrice;
            }
            set
            {
                if (value > 0)
                    _salePrice = value;
            }
        }

        public int Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                if (value > 0)
                    _stock = value;
            }
        }

        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
    }


    public class ProductSold
    {
        private int _id;
        private int _productId;
        private int _stock;
        private int _saleId;

        public ProductSold()
        {
            _id = 0;
            _productId = 0;
            _stock = 0;
            _saleId = 0;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }
        public int Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                _stock = value;
            }
        }

        public int SaleId
        {
            get
            {
                return _saleId;
            }
            set
            {
                _saleId = value;
            }
        }
    }

    public class Sale
    {
        private int _saleId;
        private string _comments;

        public Sale()
        {
            _saleId = 0;
            _comments = String.Empty;
        }

        public int SaleId
        {
            get
            {
                return _saleId;
            }
            set
            {
                _saleId = value;
            }
        }

        public string Comments
        {
            get
            {
                if (String.IsNullOrEmpty(_comments))
                    return "Sin comentarios";
                else
                    return _comments;
            }
            set
            {
                _comments = value;

            }
        }
    }
}
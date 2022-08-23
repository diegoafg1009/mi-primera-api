namespace ProyectoFinal.Model
{
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
}

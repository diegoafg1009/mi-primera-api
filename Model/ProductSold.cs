namespace ProyectoFinal.Model
{
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
}

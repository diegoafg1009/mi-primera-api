namespace ProyectoFinal.Model
{
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

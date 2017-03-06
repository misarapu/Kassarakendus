using CashRegister.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.BusinesObjects
{
    public class ProductBO
    {
        private int _productId;
        private string _name;
        private string _code;
        private int _categoryId;
        private decimal _price;
        private int _quantity;
        private string _comment;

        public ProductBO(Product product)
        {
            _productId = product.ProductId;
            _name = product.Name;
            _code = product.Code;
            _categoryId = product.CategoryId;
            _price = product.Price;
            _quantity = product.Quantity;
            _comment = product.Comment;
        }

        public ProductBO()
        {

        }

        public ProductBO Copy()
        {
            return new ProductBO(ParseDomain());
        }
        public int ProductId
        {
            get { return _productId; }
        }

        public string ProductName
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ProductCode
        {
            get { return _code; }
            set{ _code = value; }
        }

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public decimal ProductPrice
        {
            get { return Math.Round(_price, 2); }
            set{ _price = value; }
        }

        public int ProductQuantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string ProductComment
        {
            get{ return _comment; }
            set { _comment = value; }
        }

        public string NameAndPrice
        {
            get { return String.Format("{0}\n{1}€", _name, _price); }
        }

        public Product ParseDomain()
        {
            return new Product
            {
                ProductId = _productId,
                Name = _name,
                Code = _code,
                CategoryId = _categoryId,
                Price = _price,
                Quantity = _quantity,
                Since = DateTime.Now
            };
        }
    }
}

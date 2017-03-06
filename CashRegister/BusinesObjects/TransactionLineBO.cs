using CashRegister.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BusinesObjects
{
    public class TransactionLineBO
    {
        private int _productId;
        private int _transactionId;
        private int _quantity;
        private decimal _salePrice;

        
        public TransactionLineBO(TransactionLine newLine)
        {
            _productId = newLine.ProductId.Value;
            _transactionId = newLine.TransactionId.Value;
            _quantity = newLine.Quantity.Value;
            _salePrice = newLine.SalePrice.Value;
        }

        public int ProductId
        {
            get
            {
                return _productId;
            }
        }

        public int TransactionId
        {
            get
            {
                return _transactionId;
            }

            set
            {
                _transactionId = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = value;
            }
        }

        public decimal SalePrice
        {
            get
            {
                return _salePrice;
            }

            set
            {
                _salePrice = value;
            }
        }

        public TransactionLine ParseDomain()
        {
            return new TransactionLine()
            {
                TransactionId = _transactionId,
                Quantity = _quantity,
                SalePrice = _salePrice,
                ProductId = _productId
            };
        }
    }
}

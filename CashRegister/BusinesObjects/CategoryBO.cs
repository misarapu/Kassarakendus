using CashRegister.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.BusinesObjects
{
    public class CategoryBO
    {
        private int _categoryId;
        private string _name;

        public CategoryBO(Category category)
        {
            _categoryId = category.CategoryId;
            _name = category.Name;
        }

        public CategoryBO()
        {

        }

        public int CategoryId
        {
            get
            {
                return _categoryId;
            }
        }

        public string CategoryName
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public Category ParseDomain()
        {
            return new Category
            {
                CategoryId = _categoryId,
                Name = _name
            };
        }
    }
}

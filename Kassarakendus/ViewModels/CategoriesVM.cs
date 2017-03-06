using CashRegister.Services;
using Kassarakendus.BusinesObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassarakendus.ViewModels
{
    public class CategoriesVM : BaseVM
    {
        public List<CategoryBO> _categories;
        private CategoryBO _selectedCategory;

        /// <summary>
        /// ViewModel konstruktor.
        /// </summary>
        public CategoriesVM()
        {
            _categories = new List<CategoryBO>();
            _selectedCategory = new CategoryBO();
        }

        public CategoryBO SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; }
        }

        /// <summary>
        /// Laeb kategooriate loendi.
        /// </summary>
        public void LoadCategories()
        {
            Categories = StorageService.GetAllCategories();
        }

        /// <summary>
        /// Property, mis tagastab ja väärtustab kategooriate loendi.
        /// </summary>
        public List<CategoryBO> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                base.NotifyPropertyChanged("Categories");
            }
        }
    }
}

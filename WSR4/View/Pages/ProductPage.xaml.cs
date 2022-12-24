using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WSR4.AppDataFiles;
using WSR4.View.Pages.Cart;

namespace WSR4.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page, INotifyPropertyChanged
    {
        public ProductPage()
        {
            InitializeComponent();
            DataContext= this;

            LoadData();

            CheckAdmin();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] String prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private int _countCart;

        public int CountCart
        {
            get => _countCart;

            set
            {
                _countCart = value;
                OnPropertyChanged();
            }
        }

        public void LoadData()
        {
            var products = ConnectOdb.wsr4.Product.ToList();

            var types = ConnectOdb.wsr4.ProductCategory.ToList();

            types.Insert(0, new ProductCategory()
            {
                Title = "Все"
            });

            cbType.ItemsSource = types;

            cbType.SelectedIndex = 0;

            ListProduct.ItemsSource = products;

        }

        private void UpdateData()
        {
            if (cbType.SelectedIndex == 0)
            {
                var currentProducts = ConnectOdb.wsr4.Product.OrderBy(x => x.ProductCost).ToList();

                ListProduct.ItemsSource = currentProducts;
            }

            if (cbType.SelectedIndex == 1)
            {
                var currentProducts = ConnectOdb.wsr4.Product.OrderByDescending(x => x.ProductCost).ToList();

                ListProduct.ItemsSource = currentProducts;
            }
        }

        private void CheckAdmin()
        {
            if (!Admin.isAdmin)
                tbVisibility.Text = "Hidden";
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ConnectOdb.wsr4.Product.Remove(((Button)sender).DataContext as Product);

            try
            {
                ConnectOdb.wsr4.SaveChanges();

                MessageBox.Show("Удалено!");


                var products = ConnectOdb.wsr4.Product.ToList();

                ListProduct.ItemsSource = products;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удачно!");
            }
        }

        private void btnChange_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangeProductPage(((Button)sender).DataContext as Product));
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void btnAddInCart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CountCart += 1;

            AppDataFiles.Cart.products.Add(((Button)sender).DataContext as Product);
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage() );
        }
    }
}

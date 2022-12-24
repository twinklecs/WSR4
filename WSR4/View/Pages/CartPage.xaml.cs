using System.Windows;
using System.Windows.Controls;
using WSR4.AppDataFiles;

namespace WSR4.View.Pages.Cart
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();

            LoadData();
        }

        public void LoadData()
        {
            var carts = AppDataFiles.Cart.products;

            for (int i = 0; i < carts.Count; i++)
            {
                ListProduct.Items.Add(carts[i]);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AppDataFiles.Cart.products.Remove(((Button)sender).DataContext as Product);

            ListProduct.Items.Clear();

            LoadData();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateOrderPage(((Button)sender).DataContext as Order));
        }
    }
}

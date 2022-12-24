using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WSR4.AppDataFiles;

namespace WSR4.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();

            var types = ConnectOdb.wsr4.ProductCategory.ToList();

            cbProductCategory.ItemsSource = types;

            var manufactures = ConnectOdb.wsr4.ProductManufacture.ToList();

            cbProductManufacturer.ItemsSource = manufactures;

            var status = ConnectOdb.wsr4.ProductStatus.ToList();

            cbProductStatus.ItemsSource = status;
        }

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Product product = new Product()
            {
                ProductArticleNumber = tbArticul.Text,
                ProductStatusId = cbProductStatus.SelectedIndex,
                ProductManufacturerId = cbProductManufacturer.SelectedIndex,
                ProductQuantityInStock = Convert.ToInt32(tbProductQuantityInStock.Text),
                ProductStringPhotoPath = tbProductStringPhotoPath.Text,
                ProductCategoryId = cbProductCategory.SelectedIndex,
                ProductName = tbProductName.Text,
                ProductDescription = tbProductDescription.Text,
                ProductDiscountAmount = Convert.ToByte(tbProductDiscountAmount.Text),
                ProductCost = Convert.ToByte(tbProductCost.Text)
            };

            try
            {
                ConnectOdb.wsr4.Product.Add(product);
                ConnectOdb.wsr4.SaveChanges();

                NavigationService.GoBack(); 
            }
            catch(Exception )
            {
                MessageBox.Show("Не удачно!");
            }
        }
    }
}

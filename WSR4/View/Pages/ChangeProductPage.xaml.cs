using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WSR4.AppDataFiles;

namespace WSR4.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangeProductPage.xaml
    /// </summary>
    public partial class ChangeProductPage : Page
    {
        private Product _product;

        public ChangeProductPage(Product product)
        {
            InitializeComponent();

            _product = product;

            PlaceInfo(_product);
        }

        private void PlaceInfo(Product product)
        {
            var types = ConnectOdb.wsr4.ProductCategory.ToList();

            cbProductCategory.ItemsSource = types;
            cbProductCategory.SelectedIndex = product.ProductCategoryId - 1;

            var manufactures = ConnectOdb.wsr4.ProductManufacture.ToList();

            cbProductManufacturer.ItemsSource = manufactures;
            cbProductManufacturer.SelectedIndex = product.ProductManufacturerId - 1;

            var status = ConnectOdb.wsr4.ProductStatus.ToList();

            cbProductStatus.ItemsSource = status;
            cbProductStatus.SelectedIndex = product.ProductStatusId - 1;

            tbArticul.Text = product.ProductArticleNumber;
            tbProductCost.Text = product.ProductCost.ToString();
            tbProductDescription.Text = product.ProductDescription;
            tbProductDiscountAmount.Text = product.ProductDiscountAmount.ToString();
            tbProductName.Text = product.ProductName;
            tbProductQuantityInStock.Text = product.ProductQuantityInStock.ToString();
            tbProductStringPhotoPath.Text = product.ProductStringPhotoPath;

        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
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
                if (product != _product)
                {
                    ConnectOdb.wsr4.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    ConnectOdb.wsr4.SaveChanges();

                    MessageBox.Show("Сохранено!");
                }
                else
                    NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Не удачно!");
            }
        }
    }
}

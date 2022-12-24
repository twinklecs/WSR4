using System.Windows.Controls;
using WSR4.AppDataFiles;

namespace WSR4.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        public CreateOrderPage(Order order)
        {
            InitializeComponent();
        }

        private void PlaceInfo(Order order)
        {
            if (order == null)
            {
                Data.Text = order.OrderDeliveryDate.ToString();
                Composition.Text = order.OrderDeliveryDate.ToString();

                    
            }
        }
    }
}

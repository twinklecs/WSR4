using System.Windows;
using WSR4.View.Pages;

namespace WSR4.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        public MainWin(string currentUsers)
        {
            InitializeComponent();

            frmMain.Navigate(new ProductPage());

            tbCurrentUser.Text = currentUsers;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            frmMain.GoBack();
        }

        private void btnFAQ_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new FaqPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            AuthWin authWin = new AuthWin();
            authWin.Show();

            this.Close();
        }

        private void frmMain_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (frmMain.Content.GetType().Name == "ProductPage")
                btnGoBack.Visibility = Visibility.Hidden;
            else
                btnGoBack.Visibility = Visibility.Visible;
        }
    }
}

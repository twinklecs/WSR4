using System.Linq;
using System.Windows;
using WSR4.AppDataFiles;

namespace WSR4.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWin.xaml
    /// </summary>
    public partial class AuthWin : Window
    {
        public AuthWin()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != "" && tbPass.Text != "")
            {
                var users = ConnectOdb.wsr4.User.ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].UserLogin == tbLogin.Text && users[i].UserPassword == tbPass.Text)
                    {
                        if (users[i].Role.RoleName == "Администратор")
                            Admin.isAdmin = true;

                        MainWin mainWin = new MainWin(users[i].UserSurname + "" + users[i].UserName + "" + users[i].UserPatronymic);
                        mainWin.Show();

                        this.Close();
                    }
                }
            }
            else
                MessageBox.Show("Не все поля заполнены!");
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWin registrationWin = new RegistrationWin();
            registrationWin.Show();

            this.Close();
        }
    }
}

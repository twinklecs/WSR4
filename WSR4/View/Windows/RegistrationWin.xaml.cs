using System;
using System.Linq;
using System.Windows;
using WSR4.AppDataFiles;

namespace WSR4.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWin.xaml
    /// </summary>
    public partial class RegistrationWin : Window
    {
        public RegistrationWin()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != "" &&
                tbPass.Text != "" &&
                tbUserName.Text != "" &&
                tbUserSurname.Text != "" &&
                tbUserPatronymic.Text != "")
            {
                var users = ConnectOdb.wsr4.User.ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    if (tbLogin.Text == users[i].UserLogin)
                    {
                        MessageBox.Show("Такой пользователь уже существует!");
                        return;
                    }
                }

                User user = new User()
                {
                    UserLogin = tbLogin.Text,
                    UserPassword = tbPass.Text,
                    UserName = tbUserName.Text,
                    UserPatronymic = tbUserPatronymic.Text,
                    UserSurname = tbUserSurname.Text,
                    UserRole = 3
                };

                ConnectOdb.wsr4.User.Add(user);
                try
                {
                    ConnectOdb.wsr4.SaveChanges();

                    MessageBox.Show("Успешно!");

                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Неудачно!");
                }
            }
            else
                MessageBox.Show("Не все поля заполнены!");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AuthWin authWin = new AuthWin();
            authWin.Show();
        }
    }
}

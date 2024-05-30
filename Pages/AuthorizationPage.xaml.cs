using NauchnaiConference.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NauchnaiConference.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        // Код предназначеный для обработки логина и пароля пользователя, в последующем успешную авторизацию в систему
        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var UserObj = NauchnaiConferenciiEntities.GetContext().user.FirstOrDefault(x => x.login == txbLogin.Text && x.password == txbPassword.Text);
                if (UserObj == null)
                {
                    MessageBox.Show("Вы уволены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    switch(UserObj.userroleid)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте Заведующим отделения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.UtilsFrame.Navigate(new zavOtdelPage());
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте Организатор", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.UtilsFrame.Navigate(new organizatorPage());
                            break;
                        case 3:
                            MessageBox.Show("Здравствуйте Техник", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.UtilsFrame.Navigate(new technikPage());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString() + "Fatal error", "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

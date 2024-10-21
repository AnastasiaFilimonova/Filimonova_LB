using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик для кнопки "Регистрация" 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
            this.Close();
        }

        // Обработчик для кнопки "Войти" 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = textBox.Text;
            string password = textBox1.Text;
            // Проверка введенных данных с использованием класса InputValidator
            if (!InputValidator.IsValidEmail(email))
            {
                MessageBox.Show("Неверный формат почты! Почта должна быть в формате *@*.*", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!InputValidator.IsValidPassword(password))
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Window2 win2 = new Window2();
            win2.Show();
            this.Close();
        }

        // Класс для проверки корректности ввода
        public static class InputValidator
        {
            public static bool IsValidEmail(string email)
            {

                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern);
            }

            // Метод для проверки пароля (не менее 6 символов)
            public static bool IsValidPassword(string password)
            {
                return password.Length >= 6;
            }
        }

        // Обновление watermark для текстовых полей
        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateWatermark();
        }
        private void UpdateWatermark()
        {
            watermark.Visibility = string.IsNullOrWhiteSpace(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TextBox_TextChanged1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateWatermark1();
        }
        private void UpdateWatermark1()
        {
            watermark1.Visibility = string.IsNullOrWhiteSpace(textBox1.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
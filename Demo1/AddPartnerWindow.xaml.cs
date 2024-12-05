using Demo1.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Windows.Shapes;

namespace Demo1
{
    /// <summary>
    /// Логика взаимодействия для AddPartnerWindow.xaml
    /// </summary>
    public partial class AddPartnerWindow : Window
    {
        Partners _currentPartner;
        public AddPartnerWindow(Partners currentPartner)
        {
            InitializeComponent();
            _currentPartner = currentPartner;
            DataContext = _currentPartner; //Заполнение полей формы данными партнера
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Partners { ID = _currentPartner.ID }; //Очистка полей. Создаем новый DataContext, ID текущего партнера сохраняем.
            _currentPartner = DataContext as Partners; //Сохраняем ссылку на DataContext
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_currentPartner.Title))
                    throw new Exception("Введите название партнера");
                if (_currentPartner.Title.Length > 255)
                    throw new Exception("Название партнера слишком длинное");
                if (string.IsNullOrEmpty(_currentPartner.Type))
                    throw new Exception("Выберите тип партнера");
                if (string.IsNullOrEmpty(_currentPartner.Rating.ToString()))
                    throw new Exception("Введите рейтинг партнера");
                if (!int.TryParse(_currentPartner.Rating.ToString(), out _))
                    throw new Exception("Рейтинг партнера должен быть целым числом"); //Не робит.
                if (string.IsNullOrEmpty(_currentPartner.Address))
                    throw new Exception("Введите адрес партнера");
                if (_currentPartner.Address.Length > 255)
                    throw new Exception("Адрес партнера слишком длинный");
                if (string.IsNullOrEmpty(_currentPartner.Director))
                    throw new Exception("Введите ФИО директора");
                if (_currentPartner.Director.Length < 4)
                    throw new Exception("ФИО директора слишком короткое");
                if (_currentPartner.Director.Length > 255)
                    throw new Exception("ФИО директора слишком длинное");
                if (string.IsNullOrEmpty(_currentPartner.Phone))
                    throw new Exception("Введите телефон партнера");
                if (_currentPartner.Phone.Length < 10 || _currentPartner.Phone.Length > 13)
                    throw new Exception("Телефон партнера должен содержать от 10 до 13 цифр");
                if (_currentPartner.Phone.Any(char.IsLetter))
                    throw new Exception("Телефон партнера не должен содержать буквы");
                if (string.IsNullOrEmpty(_currentPartner.Email))
                    throw new Exception("Введите почту партнера");
                if (_currentPartner.Email.Length > 255)
                    throw new Exception("Email партнера слишком длинный");
                if (!_currentPartner.Email.Contains("@"))
                    throw new Exception("Email введен неверно");
                if (string.IsNullOrEmpty(_currentPartner.INN))
                    throw new Exception("Введите ИНН партнера");
                if (_currentPartner.INN.Length != 10)
                    throw new Exception("ИНН партнера введен неверно");
                if (!_currentPartner.INN.All(char.IsDigit))
                    throw new Exception("ИНН партнера должен содержать только цифры");


                if (MessageBox.Show("Вы точно хотите сохранить?", "Сохранение", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    DemoEntities.GetContext().Partners.AddOrUpdate(_currentPartner); //Добавление либо обновление партнера
                    DemoEntities.GetContext().SaveChanges(); //Сохранение изменений
                    MessageBox.Show("Сохранено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}

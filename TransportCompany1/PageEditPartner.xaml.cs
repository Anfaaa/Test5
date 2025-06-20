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
using Core;
using Core.models;

namespace TransportCompany1
{
    /// <summary>
    /// Логика взаимодействия для PageEditPartner.xaml
    /// </summary>
    public partial class PageEditPartner : Page
    {
        private PartnerRequest _selectedPartner;

        public PageEditPartner(PartnerRequest selectedPartner)
        {
            InitializeComponent();

            _selectedPartner = selectedPartner;

            try
            {
                using (var context = new Context())
                {
                    var partnerTypes = context.PartnerTypes.ToList();
                    TypeComboBox.ItemsSource = partnerTypes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при получении данных: {ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            NameInput.Text = _selectedPartner.Name;
            TypeComboBox.SelectedValue = _selectedPartner.PartnerTypeId;
            string director = _selectedPartner.DirectorSurname + " " + _selectedPartner.DirectorName + " " + _selectedPartner.DirectorMiddleName;
            DirectorInput.Text = director;
            EmailInput.Text = _selectedPartner.Email;
            PhoneInput.Text = _selectedPartner.Phone;
            AddressInput.Text = _selectedPartner.Address;
            RatingInput.Text = _selectedPartner.Rating.ToString();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Наименование обязательно, заполните это поле.", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int type = (int)TypeComboBox.SelectedValue;

            string director = DirectorInput.Text;
            string[] directorFullName = director.Split(' ');

            if (directorFullName.Length < 2 && directorFullName.Length > 3)
            {
                MessageBox.Show("Имя, фамилия и отчество (при наличии) являются обязательными данными.", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string email = EmailInput.Text;
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email должен быть в формате [example@mail.com]", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string phone = PhoneInput.Text;
            if (phone.Length != 13)
            {
                MessageBox.Show("Номер телефона должен быть в формате [XXX XXX XX XX]", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string address = AddressInput.Text;
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Адрес обязателен, заполните это поле.", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int rating;

            try
            {
                rating = int.Parse(RatingInput.Text);
                if (rating < 0)
                {
                    MessageBox.Show("Рейтинг должен быть положительным числом.", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Рейтинг должен быть положительным целым числом.", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new Context())
                {
                    var partner = context.PartnerRequests.FirstOrDefault(p => p.Id == _selectedPartner.Id);

                    if (partner != null)
                    {
                        partner.Name = name;
                        partner.DirectorSurname = directorFullName[0];
                        partner.DirectorName = directorFullName[1];
                        partner.DirectorMiddleName = directorFullName.Length == 3 ? directorFullName[2] : null;
                        partner.Email = email;
                        partner.Phone = phone;
                        partner.Address = address;
                        partner.Rating = rating;
                        partner.PartnerTypeId = type;

                        context.SaveChanges();

                        MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new PageRequestsList());
                    }
                    else MessageBox.Show($"Произошла ошибка при сохранении  данных, партнер не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении данных: {ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRequestsList());
        }
    }
}

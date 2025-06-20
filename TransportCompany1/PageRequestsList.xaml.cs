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
using Microsoft.EntityFrameworkCore;

namespace TransportCompany1
{
    /// <summary>
    /// Логика взаимодействия для PageRequestsList.xaml
    /// </summary>
    public partial class PageRequestsList : Page
    {
        public PageRequestsList()
        {
            InitializeComponent();

            try
            {
                using (var context = new Context())
                {
                    var partners = context.PartnerRequests
                        .Include(p => p.PartnerType)
                        .Include(p => p.RequestProduct)
                        .ThenInclude(rp => rp.Product).ToList();
                    PartnersListView.ItemsSource = partners;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при получении данных: {ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PartnersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PartnersListView.SelectedItem != null)
            {
                var selectedPartner = PartnersListView.SelectedItem as PartnerRequest;
                NavigationService?.Navigate(new PageEditPartner(selectedPartner));
            }
            else
            {
                MessageBox.Show("Выберете партнера для изменения", "Выберете партнера", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void SaleHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var partner = (PartnerRequest)button.DataContext;

            NavigationService?.Navigate(new PageRequestProducts(partner));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new PageAddPartner());
        }
    }
}

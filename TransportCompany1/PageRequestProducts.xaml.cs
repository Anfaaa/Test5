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
using Microsoft.EntityFrameworkCore;
using Core;
using Core.models;

namespace TransportCompany1
{
    /// <summary>
    /// Логика взаимодействия для PageRequestProducts.xaml
    /// </summary>
    public partial class PageRequestProducts : Page
    {

        private PartnerRequest _selectedPartner;

        public PageRequestProducts(PartnerRequest selectedPartner)
        {
            InitializeComponent();

            _selectedPartner = selectedPartner;

            try
            {
                using (var context = new Context())
                {
                    var products = context.RequestsProducts
                        .Include(rp => rp.Product)
                        .Where(rp => rp.PartnerRequestId == _selectedPartner.Id)
                        .ToList();

                    PartnerProductsListView.ItemsSource = products;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при получении данных: {ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRequestsList());
        }
    }
}

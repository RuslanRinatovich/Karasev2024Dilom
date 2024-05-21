using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfAssortmentCheck.Models;
using WpfAssortmentCheck.Windows;

namespace WpfAssortmentCheck.Pages
{
    /// <summary>
    /// Логика взаимодействия для SellPage.xaml
    /// </summary>
    public partial class SellPage : Page
    {
        public SellPage(Service service)
        {
            InitializeComponent();
            LoadData(service);

        }
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }


        // загрузка данных в DataGrid и ComboBox
        void LoadData(Service service)
        {
            DtData.ItemsSource = AutoTuningBDEntities.GetContext().ServiceOrders.Include(p => p.Order).Where(p => p.ServiceId == service.Id).OrderBy(p => p.Order.DateStart).ToList();
            ComboGoods.ItemsSource = AutoTuningBDEntities.GetContext().Services.OrderBy(p => p.Name).ToList(); ;
            ComboGoods.SelectedIndex = 0;
            ComboGoods.SelectedValue = service.Id;
            GridGood.DataContext = service;
        }
        // фильтрация продаж по товару
        private void ComboGoodsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboGoods.SelectedIndex >= 0)
            {
                int goodId = Convert.ToInt32(ComboGoods.SelectedValue);
                var x = AutoTuningBDEntities.GetContext().ServiceOrders.Include(p => p.Order).Where(p => p.ServiceId == goodId).OrderBy(p => p.Order.DateStart).ToList();
                DtData.ItemsSource = x;
                GridGood.DataContext = ComboGoods.SelectedItem;
            }
        }

     

        }
    }

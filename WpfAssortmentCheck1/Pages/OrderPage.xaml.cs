using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using WpfAssortmentCheck.Pages;
using WpfAssortmentCheck.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfAssortmentCheck.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        List<Order> rents;
        User _currentUser;
        public OrderPage()
        {
            InitializeComponent();
            _currentUser = Manager.CurrentUser;
            LoadData();
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // открытие редактирования товара
            // передача выбранного товара в AddGoodPage
            Manager.MainFrame.Navigate(new AddNewOrderPage((sender as Button).DataContext as Order));
        }


        void LoadData()

        {
            if (_currentUser.Role == true)
            {
                DataGridGood.ItemsSource = null;
                DataGridGood.Columns[8].Visibility = Visibility.Collapsed;
                //загрузка обновленных данных
                AutoTuningBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                rents = AutoTuningBDEntities.GetContext().Orders.OrderBy(p => p.DateStart).ToList();
                DataGridGood.ItemsSource = rents;
            }
            else
            {
                BtnStatus.Visibility = Visibility.Collapsed;
                DataGridGood.Columns[7].Visibility = Visibility.Collapsed;
                DataGridGood.ItemsSource = null;
                //загрузка обновленных данных
                AutoTuningBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                rents = AutoTuningBDEntities.GetContext().Orders.Where(x => x.Username == _currentUser.UserName).OrderBy(p => p.DateStart).ToList();
                DataGridGood.ItemsSource = rents;
            }
        }
        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //событие отображения данного Page
            // обновляем данные каждый раз когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                LoadData();
            }
        }



        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            // открытие  AddGoodPage для добавления новой записи
            Manager.MainFrame.Navigate(new AddNewOrderPage(null));
        }

        private void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары
            var selectedGoods = DataGridGood.SelectedItems.Cast<Order>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()} записей???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                    Order x = selectedGoods[0];
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                   

                    // удаляем товара
                    AutoTuningBDEntities.GetContext().Orders.Remove(x);
                    //сохраняем изменения
                    AutoTuningBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
   

        private void BtnSellClick(object sender, RoutedEventArgs e)
        {
            // открытие страницы о продажах SellGoodsPage
            // передача в него выбранного товара
            //Manager.MainFrame.Navigate(new SellGoodsPage((sender as Button).DataContext as Order));
        }
        // отображение номеров строк в DataGrid
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnStatus_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StatusPage());
        }

        private void BtnLook_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddNewOrderPage((sender as Button).DataContext as Order));
        }
    }
}


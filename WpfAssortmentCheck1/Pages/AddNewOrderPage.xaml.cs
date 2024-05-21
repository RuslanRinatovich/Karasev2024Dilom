using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfAssortmentCheck.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewOrderPage.xaml
    /// </summary>
    public partial class AddNewOrderPage : Page
    {
        //текущий товар
        private Order _currentItem = new Order();
        public struct BuyItem
        {
            public int Count { get; set; }
            public double Total { get; set; }
      
        }

        //public string GetPhoto
        //{
        //    get
        //    {
        //        if (Photo is null)
        //            return null;
        //        return System.IO.Directory.GetCurrentDirectory() + @"\Images\" + Photo.Trim();
        //    }
        //}
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public double Price { get; set; }
        //public int CategoryId { get; set; }
        //public string Photo { get; set; }

        public static Dictionary<Service, BuyItem> buyServices = new Dictionary<Service, BuyItem>();
        string _userName = "";
        public AddNewOrderPage(Order selected)
        {
            InitializeComponent();
            buyServices.Clear();
            _currentItem = selected;
            CmbCategory.ItemsSource = AutoTuningBDEntities.GetContext().Categories.ToList();
            CmbCategory.SelectedIndex = -1;
            ComBoBrand.ItemsSource = AutoTuningBDEntities.GetContext().Brands.ToList();
            ComboStatus.ItemsSource = AutoTuningBDEntities.GetContext().Status.ToList();
            lbClient.ItemsSource = AutoTuningBDEntities.GetContext().Users.ToList();
            PreparingData();
            //ComboStatus.SelectedIndex = 0;
            LoadData();

        }
        void PreparingData()
        {


            // если это окно открыл пользователь в режиме добавления новой записи
            if ((Manager.CurrentUser.Role != true) &&(_currentItem == null))
            {
                _userName = Manager.CurrentUser.UserName;
                btnAddService.Visibility = Visibility.Visible;
                ComboStatus.SelectedIndex = 1;
                btnLoadClient.Visibility = Visibility.Hidden;
                ComboStatus.Visibility = Visibility.Collapsed;
                tbClient.Text = Manager.CurrentUser.GetInfo;
               _currentItem = new Order();
               _currentItem.DateStart = DateTime.Today;
               _currentItem.DateEnd = DateTime.Today;
                btnExcel.Visibility = Visibility.Collapsed;
                _currentItem.StatusId = 1;
               _currentItem.Username = Manager.CurrentUser.UserName;
                btnCancel.Visibility = Visibility.Collapsed;
                DataContext = _currentItem;
                ComboStatus.SelectedIndex = 0;
                return;

            }
            // если это окно открыл пользователь в режиме просмотра записи
            if ((Manager.CurrentUser.Role != true) && (_currentItem != null))
            {
                //  MessageBox.Show("2");
                btnAddService.Visibility = Visibility.Hidden;
                
                _userName = Manager.CurrentUser.UserName;
                btnLoadClient.Visibility = Visibility.Hidden;
                ComboStatus.IsEnabled = false;
                tbClient.Text = Manager.CurrentUser.GetInfo;
                btnExcel.Visibility = Visibility.Visible;
                DtOrderPriceList.Columns[5].Visibility = Visibility.Collapsed;
                DtOrderPriceList.Columns[6].Visibility = Visibility.Visible;
                //DtOrderPriceList.Columns[7].Visibility = Visibility.Collapsed;
                DtOrderPriceList.Columns[8].Visibility = Visibility.Collapsed;
                DtOrderPriceList.IsReadOnly = true;
                btnSave.Visibility = Visibility.Collapsed;
                if (_currentItem.StatusId == 1)
                {
                    btnCancel.Visibility = Visibility.Visible;
                }
                else
                    btnCancel.Visibility = Visibility.Collapsed;
                DataContext = _currentItem;
                return;

            }

            if ((Manager.CurrentUser.Role == true) && (_currentItem == null))
            {
                btnLoadClient.Visibility = Visibility.Visible;
                _currentItem = new Order();
                _currentItem.DateStart = DateTime.Today;
                _currentItem.DateEnd = DateTime.Today;
                btnExcel.Visibility = Visibility.Collapsed;
                btnCancel.Visibility = Visibility.Collapsed;
                DataContext = _currentItem;
                return;

            }

            if ((Manager.CurrentUser.Role == true) && (_currentItem != null))
            {
                btnLoadClient.Visibility = Visibility.Visible;
                tbClient.Text = _currentItem.User.GetInfo;
                _userName = _currentItem.User.UserName;
                btnExcel.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Visible;
                DataContext = _currentItem;
                return;

            }

            
        }

        void LoadData()
        {
            if (_currentItem != null)
            {
                List<ServiceOrder> serviceOrders = AutoTuningBDEntities.GetContext().ServiceOrders.Where(p => p.OrderId == _currentItem.Id).ToList();
                List<Service> services = AutoTuningBDEntities.GetContext().Services.ToList();

                foreach (ServiceOrder order in serviceOrders)
                {
                    Service service = services.Where(p => p.Id == order.ServiceId).FirstOrDefault();
                    buyServices[service] = new BuyItem { Count = order.Count, Total = service.Price * order.Count };
                }
                DtOrderPriceList.ItemsSource = buyServices;
                TbTotalPrice.Value = _currentItem.TotalPrice;
            }
            CalculateTotalPrice();
            //
            //    DtOrderPriceList.ItemsSource = AutoTuningBDEntities.GetContext().ServiceOrders.Where(p => p.OrderId == _currentItem.Id).ToList();
        }

        private void btnLoadClient_Click(object sender, RoutedEventArgs e)
        {
            hostLoadClient.IsOpen = true;
        }

        private void btnClientOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbClient.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < lbClient.SelectedItems.Count; i++)
                    {
                        User xair = lbClient.SelectedItems[i] as User;
                        if (xair != null)
                        {
                            _userName = xair.UserName;
                            _currentItem.Username = _userName;
                            tbClient.Text = xair.GetInfo;
                        }
                    }
                }


                //MaterialDesignThemes.Wpf.DialogHost.Show("Запись вфыафыва");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            hostLoadClient.IsOpen = false;
        }

        private void btnClientCancel_Click(object sender, RoutedEventArgs e)
        {
            hostLoadClient.IsOpen = false;
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddServiceHost.IsOpen = true;

        }

        private void btnServiceOK_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (LbPriceList.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < LbPriceList.SelectedItems.Count; i++)
                    {
                        Service x = LbPriceList.SelectedItems[i] as Service;

                        if (x != null)
                        {
                            int id = x.Id;

                          
                            if (buyServices.ContainsKey(x))
                            {
                                int k = buyServices[x].Count + 1;
                                double p = x.Price * k;
                                buyServices[x] = new BuyItem { Count = k, Total = p};
                            }
                            else
                            {
                                int k = 1;
                                double p = x.Price * k;
                                buyServices[x] = new BuyItem { Count = k, Total = p };
                            }
                            DtOrderPriceList.ItemsSource = null;
                            DtOrderPriceList.ItemsSource = buyServices;
                        }
                    }
                }

                CalculateTotalPrice();
                AddServiceHost.IsOpen = false;

                //MaterialDesignThemes.Wpf.DialogHost.Show("Запись вфыафыва");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }

        private void btnServiceCancel_Click(object sender, RoutedEventArgs e)
        {
            AddServiceHost.IsOpen = false;
        }

        void CalculateTotalPrice()
        {

            //if (_currentItem.Id == 0)
            //{
                double total = 0;
                foreach (KeyValuePair<Service, BuyItem> valuePair in buyServices)
                {
                    total += valuePair.Value.Total;
                }
                TbTotalPrice.Value = total;
                if (buyServices.Count == 0)
                {
                    btnSave.IsEnabled = false;
                    btnExcel.IsEnabled = false;
                }
                else
                {
                    btnSave.IsEnabled = true;
                    btnExcel.IsEnabled = true;
                }
            //}

        }
        private void btnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                if (DtOrderPriceList.SelectedIndex >= 0)
                {
                    var x = (DtOrderPriceList.SelectedValue as Service);
                    buyServices.Remove(x);
                    DtOrderPriceList.ItemsSource = null;
                    DtOrderPriceList.ItemsSource = buyServices;
                }
            }
            CalculateTotalPrice();
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {

            PrintExcel();

        }

        private void PrintExcel()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Check" + ".xltx";
            Excel.Application xlApp = new Excel.Application();
            Excel.Worksheet xlSheet = new Excel.Worksheet();
            try
            {
                //добавляем книгу
                xlApp.Workbooks.Open(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing);
                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;
                Excel.Range xlSheetRange;
                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                xlSheet.Name = "Список заявок";
                int row = 13;
                int i = 0;

                xlSheet.Cells[4, 3] = tbOrderId.Text;
                xlSheet.Cells[5, 3] = $"{_currentItem.User.LastName} {_currentItem.User.FirstName} {_currentItem.User.MiddleName}";
                xlSheet.Cells[6, 3] = _currentItem.User.Phone;
                //ServiceName = service.ServiceName,
                //                             DryOrderID = dryorder.DryOrderID,
                //                             OrderID = dryorder.OrderID,
                //                             ServiceID = service.ServiceID,
                //                             DryOrderContent = dryorder.DryOrderContent,
                //                             ServicePrice = dryorder.ServicePrice,
                //                             DryOrderCount = dryorder.DryOrderCount,
                //                             DryOrderPrice = dryorder.DryOrderPrice

                if (buyServices.Count > 0)
                {
                    foreach (KeyValuePair<Service, BuyItem> valuePair in buyServices)
                    {
                        

                        xlSheet.Cells[row, 1] = (i + 1).ToString();
                        // DateTime y = Convert.ToDateTime(dtOrders.Rows[i].Cells[1].Value);
                        xlSheet.Cells[row, 2] = valuePair.Key.Name;
                        xlSheet.Cells[row, 6] = valuePair.Key.Price.ToString();
                        xlSheet.Cells[row, 7] = valuePair.Value.Count.ToString();
                        xlSheet.Cells[row, 8] = valuePair.Value.Total.ToString();
                        //xlSheet.Cells[row, 8] = order.PriceList.Price.ToString();


                        row++;
                        Excel.Range r = xlSheet.get_Range("A" + row.ToString(), "H" + row.ToString());
                        r.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                        Excel.Range x = xlSheet.get_Range("B" + row.ToString(), "E" + row.ToString());
                        x.Merge();
                        i++;
                    }
                }
                row--;
                xlSheetRange = xlSheet.get_Range("A9:H" + (row + 1).ToString(), Type.Missing);
                xlSheetRange.Borders.LineStyle = true;
                row++;
                Excel.Range t = xlSheet.get_Range("A" + row.ToString(), "G" + row.ToString());
                t.Merge();
                xlSheet.Cells[row, 8] = "=SUM(H9:H" + (row - 1).ToString() + ")";
                xlSheet.Cells[row, 1] = "ИТОГО:";
                t = xlSheet.get_Range("A" + row.ToString());
                t.Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                row += 2;
                xlSheet.Cells[row, 3] = $"{_currentItem.User.LastName} {_currentItem.User.FirstName} {_currentItem.User.MiddleName}"; ;
                row++;
                xlSheet.Cells[row, 3] = DateTime.Today.ToShortDateString();
                //выбираем всю область данных*/
                xlSheetRange = xlSheet.UsedRange;
                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;
                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;
            }
        }

        // проверка полей
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentItem.Username))
                s.AppendLine("Выберите клиента");
            if (string.IsNullOrWhiteSpace(_currentItem.Info))
                s.AppendLine("Заполните информацию об автомобиле");
            if (string.IsNullOrWhiteSpace(_currentItem.CarNumber))
                s.AppendLine("Укажите гос номер автомобиля");
            if (ComBoBrand.SelectedIndex == -1)
                s.AppendLine("Выберите бренд");

            //if ((Manager.CurrentUser.Role == false) && (_currentItem.StatusId != 1))
            //{
            //    s.AppendLine("Выберите бренд");
            //}
            return s;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }


            // проверка полей прошла успешно
            if (_currentItem.Id == 0)
            {

                AutoTuningBDEntities.GetContext().Orders.Add(_currentItem);
                try
                {
                    _currentItem.TotalPrice = Convert.ToDouble(TbTotalPrice.Value);
                    AutoTuningBDEntities.GetContext().SaveChanges();
                    int id = _currentItem.Id;
                    _currentItem.Username = _userName;
                    tbOrderId.Text = id.ToString();
                    List<ServiceOrder> orderGoods = new List<ServiceOrder>();
                    double total = 0;
                    foreach (KeyValuePair<Service, BuyItem> valuePair in buyServices)
                    {

                        ServiceOrder orderGood = new ServiceOrder();
                        orderGood.OrderId = id;
                        orderGood.ServiceId = valuePair.Key.Id;
                        orderGood.Count = valuePair.Value.Count;
                        total += valuePair.Value.Total;
                        orderGoods.Add(orderGood);

                    }

                    AutoTuningBDEntities.GetContext().ServiceOrders.AddRange(orderGoods);
                    AutoTuningBDEntities.GetContext().SaveChanges();
                    MessageBox.Show($"Ваш заказ номер {_currentItem.Id} создан"); ;
                    tbOrderId.Visibility = Visibility.Visible;
                    btnExcel.IsEnabled = true;
                    btnSave.Visibility = Visibility.Collapsed;
                    
                    buyServices.Clear();
                    PreparingData();
                    LoadData();
                  
                    // Возвращаемся на предыдущую форму
                    // Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
            else
            {
                _currentItem.TotalPrice = Convert.ToDouble(TbTotalPrice.Value);
                _currentItem.Username = _userName;
                List<ServiceOrder> delItems = AutoTuningBDEntities.GetContext().ServiceOrders.Where(p => p.OrderId == _currentItem.Id).ToList();
                AutoTuningBDEntities.GetContext().ServiceOrders.RemoveRange(delItems);
                List<ServiceOrder> orderGoods = new List<ServiceOrder>();
                double total = 0;
                foreach (KeyValuePair<Service, BuyItem> valuePair in buyServices)
                {

                    ServiceOrder orderGood = new ServiceOrder();
                    orderGood.OrderId =  _currentItem.Id; 
                    orderGood.ServiceId = valuePair.Key.Id;
                    orderGood.Count = valuePair.Value.Count;
                    total += valuePair.Value.Total;
                    orderGoods.Add(orderGood);

                }

                AutoTuningBDEntities.GetContext().ServiceOrders.AddRange(orderGoods);
                AutoTuningBDEntities.GetContext().SaveChanges();


                //AutoTuningBDEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись Изменена");
                PreparingData();
                LoadData();
            }
        }

        private void btnExcel_Click_1(object sender, RoutedEventArgs e)
        {
            PrintExcel();
        }

        private void CmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbCategory.SelectedIndex != -1)
            {
                Category category = (CmbCategory.SelectedItem) as Category;
                LbPriceList.ItemsSource = AutoTuningBDEntities.GetContext().Services.Where(p => p.CategoryId == category.Id).ToList();
            }
            else
            {
                LbPriceList.ItemsSource = null;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var x = (sender as Button).DataContext as Service;
            //Good g = AutoTuningBDEntities.GetContext().Goods.Find(x.Good.Id);
            //MessageBox.Show(x.Name);
            if (buyServices.ContainsKey(x))
            {
                int k = buyServices[x].Count + 1;
                double p = x.Price * k;
                buyServices[x] = new BuyItem { Count = k, Total = p};
                DtOrderPriceList.ItemsSource = null;
                DtOrderPriceList.ItemsSource = buyServices;
            }
            CalculateTotalPrice();
        }

        private void BtnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            var x = (sender as Button).DataContext as Service;
            //Good g = AutoTuningBDEntities.GetContext().Goods.Find(x.Good.Id);
            //MessageBox.Show(x.Name);
            if (buyServices.ContainsKey(x))
            {
                int k = buyServices[x].Count;
                if (k > 0) k--;

                if (k == 0)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить услугу?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    //если пользователь нажал ОК пытаемся удалить запись
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        buyServices.Remove(x);
                       
                        DtOrderPriceList.ItemsSource = null;
                        DtOrderPriceList.ItemsSource = buyServices;
                    }
                    else
                    {
                        k = 1;
                        double p = x.Price * k;
                        buyServices[x] = new BuyItem { Count = k, Total = p };
                        DtOrderPriceList.ItemsSource = null;
                        DtOrderPriceList.ItemsSource = buyServices;
                    }
                }
                else
                {
                    double p = x.Price * k;
                    buyServices[x] = new BuyItem { Count = k, Total = p };
                    DtOrderPriceList.ItemsSource = null;
                    DtOrderPriceList.ItemsSource = buyServices;
                }


            }
            CalculateTotalPrice();
        }

        private void BtnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
           // if ((Manager.CurrentUser.Role == false) && ())


            var x = (sender as Button).DataContext as Service;

            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить услугу?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                buyServices.Remove(x);
                DtOrderPriceList.ItemsSource = null;
                DtOrderPriceList.ItemsSource = buyServices;
            }
            CalculateTotalPrice();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show($"Отменить заявку?", "Отмена", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //if ((Manager.CurrentUser.Role != true) &&(_currentItem.StatusId != 1))

            //{
            //    MessageBox.Show("Заказ отменить не мозможно");
                
            //}

            if (messageBoxResult == MessageBoxResult.OK)
            {
                List<ServiceOrder> delItems = AutoTuningBDEntities.GetContext().ServiceOrders.Where(p => p.OrderId == _currentItem.Id).ToList();
                AutoTuningBDEntities.GetContext().ServiceOrders.RemoveRange(delItems);
                AutoTuningBDEntities.GetContext().Orders.Remove(_currentItem);
                AutoTuningBDEntities.GetContext().SaveChanges();
                MessageBox.Show("Заявка отменена");
                Manager.MainFrame.GoBack();
            }

        }
    }
}

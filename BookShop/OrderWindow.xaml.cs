using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TransactionLibrary;

namespace BookShop
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();

            CustomerID_Label.Content = LoginWindow.CustomerID;

            OrderID_Label.Content = "1";
            ISBN_Label.Content = "-";
            ID_Label.Content = "0";
            Quatity_Label.Content = "0";
            TotalPrice_Label.Content = "0";

            string id = (string)OrderID_Label.Content;

            foreach (string isbn in Transaction.GetISBN(id))
            {
                ISBN_Label.Content = isbn;
            }

            foreach (string customer_id in Transaction.GetCustomerID(id))
            {
                ID_Label.Content = customer_id;
            }

            foreach (string quatity in Transaction.GetQuatity(id))
            {
                Quatity_Label.Content = quatity;
            }

            foreach (string total_price in Transaction.GetTotalPrice(id))
            {
                TotalPrice_Label.Content = total_price;
            }
        }

        private void Menu_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void MyShop_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MyShopWindow myShopWindow = new MyShopWindow();
            myShopWindow.Show();
        }

        private void Account_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AccountWindow accountWindow = new AccountWindow();
            accountWindow.Show();
        }

        private void Order_Btn_Click(object sender, RoutedEventArgs e)
        {
            CustomerID_Label.Content = LoginWindow.CustomerID;

            OrderID_Label.Content = "1";
            ISBN_Label.Content = "-";
            ID_Label.Content = "0";
            Quatity_Label.Content = "0";
            TotalPrice_Label.Content = "0";
        }

        private void Logout_Btn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow.CustomerID = null;
            this.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Up_Btn_Click(object sender, RoutedEventArgs e)
        {
            string order_id = (string)OrderID_Label.Content;
            int idNum = int.Parse(order_id);
            int result = idNum + 1;
            string id = result.ToString();
            OrderID_Label.Content = id;

            OrderID_Label.Content = "1";
            ISBN_Label.Content = "-";
            ID_Label.Content = "0";
            Quatity_Label.Content = "0";
            TotalPrice_Label.Content = "0";

            foreach (string isbn in Transaction.GetISBN(id))
            {
                ISBN_Label.Content = isbn;
            }

            foreach (string customer_id in Transaction.GetCustomerID(id))
            {
                ID_Label.Content = customer_id;
            }

            foreach (string quatity in Transaction.GetQuatity(id))
            {
                Quatity_Label.Content = quatity;
            }

            foreach (string total_price in Transaction.GetTotalPrice(id))
            {
                TotalPrice_Label.Content = total_price;
            }
        }

        private void Down_Btn_Click(object sender, RoutedEventArgs e)
        {
            string order_id = (string)OrderID_Label.Content;
            int idNum = int.Parse(order_id);
            int result = idNum - 1;
            string id = result.ToString();

            OrderID_Label.Content = "1";
            ISBN_Label.Content = "-";
            ID_Label.Content = "0";
            Quatity_Label.Content = "0";
            TotalPrice_Label.Content = "0";

            if (result == 0)
            {
                OrderID_Label.Content = id;
                ISBN_Label.Content = "-";
                ID_Label.Content = "0";
                Quatity_Label.Content = "0";
                TotalPrice_Label.Content = "0";
            }
            else if (result > 0)
            {
                OrderID_Label.Content = id;

                foreach (string isbn in Transaction.GetISBN(id))
                {
                    ISBN_Label.Content = isbn;
                }

                foreach (string customer_id in Transaction.GetCustomerID(id))
                {
                    ID_Label.Content = customer_id;
                }

                foreach (string quatity in Transaction.GetQuatity(id))
                {
                    Quatity_Label.Content = quatity;
                }

                foreach (string total_price in Transaction.GetTotalPrice(id))
                {
                    TotalPrice_Label.Content = total_price;
                }
            }
        }
    }
}

using CustomerLibrary;
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

namespace BookShop
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();

            CustomerID_Label.Content = LoginWindow.CustomerID;

            string customer_id = (string)CustomerID_Label.Content;
            ID_Label.Content = CustomerID_Label.Content;

            foreach (string name in Customer.GetName(customer_id))
            {
                Name_Label.Content = name;
            }

            foreach (string email in Customer.GetEmail(customer_id))
            {
                Email_Label.Content = email;
            }

            foreach (string address in Customer.GetAddress(customer_id))
            {
                Address_Label.Content = address;
            }

            Edit_Grid.Visibility = Visibility.Hidden;
            Delete_Grid.Visibility = Visibility.Hidden;
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
            CustomerID_Label.Content = LoginWindow.CustomerID;

            string customer_id = (string)CustomerID_Label.Content;
            ID_Label.Content = CustomerID_Label.Content;

            foreach (string name in Customer.GetName(customer_id))
            {
                Name_Label.Content = name;
            }

            foreach (string email in Customer.GetEmail(customer_id))
            {
                Email_Label.Content = email;
            }

            foreach (string address in Customer.GetAddress(customer_id))
            {
                Address_Label.Content = address;
            }

            Edit_Grid.Visibility = Visibility.Hidden;
            Delete_Grid.Visibility = Visibility.Hidden;
        }

        private void Order_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
        }

        private void Logout_Btn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow.CustomerID = null;
            this.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Show_Btn_Click(object sender, RoutedEventArgs e)
        {
            string customr_id = (string)CustomerID_Label.Content;

            foreach (string password in Customer.GetPassword(customr_id))
            {
                Password_Label.Content = password;
            }
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            string customer_id = (string)CustomerID_Label.Content;
            Edit_Grid.Visibility = Visibility.Visible;
            Info_Grid.Visibility = Visibility.Hidden;
            Name_TxtBox.Text = (string)Name_Label.Content;
            Email_TxtBox.Text = (string)Email_Label.Content;
            Address_TxtBox.Text = (string)Address_Label.Content;

            foreach (string password in Customer.GetPassword(customer_id))
            {
                Password_TxtBox.Text = password;
            }
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            Edit_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
        }

        private void Finish_Btn_Click(object sender, RoutedEventArgs e)
        {
            string customer_id = (string)CustomerID_Label.Content;
            string name = Name_TxtBox.Text;
            string email = Email_TxtBox.Text;
            string address = Address_TxtBox.Text;
            string password = Password_TxtBox.Text;
            Customer.UpdateData(name, email, address, password);
            MessageBox.Show("Update Complete");

            foreach (string getname in Customer.GetName(customer_id))
            {
                Name_Label.Content = getname;
            }

            foreach (string getemail in Customer.GetEmail(customer_id))
            {
                Email_Label.Content = getemail;
            }

            foreach (string getaddress in Customer.GetAddress(customer_id))
            {
                Address_Label.Content = getaddress;
            }

            Edit_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            Delete_Grid.Visibility = Visibility.Visible;
        }

        private void No_Btn_Click(object sender, RoutedEventArgs e)
        {
            Delete_Grid.Visibility = Visibility.Hidden;
        }

        private void Yes_Btn_Click(object sender, RoutedEventArgs e)
        {
            string customer_id = (string)CustomerID_Label.Content;
            Customer.DeleteData(customer_id);

            LoginWindow.CustomerID = null;
            this.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
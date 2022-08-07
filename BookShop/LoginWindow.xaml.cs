using BookLibrary;
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
using TransactionLibrary;

namespace BookShop
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Customer.InitializeDatabase();
            Book.InitializeDatabase();
            Transaction.InitializeDatabase();

            CustomerID_TxtBox.Text = "Customer ID";
            Email_TxtBox.Text = "Email";
            Password_TxtBox.Text = "Password";

            NewName_TxtBox.Text = "Name";
            NewEmail_TxtBox.Text = "Email";
            NewAddress_TxtBox.Text = "Address";
            NewPassword_TxtBox.Text = "Password";

            SignIn_Grid.Visibility = Visibility.Visible;
            Login_Grid.Visibility = Visibility.Hidden;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            SignIn_Grid.Visibility = Visibility.Hidden;
            Login_Grid.Visibility = Visibility.Visible;
        }

        private void SignUp_Btn_Click(object sender, RoutedEventArgs e)
        {
            string name = NewName_TxtBox.Text;
            string email = NewEmail_TxtBox.Text;
            string address = NewAddress_TxtBox.Text;
            string password = NewPassword_TxtBox.Text;
            Customer.AddData(name, email, address, password);
            MessageBox.Show("Sign Up Complete");

            SignIn_Grid.Visibility = Visibility.Hidden;
            Login_Grid.Visibility = Visibility.Visible;

            foreach (string id in Customer.GetID())
            {
                MessageBox.Show("Your Customer ID = " + id);
            }
        }

        public static object CustomerID { get; internal set; }

        private string CheckEmail { get; set; }

        private string CheckPassword { get; set; }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            string customer_id = CustomerID_TxtBox.Text;
            string email = Email_TxtBox.Text;
            string password = Password_TxtBox.Text;

            foreach (string getEmail in Customer.GetEmail(customer_id))
            {
                CheckEmail = getEmail;
            }

            foreach (string getPassword in Customer.GetPassword(customer_id))
            {
                CheckPassword = getPassword;
            }

            if (CheckEmail == email && CheckPassword == password)
            {
                CustomerID = customer_id;
                MessageBox.Show("Login Complete");
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else if (CheckEmail != email || CheckPassword != password)
            {
                MessageBox.Show("Eror Please Try Again");
            }
        }

        private void CreateAccount_Btn_Click(object sender, RoutedEventArgs e)
        {
            SignIn_Grid.Visibility = Visibility.Visible;
            Login_Grid.Visibility = Visibility.Hidden;
        }
    }
}
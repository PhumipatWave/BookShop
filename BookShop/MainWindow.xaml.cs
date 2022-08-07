using BookLibrary;
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
using TransactionLibrary;

namespace BookShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CustomerID_Label.Content = LoginWindow.CustomerID;

            Search_TxtBox.Text = "Search For Book ID";
            BookID_Label.Content = "1";
            ISBN_Label.Content = "-";
            Title_Label.Content = "-";
            Description_Label.Content = "-";
            Price_Label.Content = "0";
            Quatity_TxtBox.Text = "0";

            string id = (string)BookID_Label.Content;

            foreach (string isbn in Book.GetISBN(id))
            {
                ISBN_Label.Content = isbn;
            }

            foreach (string title in Book.GetTitle(id))
            {
                Title_Label.Content = title;
            }

            foreach (string description in Book.GetDescription(id))
            {
                Description_Label.Content = description;
            }

            foreach (string price in Book.GetPrice(id))
            {
                Price_Label.Content = price;
            }

            Search_Grid.Visibility = Visibility.Hidden;
            Transaction_Grid.Visibility = Visibility.Hidden;
        }

        private void Menu_Btn_Click(object sender, RoutedEventArgs e)
        {
            CustomerID_Label.Content = LoginWindow.CustomerID;

            Search_TxtBox.Text = "Search For Book ID";
            BookID_Label.Content = "1";
            ISBN_Label.Content = "-";
            Title_Label.Content = "-";
            Description_Label.Content = "-";
            Price_Label.Content = "0";
            Quatity_TxtBox.Text = "0";

            string id = (string)BookID_Label.Content;

            foreach (string isbn in Book.GetISBN(id))
            {
                ISBN_Label.Content = isbn;
            }

            foreach (string title in Book.GetTitle(id))
            {
                Title_Label.Content = title;
            }

            foreach (string description in Book.GetDescription(id))
            {
                Description_Label.Content = description;
            }

            foreach (string price in Book.GetPrice(id))
            {
                Price_Label.Content = price;
            }

            Search_Grid.Visibility = Visibility.Hidden;
            Transaction_Grid.Visibility = Visibility.Hidden;
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

        private void Up_Btn_Click(object sender, RoutedEventArgs e)
        {
            string book_id = (string)BookID_Label.Content;
            int idNum = int.Parse(book_id);
            int result = idNum + 1;
            string id = result.ToString();
            BookID_Label.Content = id;

            ISBN_Label.Content = "-";
            Title_Label.Content = "-";
            Description_Label.Content = "-";
            Price_Label.Content = "0";
            Quatity_TxtBox.Text = "0";

            foreach (string isbn in Book.GetISBN(id))
            {
                ISBN_Label.Content = isbn;
            }

            foreach (string title in Book.GetTitle(id))
            {
                Title_Label.Content = title;
            }

            foreach (string description in Book.GetDescription(id))
            {
                Description_Label.Content = description;
            }

            foreach (string price in Book.GetPrice(id))
            {
                Price_Label.Content = price;
            }
        }

        private void Down_Btn_Click(object sender, RoutedEventArgs e)
        {
            string book_id = (string)BookID_Label.Content;
            int idNum = int.Parse(book_id);
            int result = idNum - 1;
            string id = result.ToString();

            ISBN_Label.Content = "-";
            Title_Label.Content = "-";
            Description_Label.Content = "-";
            Price_Label.Content = "0";
            Quatity_TxtBox.Text = "0";

            if (result == 0)
            {
                BookID_Label.Content = id;
                ISBN_Label.Content = "-";
                Title_Label.Content = "-";
                Description_Label.Content = "-";
                Price_Label.Content = "0";
            }
            else if (result > 0)
            {
                BookID_Label.Content = id;

                foreach (string isbn in Book.GetISBN(id))
                {
                    ISBN_Label.Content = isbn;
                }

                foreach (string title in Book.GetTitle(id))
                {
                    Title_Label.Content = title;
                }

                foreach (string description in Book.GetDescription(id))
                {
                    Description_Label.Content = description;
                }

                foreach (string price in Book.GetPrice(id))
                {
                    Price_Label.Content = price;
                }
            }
        }

        private void Search_Btn_Click(object sender, RoutedEventArgs e)
        {
            Search_Grid.Visibility = Visibility.Visible;
            Info_Grid.Visibility = Visibility.Hidden;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            Search_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
        }

        private string Book_ID { get; set; }

        private void Ok_Btn_Click(object sender, RoutedEventArgs e)
        {
            Search_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
            string isbn = Search_TxtBox.Text;
            ISBN_Label.Content = isbn;

            foreach (string book_id in Book.GetID(isbn))
            {
                BookID_Label.Content = book_id;
                Book_ID = book_id;
            }

            foreach (string title in Book.GetTitle(Book_ID))
            {
                Title_Label.Content = title;
            }

            foreach (string description in Book.GetDescription(Book_ID))
            {
                Description_Label.Content = description;
            }

            foreach (string price in Book.GetPrice(Book_ID))
            {
                Price_Label.Content = price;
            }

            Search_TxtBox.Text = "Search For Book ID";
        }

        private void Buy_Btn_Click(object sender, RoutedEventArgs e)
        {
            Transaction_Grid.Visibility = Visibility.Visible;
            Info_Grid.Visibility = Visibility.Hidden;
            string isbn = (string)ISBN_Label.Content;
            string customer_id = (string)CustomerID_Label.Content;
            int quatity = int.Parse(Quatity_TxtBox.Text);
            string price_txt = (string)Price_Label.Content;
            int price = int.Parse(price_txt);

            TXN_ISBN_Label.Content = isbn;
            TXN_CustomerID_Label.Content = customer_id;
            TXN_Quatity_Label.Content = quatity;
            int result = quatity * price;
            TXN_TotalPrice_Label.Content = result;
        }

        private void No_Btn_Click(object sender, RoutedEventArgs e)
        {
            Transaction_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
        }

        private void Pay_Btn_Click(object sender, RoutedEventArgs e)
        {
            string isbn = (string)TXN_ISBN_Label.Content;
            string id_txt = (string)TXN_CustomerID_Label.Content;
            int customer_id = int.Parse(id_txt);
            int quatity = (int)TXN_Quatity_Label.Content;
            int totalPrice = (int)TXN_TotalPrice_Label.Content;
            Transaction.AddData(isbn, customer_id, quatity, totalPrice);
            MessageBox.Show("Complete Order");
            Transaction_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
        }
    }
}
using BookLibrary;
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
    /// Interaction logic for MyShopWindow.xaml
    /// </summary>
    public partial class MyShopWindow : Window
    {
        public MyShopWindow()
        {
            InitializeComponent();

            CustomerID_Label.Content = LoginWindow.CustomerID;

            ISBN_TxtBox.Text = "ISBN";
            Title_TxtBox.Text = "Title";
            Description_TxtBox.Text = "Description";
            Price_TxtBox.Text = "Price";

            BookID_Label.Content = "1";
            ISBN_Label.Content = "-";
            Title_Label.Content = "-";
            Description_Label.Content = "-";
            Price_Label.Content = "0";

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

            Add_Grid.Visibility = Visibility.Hidden;
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
            CustomerID_Label.Content = LoginWindow.CustomerID;

            ISBN_TxtBox.Text = "ISBN";
            Title_TxtBox.Text = "Title";
            Description_TxtBox.Text = "Description";
            Price_TxtBox.Text = "Price";

            BookID_Label.Content = "1";
            ISBN_Label.Content = "-";
            Title_Label.Content = "-";
            Description_Label.Content = "-";
            Price_Label.Content = "0";

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

            Add_Grid.Visibility = Visibility.Hidden;
            Edit_Grid.Visibility = Visibility.Hidden;
            Delete_Grid.Visibility = Visibility.Hidden;
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add_Grid.Visibility = Visibility.Visible;
            Info_Grid.Visibility = Visibility.Hidden;
        }

        private void CancelAdd_Btn_Click(object sender, RoutedEventArgs e)
        {
            Add_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
        }

        private void AddData_Btn_Click(object sender, RoutedEventArgs e)
        {
            string isbn = ISBN_TxtBox.Text;
            string title = Title_TxtBox.Text;
            string description = Description_TxtBox.Text;
            int price = int.Parse(Price_TxtBox.Text);
            Book.AddData(isbn, title, description, price);
            MessageBox.Show("Your Book Complete Add To Store");

            foreach (string get_isbn in Book.GetISBN("1"))
            {
                ISBN_Label.Content = get_isbn;
            }

            foreach (string get_title in Book.GetTitle("1"))
            {
                Title_Label.Content = title;
            }

            foreach (string get_description in Book.GetDescription("1"))
            {
                Description_Label.Content = get_description;
            }

            foreach (string get_price in Book.GetPrice("1"))
            {
                Price_Label.Content = get_price;
            }

            Add_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Edit_Grid.Visibility = Visibility.Visible;
            Info_Grid.Visibility = Visibility.Hidden;

            string isbn = (string)ISBN_Label.Content;
            string title = (string)Title_Label.Content;
            string description = (string)Description_Label.Content;
            string price = (string)Price_Label.Content;

            EditISBN_TxtBox.Text = isbn;
            EditTitle_TxtBox.Text = title;
            EditDescription_TxtBox.Text = description;
            EditPrice_TxtBox.Text = price;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            Edit_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
        }

        private void Finish_Btn_Click(object sender, RoutedEventArgs e)
        {
            string isbn = EditISBN_TxtBox.Text;
            string title = EditTitle_TxtBox.Text;
            string description = EditDescription_TxtBox.Text;
            int price = int.Parse(EditPrice_TxtBox.Text);
            Book.UpdateData(isbn, title, description, price);

            string book_id = (string)BookID_Label.Content;

            foreach (string getISBN in Book.GetISBN(book_id))
            {
                ISBN_Label.Content = getISBN;
            }

            foreach (string getTitle in Book.GetTitle(book_id))
            {
                Title_Label.Content = getTitle;
            }

            foreach (string getDescription in Book.GetDescription(book_id))
            {
                Description_Label.Content = getDescription;
            }

            foreach (string getPrice in Book.GetPrice(book_id))
            {
                Price_Label.Content = getPrice;
            }

            Edit_Grid.Visibility = Visibility.Hidden;
            Info_Grid.Visibility = Visibility.Visible;
            MessageBox.Show("Complete Update Book Data");
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
            string book_id = (string)BookID_Label.Content;
            Book.DeleteData(book_id);

            CustomerID_Label.Content = LoginWindow.CustomerID;

            ISBN_TxtBox.Text = "ISBN";
            Title_TxtBox.Text = "Title";
            Description_TxtBox.Text = "Description";
            Price_TxtBox.Text = "Price";

            BookID_Label.Content = "1";
            ISBN_Label.Content = "-";
            Title_Label.Content = "-";
            Description_Label.Content = "-";
            Price_Label.Content = "0";

            Add_Grid.Visibility = Visibility.Hidden;
            Edit_Grid.Visibility = Visibility.Hidden;
            Delete_Grid.Visibility = Visibility.Hidden;
        }
    }
}
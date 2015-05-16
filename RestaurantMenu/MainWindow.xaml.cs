using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RestaurantMenu
{
    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public MenuItem(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }

    public partial class MainWindow : Window
    {

        private ObservableCollection<MenuItem> _myMenu = new ObservableCollection<MenuItem>();

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _myMenu; }
            set { _myMenu = value; }
        }

        double _total;

        public MainWindow()
        {
            InitializeComponent();
          
            MenuItems = GetMenuItems();

            nameList.ItemsSource = MenuItems;
            nameList.DisplayMemberPath = "Name";
            nameList.SelectedValuePath = "Price";

            quantity.Text = "1";     
        }

        public ObservableCollection<MenuItem> GetMenuItems()
        {
            var menu = new ObservableCollection<MenuItem>();

            menu.Add(new MenuItem("Hamburger", 3.99));
            menu.Add(new MenuItem("Wrap", 2.89));
            menu.Add(new MenuItem("Sandwich", 4.79));
            menu.Add(new MenuItem("Fries", 1.99));
            menu.Add(new MenuItem("Drink", 1.49));
            return menu;

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var q = Int32.Parse(quantity.Text);
            _total += Double.Parse(nameList.SelectedValue.ToString()) * q ;
            
            due.Text = String.Format("${0,2}", _total);

            quantity.Text = "1";  
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            var _cash = Double.Parse(cash.Text);

            change.Text = String.Format("${0,2}", _cash - _total);

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _total = 0.00;
            due.Text = String.Format("${0,2}", _total);
            
            cash.Text = String.Format("${0,2}", 0);

            change.Text = String.Format("${0,2}", 0);
        }

    }
}

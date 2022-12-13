using JournalDemin.AppData;
using JournalDemin.Model;
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

namespace JournalDemin.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для JournalPage.xaml
    /// </summary>
    public partial class JournalPage : Page
    {
        public JournalPage()
        {
            InitializeComponent();
            CustomersList.ItemsSource = Connect.entities.VisGroups.ToList();
            CustomersList.ItemsSource = Connect.entities.Focus.ToList();
            CustomersList.ItemsSource = Connect.entities.Mark.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {            
                CustomersList.ItemsSource = Connect.entities.Journal.ToList();                       
        }

        private void CustomersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Journal journal = (Journal)CustomersList.SelectedItem;           
        }
    }
}

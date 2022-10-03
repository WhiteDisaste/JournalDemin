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
    /// Логика взаимодействия для ActivityPage.xaml
    /// </summary>
    public partial class ActivityPage : Page
    {
        public ActivityPage()
        {
            InitializeComponent();

            txtFocusActivity.ItemsSource = Connect.entities.Focus.ToList();
        }

        private void CreateActivityBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(txtActivityName.Text))
                mes += "Введите название мероприятия";
            
            if (string.IsNullOrWhiteSpace(txtFocusActivity.Text))
                mes += "Введите направленность мероприятия";
            if (mes != "")
            {
                MessageBox.Show("Вы создали новое мероприятие", "Информация!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Activity activity = new Activity()
            {
                Name = txtActivityName.Text,
                Focus = txtFocusActivity.SelectedItem as Focus
            };
            Connect.entities.Activity.Add(activity);
            Connect.entities.SaveChanges();
            MessageBox.Show("запись добавлена");

            txtActivityName.Text = "";
            txtFocusActivity.Text = "";
        }
    }
}

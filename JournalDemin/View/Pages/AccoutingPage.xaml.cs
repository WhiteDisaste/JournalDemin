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
    /// Логика взаимодействия для AccoutingPage.xaml
    /// </summary>
    public partial class AccoutingPage : Page
    {
        public AccoutingPage()
        {
            InitializeComponent();
            
            txtFocusActivity.ItemsSource = Connect.entities.Focus.ToList();
            txtGroupName.ItemsSource = Connect.entities.Groups.ToList();
            txtMark.ItemsSource = Connect.entities.Mark.ToList();
            txtActivityName.ItemsSource = Connect.entities.Activity.ToList();
            txtViewGroup.ItemsSource = Connect.entities.VisGroups.ToList();
        }

        private void CreateAccoutingBtn_Click(object sender, RoutedEventArgs e)
        {
            
            
            string mes = "";
            if (string.IsNullOrWhiteSpace(txtActivityName.Text))
                mes += "Выберите название мероприятия\n";
           
            if (string.IsNullOrWhiteSpace(txtFocusActivity.Text))
                mes += "Выберите направление мероприятия\n";
            
            if (string.IsNullOrWhiteSpace(dapicCalendar.Text))
                mes += "Выберите дату\n";
            
            if (string.IsNullOrWhiteSpace(txtGroupName.Text))
                mes += "Выберите название группы\n";
            
            if (string.IsNullOrWhiteSpace(txtViewGroup.Text))
                mes += "Выберите вид группы\n";
            if(mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Journal journal = new Journal()
            {
                DateGr = (DateTime)dapicCalendar.SelectedDate,
                Groups = txtGroupName.SelectedItem as Groups,
                Activity = txtActivityName.SelectedItem as Activity,
                Mark = txtMark.SelectedItem as Mark
            };
            Connect.entities.Journal.Add(journal);
            Connect.entities.SaveChanges();
            MessageBox.Show("запись добавлена");

            txtActivityName.Text = "";
            txtFocusActivity.Text = "";
            txtGroupName.Text = "";
            txtViewGroup.Text = "";
            txtMark.Text = "";
            dapicCalendar.Text = "";

        }

        private void txtFocusActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int View = Convert.ToInt32(txtFocusActivity.SelectedValue);
            //txtActivityName.ItemsSource = Connect.entities.Activity.Where(x => x.IdFocus == View).ToList();
        }

        private void txtViewGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int View = Convert.ToInt32(txtViewGroup.SelectedValue);
            //txtGroupName.ItemsSource = Connect.entities.Groups.Where(x => x.IdGroup == View).ToList();
        }
    }
}

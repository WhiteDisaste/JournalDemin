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
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Page
    {
        public GroupPage()
        {
            InitializeComponent();

            
                    
            txtViewGroup.ItemsSource = Connect.entities.VisGroups.ToList();

        }

        private void CreateGroupBtn_Click(object sender, RoutedEventArgs e)
        {
              string mes = "";
                if (string.IsNullOrWhiteSpace(txtGroupName.Text))
                    mes += "Введите название группу";
                if (string.IsNullOrWhiteSpace(txtViewGroup.Text))
                    mes += "Введите вид группу";            
            if (mes !="")
                {
                    MessageBox.Show("Вы создали новую группу", "Информация!", MessageBoxButton.OK,MessageBoxImage.Information);
                }

            Groups groups = new Groups()
            {
                Name = txtGroupName.Text,
                VisGroups = txtViewGroup.SelectedItem as VisGroups               
            };
            Connect.entities.Groups.Add(groups);
            Connect.entities.SaveChanges();
            MessageBox.Show("запись добавлена");

            txtGroupName.Text = "";
            txtViewGroup.Text = "";
        }


        
    }
}

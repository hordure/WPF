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
using System.Windows.Shapes;

namespace ProjectMaster2016
{
    /// <summary>
    /// Interaction logic for AddProjectHours_ProjectWindow.xaml
    /// </summary>
    public partial class AddProjectHours_ProjectWindow : Window
    {
        public AddProjectHours_ProjectWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table project. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            projectmasterDataSetprojectTableAdapter.Fill(projectmasterDataSet.project);
            System.Windows.Data.CollectionViewSource projectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectViewSource")));
            projectViewSource.View.MoveCurrentToFirst();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["AddProjectToProjectHours"] = projectDataGrid.SelectedItem;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

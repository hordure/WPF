using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectMaster2016
{
    /// <summary>
    /// Interaction logic for SelectProjectWindow.xaml
    /// </summary>
    public partial class SelectProjectWindow : Window
    {
        public SelectProjectWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table project. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            projectmasterDataSetprojectTableAdapter.Fill(projectmasterDataSet.project);
            System.Windows.Data.CollectionViewSource projectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectViewSource")));
            projectViewSource.View.MoveCurrentToFirst();
        }

        private void selectProject_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["SelectedProject"] = projectDataGrid.SelectedItem;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void projectDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.Current.Properties["SelectedProject"] = projectDataGrid.SelectedItem;
            this.Close();
        }


    }
}

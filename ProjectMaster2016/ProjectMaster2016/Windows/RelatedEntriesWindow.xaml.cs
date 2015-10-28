using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for RelatedEntriesWindow.xaml
    /// </summary>
    public partial class RelatedEntriesWindow : Window
    {
        public RelatedEntriesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)App.Current.Properties["project"];
           
            int pid = (int)drv["pid"];
            string title = (string)drv["projectname"];
            lblProjectTitle.Content = title;
            
            try
            {
                ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
                // Load data into the table project_employees. You can modify this code as needed.
                ProjectMaster2016.projectmasterDataSetTableAdapters.project_employeesTableAdapter projectmasterDataSetproject_employeesTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_employeesTableAdapter();
                projectmasterDataSetproject_employeesTableAdapter.FillByAllRelatedEntries(projectmasterDataSet.project_employees, pid);
                System.Windows.Data.CollectionViewSource project_employeesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("project_employeesViewSource")));
                project_employeesViewSource.View.MoveCurrentToFirst();
            }
            catch(Exception)
            {
                //MessageBox.Show(exs.ToString());
            }
        }
    }
}

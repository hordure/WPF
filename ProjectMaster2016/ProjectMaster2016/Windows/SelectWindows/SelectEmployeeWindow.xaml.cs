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
    /// Interaction logic for AddProjectCost_Employee.xaml
    /// </summary>
    public partial class SelectEmployeeWindow : Window
    {
        public SelectEmployeeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table employee. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter projectmasterDataSetemployeeTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter();
            projectmasterDataSetemployeeTableAdapter.Fill(projectmasterDataSet.employee);
            System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            employeeViewSource.View.MoveCurrentToFirst();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["SelectedEmployee"] = employeeDataGrid.SelectedItem;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void employeeDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.Current.Properties["SelectedEmployee"] = employeeDataGrid.SelectedItem;
            this.Close();
        }
    }
}


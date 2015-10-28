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
    /// Interaction logic for AddProjectEmployeeWindow.xaml
    /// </summary>
    public partial class AddProjectEmployeeWindow : Window
    {
        public AddProjectEmployeeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)App.Current.Properties["project"];
            //string empId = Convert.ToString(drv["employee_eid"]);
            int pid = (int)drv["pid"];
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table employee. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter projectmasterDataSetemployeeTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter();
            projectmasterDataSetemployeeTableAdapter.FillByNotProjectEmployees(projectmasterDataSet.employee, pid);
            System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            employeeViewSource.View.MoveCurrentToFirst();
      
        }

        private void btnAddProjectEmployee_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)App.Current.Properties["project"];
            //string empId = Convert.ToString(drv["employee_eid"]);
            int pid = (int)drv["pid"];
            int eid = (int)employeeDataGrid.SelectedValue;
            ProjectMaster2016.projectmasterDataSetTableAdapters.project_employeesTableAdapter peta = new projectmasterDataSetTableAdapters.project_employeesTableAdapter();
            peta.Insert(pid, eid);
            this.Close();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

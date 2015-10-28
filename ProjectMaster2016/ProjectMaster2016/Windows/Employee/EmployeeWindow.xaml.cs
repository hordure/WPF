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
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            UpdateWindow();
        }

        private void UpdateWindow()
        {
            int UserId = (int)App.Current.Properties["UserId"];
            string role = (string)App.Current.Properties["Role"];

            if (role == "user" || role == "poweruser")
            {
                btnAddEmployee.Visibility = Visibility.Collapsed;
                btnEditEmployee.Visibility = Visibility.Collapsed;
                btnRemoveEmployee.Visibility = Visibility.Collapsed;
                ctxMenu.Visibility = Visibility.Collapsed;

            }

            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table employee. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter projectmasterDataSetemployeeTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter();
            projectmasterDataSetemployeeTableAdapter.FillWithUserRole(projectmasterDataSet.employee);
            System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            employeeViewSource.View.MoveCurrentToFirst();

            lblName.Content = App.Current.Properties["User"];
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow win = new AddEmployeeWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnRemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            int eid = (int)employeeDataGrid.SelectedValue;
            MessageBoxResult result = MessageBox.Show("Ertu viss um að þú viljir eyða starfsmaður", "Eyða starfsmaður", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    projectmasterDataSetTableAdapters.employeeTableAdapter eta = new projectmasterDataSetTableAdapters.employeeTableAdapter();
                    eta.DeleteEmployee(eid);
                    UpdateWindow();

                }
                catch
                {
                    MessageBox.Show("Ekki hægt að eyða starfsmaður", "Framkvæmd mistókst");
                }
            }
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            EditEmployeeWindow win = new EditEmployeeWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Viltu skrá þig út?", "Útskráning", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
                //App.Current.Properties["User"] = "Logout";
                App.Current.Properties["CloseWindow"] = "Close";
            }
        }
    }
}

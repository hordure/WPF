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
    /// Interaction logic for EditProjectCostWindow.xaml
    /// </summary>
    public partial class EditProjectCostWindow : Window
    {
        public EditProjectCostWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
        }

        private void UpdateWindow()
        {
            DataRowView drv = (DataRowView)App.Current.Properties["projectCost"];
            int pcid = (int)drv["pcid"];

            string role = (string)App.Current.Properties["Role"];
            if(role == "user" || role =="poweruser")
            {
                btnEditProjectCostProject.Visibility = Visibility.Collapsed;
                btnEditProjectCostEmployee.Visibility = Visibility.Collapsed;
            }

            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table project_costs. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.project_costsTableAdapter projectmasterDataSetproject_costsTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_costsTableAdapter();
            projectmasterDataSetproject_costsTableAdapter.FillByProjectCostId(projectmasterDataSet.project_costs, pcid);
            System.Windows.Data.CollectionViewSource project_costsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("project_costsViewSource")));
            project_costsViewSource.View.MoveCurrentToFirst();

            if (App.Current.Properties["SelectedProject"] != null)
            {
                DataRowView drv2 = (DataRowView)App.Current.Properties["SelectedProject"];
                lblEditProjectCost_Project.Content = (string)drv2["projectname"];
                lblpid.Content = (int)drv2["pid"];
                App.Current.Properties["SelectedProject"] = null;
            }

            if (App.Current.Properties["SelectedEmployee"] != null)
            {
                DataRowView drv3 = (DataRowView)App.Current.Properties["SelectedEmployee"];
                lblEditProjectCost_Employee.Content = (string)drv3["name"];
                lbleid.Content = (int)drv3["eid"];
                App.Current.Properties["SelectedEmployee"] = null;
            }
        }




        private void btnEditProjectCost_Employee_Click(object sender, RoutedEventArgs e)
        {
            SelectEmployeeWindow win = new SelectEmployeeWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnEditProjectCost_Project_Click(object sender, RoutedEventArgs e)
        {
            SelectProjectWindow win = new SelectProjectWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnUptadeProjectCost_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Viltu vista breytingar?", "Breyta kostnaði", MessageBoxButton.YesNo);
            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    DataRowView drv = (DataRowView)App.Current.Properties["projectCost"];
                    
                    int project_pid = (int)lblpid.Content;
                    int employee_eid = (int)lbleid.Content;
                    string costdescription = (string)txtpcdescription.Text;
                    DateTime costdate = (DateTime)dpCostDate.SelectedDate;
                    DateTime costTimeStamp = Convert.ToDateTime(lblCreateDate.Content);
                    int cost = Convert.ToInt32(txtcost.Text);
                    int pcid = (int)drv["pcid"];

                    projectmasterDataSetTableAdapters.project_costsTableAdapter pca = new projectmasterDataSetTableAdapters.project_costsTableAdapter();
                    pca.UpdateProjectCost(project_pid, employee_eid, costdescription, costdate, costTimeStamp, cost, pcid);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ekki hægt að vista breytingar");
            }
        }
    }
}

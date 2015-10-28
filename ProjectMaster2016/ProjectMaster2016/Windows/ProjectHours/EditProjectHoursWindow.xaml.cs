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
    /// Interaction logic for EditProjectHoursWindow.xaml
    /// </summary>
    public partial class EditProjectHoursWindow : Window
    {
        public static int pid;
        public static int eid;

        public EditProjectHoursWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();

        }

        private void UpdateWindow()
        {
            //
            //The selected project to edit from ProjectHoursWindow
            //
            DataRowView drv = (DataRowView)App.Current.Properties["ProjecthoursToEdit"];
            pid = (int)drv["project_pid"];
            eid = Convert.ToInt32(drv["employee_eid"]);
            txtPhid.Content = (int)drv["phid"];
            lblEditProject.Content = (string)drv["projectname"];
            lblEmployee.Content = (string)drv["name"];

            txtphdescription.Text = (string)drv["hourdescription"];
            dpHoursDate.SelectedDate = (DateTime)drv["hourdate"];
            decimal temp = (decimal)drv["workhour"];
            txthours.Text = Convert.ToString(temp);

            string role = (string)App.Current.Properties["Role"];
            if (role == "user" || role == "poweruser")
            {
                btnEditProjectHours_Project.Visibility = Visibility.Collapsed;
                btnEditProjectHours_Employee.Visibility = Visibility.Collapsed;
            }

            if (App.Current.Properties["SelectedProject"] != null)
            {
                //
                //Check if user has selected a project from SelectProjectWindow
                //
                DataRowView drv2 = (DataRowView)App.Current.Properties["SelectedProject"];
                lblEditProject.Content = (string)drv2["projectname"];
                pid = (int)drv2["pid"];
                App.Current.Properties["SelectedProject"] = null;

            }
            if (App.Current.Properties["SelectedEmployee"] != null)
            {
                //
                //Check if user has selected an employee from SelectEmployeeWindow
                //
                DataRowView drv3 = (DataRowView)App.Current.Properties["SelectedEmployee"];
                lblEmployee.Content = (string)drv3["name"];
                eid = (int)drv3["eid"];
                App.Current.Properties["SelectedEmployee"] = null;

            }
        }

        private void btnEditProjectHoursEmployee_Click(object sender, RoutedEventArgs e)
        {
            //
            //Go to SelectEmployeeWindow
            //
            SelectEmployeeWindow win = new SelectEmployeeWindow();
            //AddProjectHours_ProjectWindow win = new AddProjectHours_ProjectWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnEditProjectHoursProject_Click(object sender, RoutedEventArgs e)
        {
            //
            //Go to SelectProjectWindow
            //
            SelectProjectWindow win = new SelectProjectWindow();
            //AddProjectHours_ProjectWindow win = new AddProjectHours_ProjectWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void EditProjectHours_Click(object sender, RoutedEventArgs e)
        {

            projectmasterDataSetTableAdapters.project_hoursTableAdapter pha = new projectmasterDataSetTableAdapters.project_hoursTableAdapter();
            string description = txtphdescription.Text;
            DateTime date = (DateTime)dpHoursDate.SelectedDate;
            decimal hours = Convert.ToDecimal(txthours.Text);
            int phid = (int)txtPhid.Content;

            pha.UpdateProjectHours(pid, eid, description, date, DateTime.Now, hours, phid);
            this.Close();
            MessageBox.Show("Færslu hefur verið breytt");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

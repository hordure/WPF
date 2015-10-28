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
    /// Interaction logic for AddProjectHourWindow.xaml
    /// </summary>
    public partial class AddProjectHourWindow : Window
    {
        public static int pid;
        public static int eid;

        public AddProjectHourWindow()
        {
            InitializeComponent();
        }

        private void btnAddProjectHoursProject_Click(object sender, RoutedEventArgs e)
        {
            SelectProjectWindow win = new SelectProjectWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
        }

        private void UpdateWindow()
        {
            if (App.Current.Properties["SelectedProject"] != null)
            {
                DataRowView drv = (DataRowView)App.Current.Properties["SelectedProject"];
                pid = (int)drv["pid"];
                string projectname = (string)drv["projectname"];

                lblAddProjectHoursProject.Content = projectname;
                App.Current.Properties["SelectedProject"] = null;

            }

            if (App.Current.Properties["SelectedEmployee"] != null)
            {
                DataRowView drv = (DataRowView)App.Current.Properties["SelectedEmployee"];
                eid = (int)drv["eid"];
                string name = (string)drv["name"];
                lblProjectHourEmployee.Content = name;
                App.Current.Properties["SelectedEmployee"] = null;
            }

            try { 
                if ((bool)App.Current.Properties["myProject"] == true)
                {
                    DataRowView drv2 = (DataRowView)App.Current.Properties["thisProjectHours"];
                    lblAddProjectHoursProject.Content = (string)drv2["projectname"];
                    lblProjectHourEmployee.Content = (string)App.Current.Properties["User"];
                    btnAddProjectHours_Employee.Visibility = Visibility.Collapsed;
                    btnAddProjectHours_Project.Visibility = Visibility.Collapsed;
                    eid = (int)App.Current.Properties["UserId"];
                    pid = (int)drv2["pid"];
                }
            }
            catch { }
        }

        private void AddProjectHours_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string description = (string)txtphdescription.Text;
                DateTime hoursdate = (DateTime)dpHoursDate.SelectedDate;
                int hours = Convert.ToInt32(txthours.Text);
                projectmasterDataSetTableAdapters.project_hoursTableAdapter pha = new projectmasterDataSetTableAdapters.project_hoursTableAdapter();
                pha.Insert(pid, eid, description, hoursdate, DateTime.Now, hours);
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Verður að fylla rétt í viðeigandi reiti");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddProjectHoursEmployee_Click(object sender, RoutedEventArgs e)
        {
            SelectEmployeeWindow win = new SelectEmployeeWindow();
            
            win.ShowDialog();
            UpdateWindow();
        }



 
    }
}

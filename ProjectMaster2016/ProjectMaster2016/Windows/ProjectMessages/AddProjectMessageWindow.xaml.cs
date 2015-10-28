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
    /// Interaction logic for AddProjectCostWindow.xaml
    /// </summary>
    public partial class AddProjectMessageWindow : Window
    {
        private static int eid;
        private static int pid;

        public AddProjectMessageWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();

        }

        private void btnAddProjectMessageEmployee_Click(object sender, RoutedEventArgs e)
        {
            SelectEmployeeWindow win = new SelectEmployeeWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnAddProjectMessageProject_Click(object sender, RoutedEventArgs e)
        {
            SelectProjectWindow win = new SelectProjectWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnAddProjectMessage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string description = (string)txtpcdescription.Text;
               
                projectmasterDataSetTableAdapters.project_messagesTableAdapter pma = new projectmasterDataSetTableAdapters.project_messagesTableAdapter();
                pma.Insert(pid, eid, description, DateTime.Now, null, null);
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Verður að fylla í viðeigandi reiti");
            }
        }

        private void UpdateWindow()
        {

            projectmasterDataSetTableAdapters.project_messagesTableAdapter pca = new projectmasterDataSetTableAdapters.project_messagesTableAdapter();

            //
            //Set Employee from SelectEmployeeWindow
            //
            if (App.Current.Properties["SelectedEmployee"] != null)
            {
                DataRowView drv = (DataRowView)App.Current.Properties["SelectedEmployee"];
                eid = (int)drv["eid"];
                string name = (string)drv["name"];
                lblAddProjectMessageEmployee.Content = name;
                App.Current.Properties["SelectedEmployee"] = null;
            }

            //
            //Set Project from SelectProjectWindow
            //
            if (App.Current.Properties["SelectedProject"] != null)
            {
                DataRowView drv = (DataRowView)App.Current.Properties["SelectedProject"];
                pid = (int)drv["pid"];
                string projectname = (string)drv["projectname"];
                lblAddProjectMessageProject.Content = projectname;
                App.Current.Properties["SelectedProject"] = null;
            }
            try 
            { 
                //
                //Set Project and Employee if accessed through UserWindow -> user cannot change
                //
                if ((bool)App.Current.Properties["myProject"] == true)
                {
                    DataRowView drv2 = (DataRowView)App.Current.Properties["thisProjectMessage"];
                    lblAddProjectMessageProject.Content = (string)drv2["projectname"];
                    lblAddProjectMessageEmployee.Content = (string)App.Current.Properties["User"];
              
                    btnAddProjectMessageEmployee.Visibility = Visibility.Collapsed;
                    btnAddProjectMessageProject.Visibility = Visibility.Collapsed;
                    eid = (int)App.Current.Properties["UserId"];
                    pid = (int)drv2["pid"];
                }
            }
            catch { }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


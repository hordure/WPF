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
    public partial class AddProjectCostWindow : Window
    {
        public static int eid;
        public static int pid;

        public AddProjectCostWindow()
        {
            InitializeComponent();
        }

        private void btnAddProjectCostProject_Click(object sender, RoutedEventArgs e)
        {
            SelectProjectWindow win = new SelectProjectWindow();
            win.ShowDialog();
            UpdateWindow();

        }

        private void btnAddProjectCostEmployee_Click(object sender, RoutedEventArgs e)
        {
            SelectEmployeeWindow win = new SelectEmployeeWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnAddProjectCost_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                string description = (string)txtpcdescription.Text;
                DateTime costdate = (DateTime)dpCostDate.SelectedDate;
                int cost = Convert.ToInt32(txtcost.Text);
                projectmasterDataSetTableAdapters.project_costsTableAdapter pca = new projectmasterDataSetTableAdapters.project_costsTableAdapter();
                pca.InsertProjectCost(pid, eid, description, costdate, DateTime.Now, cost);
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Verður að fylla í viðeigandi reiti");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            UpdateWindow();


        }

        private void UpdateWindow()
        {

            projectmasterDataSetTableAdapters.project_costsTableAdapter pca = new projectmasterDataSetTableAdapters.project_costsTableAdapter();

            if (App.Current.Properties["SelectedEmployee"] != null)
            {
                DataRowView drv = (DataRowView)App.Current.Properties["SelectedEmployee"];
                eid = (int)drv["eid"];
                string name = (string)drv["name"];
                lblAddProjectCostEmployee.Content = name;
                App.Current.Properties["SelectedEmployee"] = null;
            }

            if (App.Current.Properties["SelectedProject"] != null)
            {
                DataRowView drv = (DataRowView)App.Current.Properties["SelectedProject"];
                pid = (int)drv["pid"];
                string projectname = (string)drv["projectname"];
                lblAddProjectCostProject.Content = projectname;
                App.Current.Properties["SelectedProject"] = null;
            }

            try 
            { 
                if((bool)App.Current.Properties["myProject"] == true)
                {
                    DataRowView drv2 = (DataRowView)App.Current.Properties["thisProjectCost"];
                    lblAddProjectCostProject.Content = (string)drv2["projectname"];

                    lblAddProjectCostEmployee.Content = (string)App.Current.Properties["User"];
                    btnAddProjectCostEmployee.Visibility = Visibility.Collapsed;
                    btnAddProjectCostProject.Visibility = Visibility.Collapsed;
                    eid = (int)App.Current.Properties["UserId"];
                    pid = (int)drv2["pid"];
                }
           }
            catch { }


        }
    }
}













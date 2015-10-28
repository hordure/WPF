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
            AddProjectCost_Project win = new AddProjectCost_Project();
            win.ShowDialog();
            UpdateWindow();

        }

        private void btnAddProjectCostEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddProjectCost_Employee win = new AddProjectCost_Employee();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnAddProjectCost_Click(object sender, RoutedEventArgs e)
        {
            string description = (string)txtpcdescription.Text;
            DateTime costdate = (DateTime)dpCostDate.SelectedDate;
            int cost = Convert.ToInt32(txtcost.Text);

            try
            {
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

            if (App.Current.Properties["AddProjectCost_Employee"] != null)
            {
                DataRowView drv = (DataRowView)App.Current.Properties["AddProjectCost_Employee"];
                eid = (int)drv["eid"];
                string name = (string)drv["name"];
                lblAddProjectCostEmployee.Content = name;
                App.Current.Properties["AddProjectCost_Employee"] = null;
            }

            if (App.Current.Properties["AddProjectCost_Project"] != null)
            {
                DataRowView drv = (DataRowView)App.Current.Properties["AddProjectCost_Project"];
                pid = (int)drv["pid"];
                string projectname = (string)drv["projectname"];
                lblAddProjectCostProject.Content = projectname;
                App.Current.Properties["AddProjectCost_Project"] = null;
            }


        }
    }
}

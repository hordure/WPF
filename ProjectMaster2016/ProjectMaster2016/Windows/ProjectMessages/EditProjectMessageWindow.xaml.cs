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
    /// Interaction logic for EditProjectMessageWindow.xaml
    /// </summary>
    public partial class EditProjectMessageWindow : Window
    {
        public int eid;
        public int pid;

        public EditProjectMessageWindow()
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
            //The selected project to edit from ProjectMessagesWindow
            //
            DataRowView drv = (DataRowView)App.Current.Properties["projectMessage"];
            int pmid = (int)drv["pmid"];

            string role = (string)App.Current.Properties["Role"];
            if (role == "user" || role == "poweruser")
            {
                btnEditProjectMessageProject.Visibility = Visibility.Collapsed;
                btnEditProjectMessageEmployee.Visibility = Visibility.Collapsed;
            }
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table project_costs. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.project_messagesTableAdapter projectmasterDataSetproject_messagesTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_messagesTableAdapter();

            try
            {
                //
                //Fill message details
                //
                projectmasterDataSetproject_messagesTableAdapter.FillByProjectMessageId(projectmasterDataSet.project_messages, pmid);
                System.Windows.Data.CollectionViewSource project_messagesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("project_messagesViewSource")));
                project_messagesViewSource.View.MoveCurrentToFirst();
            }
            catch (Exception ) { }
            
            //
            //Check if user has selected a project from SelectProjectWindow
            //
            if (App.Current.Properties["SelectedProject"] != null)
            {
                DataRowView drv2 = (DataRowView)App.Current.Properties["SelectedProject"];
                lblEditProjectMessage_Project.Content = (string)drv2["projectname"];
                pid = (int)drv2["pid"];
                lblpid.Content = (int)drv2["pid"];
                App.Current.Properties["SelectedProject"] = null;
            }

            //
            //Check if user has selected an employee from SelectEmployeeWindow
            //
            if (App.Current.Properties["SelectedEmployee"] != null)
            {
                DataRowView drv3 = (DataRowView)App.Current.Properties["SelectedEmployee"];
                lblEditProjectMessage_Employee.Content = (string)drv3["name"];
                eid = (int)drv3["eid"];
                lbleid.Content = (int)drv3["eid"];
                App.Current.Properties["SelectedEmployee"] = null;
            }
        }


        private void btnEditProjectMessage_Employee_Click(object sender, RoutedEventArgs e)
        {
            //
            //Go to SelectEmployeeWindow
            //
            SelectEmployeeWindow win = new SelectEmployeeWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnEditProjectMessage_Project_Click(object sender, RoutedEventArgs e)
        {
            //
            //Go to SelectProjectWindow
            //
            SelectProjectWindow win = new SelectProjectWindow();
            //EditProjectCost_ProjectWindow win = new EditProjectCost_ProjectWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnUptadeProjectMessage_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Viltu vista breytingar?", "Breyta skilaboð", MessageBoxButton.YesNo);
            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    DataRowView drv = (DataRowView)App.Current.Properties["projectMessage"];

                    int pmid = (int)drv["pmid"];

                    projectmasterDataSetTableAdapters.project_messagesTableAdapter pma = new projectmasterDataSetTableAdapters.project_messagesTableAdapter();
                    pma.UpdateProjectMessage((int)lblpid.Content, (int)lbleid.Content, txtMessage.Text, DateTime.Now, pmid);
                    
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ekki hægt að vista breytingar");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

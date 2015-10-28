using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectMaster2016
{

    /// <summary>
    /// Interaction logic for AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {

        public AddProjectWindow()
        {
            InitializeComponent();
        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string pname = txtTitle.Text;
            int employeeid = (int)cbEmployee.SelectedValue;
            string pdescription = txtDescription.Text;
            DateTime creationDate = DateTime.Now;
            bool isFinished = false;

            DateTime? duedate = null;
            if(dpDueDate.SelectedDate !=  null)
            {
                duedate = dpDueDate.SelectedDate;
            }
            else
            {
                duedate = null;
            }

            try
            {
                projectmasterDataSetTableAdapters.projectTableAdapter pta = new projectmasterDataSetTableAdapters.projectTableAdapter();
                //pta.Insert(pname, employeeid, isFinished, duedate, creationDate, pdescription);
                //pta.Insert(pname, employeeid,pdescription,isFinished, null ,creationDate);
                decimal temp = (decimal)pta.InsertProject(pname, employeeid, isFinished, duedate, creationDate, pdescription);

                int insertedpid = Convert.ToInt32(temp);
                projectmasterDataSetTableAdapters.project_messagesTableAdapter pma = new projectmasterDataSetTableAdapters.project_messagesTableAdapter();
                pma.Insert(insertedpid, employeeid, "*** Verkefni stofnað ***", creationDate, null, null);
            }
            catch
            {
                MessageBox.Show("Verður að fylla í viðeigandi reiti");
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            lblUserId.Content = (int)App.Current.Properties["UserId"];
            lblUserId.Visibility = Visibility.Collapsed;

            //preset projectemployee if opened through UserWindow(myprojects) 
            string s = (string)App.Current.Properties["MyProject"];
            if(s == "y")
            {
                cbEmployee.Visibility = Visibility.Collapsed;
                cbEmployee.SelectedValue = (int)App.Current.Properties["UserId"];
                lblEmployee.Visibility = Visibility.Visible;
                lblEmployee.Content = (string)App.Current.Properties["User"];
                
            }
            else 
            { 

                ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
                // Load data into the table employee. You can modify this code as needed.
                ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter projectmasterDataSetemployeeTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter();
                projectmasterDataSetemployeeTableAdapter.Fill(projectmasterDataSet.employee);
                System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
                employeeViewSource.View.MoveCurrentToFirst();
            }

        }
    }
}

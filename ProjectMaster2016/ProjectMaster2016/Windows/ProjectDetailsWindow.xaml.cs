using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectMaster2016
{
    /// <summary>
    /// Interaction logic for ProjectDetailsWindow.xaml
    /// </summary>
    public partial class ProjectDetailsWindow : Window
    {
        private static int pid;
        private static int eid;

        ToolTip editTip = new ToolTip { Content = "Ýttu til að breyta verkefni" };
        ToolTip delTip = new ToolTip { Content = "Ýttu til að eyða verkefni" };

        public ProjectDetailsWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();


        }

        private void UpdateWindow()
        {
            eid = (int)App.Current.Properties["UserId"];

            //User logging out
            if ((string)App.Current.Properties["CloseWindow"] == "Close")
            {
                this.Close();
            }

            lblName.Content = App.Current.Properties["User"];

            DataRowView drv = (DataRowView)App.Current.Properties["thisProject"];
            txtblTitle.Text = (string)drv["projectname"];
            pid = (int)drv["pid"];            
            

            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            projectmasterDataSetTableAdapters.projectTableAdapter pta = new projectmasterDataSetTableAdapters.projectTableAdapter();
            try 
            { 
                // fill view with selectd project
                pta.FillByProjectId(projectmasterDataSet.project, pid);
                System.Windows.Data.CollectionViewSource projectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectViewSource")));
                projectViewSource.View.MoveCurrentToFirst();
            }
            catch { }

            //disable edit, remove and add projectemployee -> if user is not owner/creator of project
            int isOwner = (int)pta.GetProjectOwner(pid);
            if (isOwner != eid)
            {
                btnRemoveProject.Visibility = Visibility.Collapsed;
                btnEditProject.Visibility = Visibility.Collapsed;
                btnAddProjectEmployee.Visibility = Visibility.Collapsed;
                btnRemoveProjectEmployee.Visibility = Visibility.Collapsed;

            }

            lblEmp.Content = pta.GetEmployeeName((int)drv["pid"]);

            //display project status finished/unfinished
            bool status = (bool)drv["projectisfinished"];
            if (status == false)
            {
                lblStatus.Content = "Í vinnslu";
            }
            else
            {
                lblStatus.Content = "Lokið";
            }

            //display creationdate
            try
            {
                DateTime created = (DateTime)drv["pdate"];
                if (created != null)
                {
                    lblCreated.Content = created.ToLongDateString();
                }
            }
            catch
            {
            }

            //display deadline
            try
            {
                DateTime due = (DateTime)drv["pdeadline"];
                lblDue.Content = due.ToLongDateString();
            }
            catch
            {
                lblDue.Content = "Ekki tilgreint";
            }


            ProjectMaster2016.projectmasterDataSetTableAdapters.project_employeesTableAdapter peta = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_employeesTableAdapter();
            try
            {
                //fill  relatedentries -> messages, costs and hours
                peta.FillByAllRelatedEntries(projectmasterDataSet.project_employees, pid);
                System.Windows.Data.CollectionViewSource project_employeesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("project_employeesViewSource")));
                project_employeesViewSource.View.MoveCurrentToFirst();
            }
            catch (Exception)
            {

            }

            // display statistics
            try { lblentriesCount.Content = (int)pta.CountOfRelatedProjectEntries(pid); }
            catch { }
            try { lbltotalHours.Content = (decimal)pta.CountOfProjectHours(pid); }
            catch { }
            try { lbltotalCost.Content = (int)pta.SumOfProjectCosts(pid); }
            catch { }
            
            //fill for add projectemployeelistbox
            try 
            { 
                ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter projectmasterDataSetemployeeTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter();
                projectmasterDataSetemployeeTableAdapter.FillByProjectEmployeeName(projectmasterDataSet.employee, pid);
                System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
                employeeViewSource.View.MoveCurrentToFirst();
            }
            catch { }
        }

        private void btnProjectCost_Click(object sender, RoutedEventArgs e)
        {
            //Restrict addProjectCost to this user and project
            App.Current.Properties["thisProjectCost"] = App.Current.Properties["thisProject"];
            App.Current.Properties["myProject"] = true;
            ProjectCostsWindow win = new ProjectCostsWindow();
            win.ShowDialog();
            UpdateWindow();
            App.Current.Properties["thisProjectCost"] = null;
            App.Current.Properties["myProject"] = false;
            

        }

        private void btnProjectMessages_Click(object sender, RoutedEventArgs e)
        {
            //Restrict addProjectMessage to this user and project
            App.Current.Properties["thisProjectMessage"] = App.Current.Properties["thisProject"];
            App.Current.Properties["myProject"] = true;
            ProjectMessagesWindow win = new ProjectMessagesWindow();
            win.ShowDialog();
            UpdateWindow();
            App.Current.Properties["thisProjectMessage"] = null;
            App.Current.Properties["myProject"] = false;
            
        }

        private void btnProjectHours_Click(object sender, RoutedEventArgs e)
        {
            //Restrict addProjectHours to this user and project
            App.Current.Properties["thisProjectHours"] = App.Current.Properties["thisProject"];
            App.Current.Properties["myProject"] = true;
            ProjectHoursWindow win = new ProjectHoursWindow();
            win.ShowDialog();
            UpdateWindow();
            App.Current.Properties["thisProjectHours"] = null;
            App.Current.Properties["myProject"] = false;
            

        }

        private void btnAddProjectEmployee_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["project"] = App.Current.Properties["thisProject"];
            DataRowView drv = (DataRowView)App.Current.Properties["project"];
            int pid = (int)drv["pid"];
            AddProjectEmployeeWindow win = new AddProjectEmployeeWindow();
            win.ShowDialog();
            App.Current.Properties["project"] = null;
            UpdateWindow();
        }

        private void btnRemoveProjectEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Fjarlægja starfsmann úr verkefni?", "Fjarlægja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int peid = (int)lbProjectEmployees.SelectedValue;
                try
                {
                    ProjectMaster2016.projectmasterDataSetTableAdapters.project_employeesTableAdapter peta = new projectmasterDataSetTableAdapters.project_employeesTableAdapter();
                    peta.DeleteProjectEmployee(peid);
                    UpdateWindow();
                }
                catch
                {
                    MessageBox.Show("Ekki tókst að eyða færslu");
                }
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Viltu skrá þig út?", "Útskráning", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();

                App.Current.Properties["CloseWindow"] = "Close";
            }
        }

        private void btnEditProject_Click(object sender, RoutedEventArgs e)
        {
            //edit project
            App.Current.Properties["project"] = App.Current.Properties["thisProject"];
            EditProjectWindow win = new EditProjectWindow();
            win.ShowDialog();
            App.Current.Properties["project"] = null;
            UpdateWindow();
        }

        private void btnRemoveProject_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult result = MessageBox.Show("Ertu viss um að þú viljir eyða verkefni", "Eyða verkefni", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    projectmasterDataSetTableAdapters.projectTableAdapter pta = new projectmasterDataSetTableAdapters.projectTableAdapter();
                    pta.DeleteProject(pid);
                    UpdateWindow();

                }
                catch
                {
                    MessageBox.Show("Ekki hægt að eyða verkefni.  Fjarlægja verður tengdar færslur fyrst (starfsmenn, skilaboð, kostnað og tímaskráningar) ", "Framkvæmd mistókst");
                }
            }
        }

        private void btnEditProject_MouseEnter(object sender, MouseEventArgs e)
        {
            editTip.IsOpen = true;
        }

        private void btnEditProject_MouseLeave(object sender, MouseEventArgs e)
        {
            editTip.IsOpen = false;
        }

        private void btnRemoveProject_MouseEnter(object sender, MouseEventArgs e)
        {
            delTip.IsOpen = true;
        }

        private void btnRemoveProject_MouseLeave(object sender, MouseEventArgs e)
        {
            delTip.IsOpen = false;
        }
    }
}

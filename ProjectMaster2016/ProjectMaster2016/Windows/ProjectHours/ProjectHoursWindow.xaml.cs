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
    /// Interaction logic for ProjectHoursWindow.xaml
    /// </summary>
    public partial class ProjectHoursWindow : Window
    {
        private static int pid;
        private static int eid;

        public ProjectHoursWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
        }

        private void UpdateWindow()
        {
            //display user's name in upper right corner 
            lblName.Content = App.Current.Properties["User"];
            
            //disable add, edit and remove for 'poweruser' in admin menu

      

            string role = (string)App.Current.Properties["Role"];
            if (role == "poweruser" && App.Current.Properties["thisProject"] == null )
            {
                btnAddProjectHours.Visibility = Visibility.Collapsed;
                ctx.Visibility = Visibility.Collapsed;
            }

            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table project_hours. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.project_hoursTableAdapter projectmasterDataSetproject_hoursTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_hoursTableAdapter();

            if (App.Current.Properties["thisProjectHours"] == null)
            {
                //
                //This loads Hours for all Projects. For access through admin menu: add, edit and remove enabled (admin role) -> add,edit and remove disabled (poweruser role)
                //
                projectmasterDataSetproject_hoursTableAdapter.FillByProjectName(projectmasterDataSet.project_hours);
                System.Windows.Data.CollectionViewSource project_hoursViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("project_hoursViewSource")));
                project_hoursViewSource.View.MoveCurrentToFirst();
            }
            else
            {
                //
                //This loads Hours for a selected project
                //
                DataRowView drv = (DataRowView)App.Current.Properties["thisProjectHours"];
                pid = (int)drv["pid"];
                projectmasterDataSetproject_hoursTableAdapter.FillProjectHoursByPId(projectmasterDataSet.project_hours, pid);
                
            }

            //
            //disable edit and delete if user is not owner/creator of project
            //
            eid = (int)App.Current.Properties["UserId"];
            projectmasterDataSetTableAdapters.projectTableAdapter pta = new projectmasterDataSetTableAdapters.projectTableAdapter();
            try 
            { 
                int isOwner = (int)pta.GetProjectOwner(pid);
                if (isOwner != eid)
                {
                    ctx.Visibility = Visibility.Collapsed;
                }

                //disable poweruser to edit "other projects"
                if (role == "poweruser" && isOwner != eid)
                {
                    btnAddProjectHours.Visibility = Visibility.Collapsed;
                    ctx.Visibility = Visibility.Collapsed;
                }
            }
            catch { }

            //ensure add, edit and remove are enabled for admin
            if (role == "admin")
            {
                btnAddProjectHours.Visibility = Visibility.Visible;
                ctx.Visibility = Visibility.Visible;
            }

            //ensure add is enabled for poweruser
            if (role == "poweruser" && App.Current.Properties["thisProject"] != null)
            {
                btnAddProjectHours.Visibility = Visibility.Visible;
            }
        }

        private void menu_EditProjectHours_Click(object sender, RoutedEventArgs e)
        {
            //
            //Edit hours. Userrights -> project owner/creator and admin
            //
            App.Current.Properties["ProjecthoursToEdit"] = project_hoursDataGrid.SelectedItem;
            EditProjectHoursWindow win = new EditProjectHoursWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void menu_RemoveProjectHours_Click(object sender, RoutedEventArgs e)
        {
            //
            //Remove hoursentry.  Userrights -> project owner/creator and admin
            //
            DataRowView drv = (DataRowView)project_hoursDataGrid.SelectedItem;
            string description = (string)drv["hourdescription"];
            int phid = (int)project_hoursDataGrid.SelectedValue;
            MessageBoxResult dlg = MessageBox.Show("Ertu viss um að þú viljir eyða færslu nr. "+ phid  + "?" , "Eyða færslu?", MessageBoxButton.YesNo);
            

            if (dlg == MessageBoxResult.Yes)
            {
                try
                {
                    projectmasterDataSetTableAdapters.project_hoursTableAdapter phta = new projectmasterDataSetTableAdapters.project_hoursTableAdapter();
                    phta.DeleteProjectHours(phid);
                    MessageBox.Show("Færslu nr. " + phid + " hefur verið eytt.");
                    UpdateWindow();

                }
                catch (Exception)
                {
                    //MessageBox.Show(exc.ToString());
                    MessageBox.Show("Ekki hægt að eyða færslu nr." + phid , "Framkvæmd mistókst");
                }
            }
        }

        private void btnAddProjectHours_Click(object sender, RoutedEventArgs e)
        {
            AddProjectHourWindow win = new AddProjectHourWindow();
            win.ShowDialog();
            UpdateWindow();
            
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

        private void btnfillByDate_Click(object sender, RoutedEventArgs e)
        {
            //
            //Select daterange by hourtimestamp
            //
            if (dpFromDate.SelectedDate <= dpToDate.SelectedDate)
            {
                DateTime from = (DateTime)dpFromDate.SelectedDate;
                DateTime to = (DateTime)dpToDate.SelectedDate.Value.AddDays(1);
                ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
                ProjectMaster2016.projectmasterDataSetTableAdapters.project_hoursTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_hoursTableAdapter();

                if (App.Current.Properties["thisProjectHours"] == null)
                {
                    projectmasterDataSetprojectTableAdapter.FillByDate(projectmasterDataSet.project_hours, from, to);
                }
                else 
                {
                    projectmasterDataSetprojectTableAdapter.FillBythisProjectDate(projectmasterDataSet.project_hours, from, to, pid);
                }

                string fromlbl = dpFromDate.SelectedDate.Value.ToLongDateString();

                string tolbl = dpToDate.SelectedDate.Value.ToLongDateString();

                lbldateRange.Content = fromlbl + " - " + tolbl;
            }
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
            dpToDate.SelectedDate = null;
            dpFromDate.SelectedDate = null;
        }
    }
}

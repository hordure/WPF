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
    /// Interaction logic for ProjectCostsWindow.xaml
    /// </summary>
    public partial class ProjectCostsWindow : Window
    {
        private static int pid;
        private static int eid;

        public ProjectCostsWindow()
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
            if (role == "poweruser" && App.Current.Properties["thisProject"] == null)
            {
                
                btnAddProject.Visibility = Visibility.Collapsed;
                ctxMenu.Visibility = Visibility.Collapsed;
            }
            
            
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table project_costs. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.project_costsTableAdapter projectmasterDataSetproject_costsTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_costsTableAdapter();
            
            if(App.Current.Properties["thisProjectCost"] == null)
            {
                //
                //Fill all costs for all projects. For access through admin menu: add, edit and remove enabled (admin role) -> add,edit and remove disabled (poweruser role)
                //

                projectmasterDataSetproject_costsTableAdapter.Fill(projectmasterDataSet.project_costs);
                System.Windows.Data.CollectionViewSource project_costsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("project_costsViewSource")));
                project_costsViewSource.View.MoveCurrentToFirst();
            }
            else
            {
                //
                //Fill with costs related to a particular project
                //
 
                DataRowView drv = (DataRowView)App.Current.Properties["thisProjectCost"];
                pid = (int)drv["pid"];
                projectmasterDataSetproject_costsTableAdapter.FillProjectCostsByPId(projectmasterDataSet.project_costs, pid);
                
                
            }

            //display when no daterange is selected
            lbldateRange.Content = "Allt";

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
                    ctxMenu.Visibility = Visibility.Collapsed;
                }

                //disable poweruser to edit "other projects"
                if (role == "poweruser" && isOwner !=eid)
                {
                    btnAddProject.Visibility = Visibility.Collapsed;
                    ctxMenu.Visibility = Visibility.Collapsed;
                }
            }
            catch { }

            
            //ensure add, edit and remove are enabled for admin
            if (role == "admin")
            {
                btnAddProject.Visibility = Visibility.Visible;
                ctxMenu.Visibility = Visibility.Visible;
            }

            //ensure add is enable for poweruser
            if (role == "poweruser" && App.Current.Properties["thisProject"] != null)
            {
                btnAddProject.Visibility = Visibility.Visible;
            }
        }

        private void menu_EditProjectCost_Click(object sender, RoutedEventArgs e)
        {
            //
            //Edit cost. Userrights -> project owner/creator and admin
            //
            App.Current.Properties["projectCost"] = project_costsDataGrid.SelectedItem;
            EditProjectCostWindow win = new EditProjectCostWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void menu_RemoveProjectCost_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)project_costsDataGrid.SelectedItem;
            string description = (string)drv["costdescription"];
            int pcid = (int)project_costsDataGrid.SelectedValue;
            MessageBoxResult result = MessageBox.Show("Ertu viss um að þú viljir eyða færslu nr. " + pcid + "?", "Eyða færslu", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            { 
                try
                {
                    projectmasterDataSetTableAdapters.project_costsTableAdapter pca = new projectmasterDataSetTableAdapters.project_costsTableAdapter();
                    pca.DeleteProjectCost(pcid);
                    MessageBox.Show("Færslu nr. " + pcid + " hefur verið eytt.");
                    UpdateWindow();

                }
                catch(Exception )
                {
                    MessageBox.Show("Ekki hægt að eyða færslu nr." + pcid , "Framkvæmd mistókst");
                }
            }
        }

        private void btnAddProjectCost_Click(object sender, RoutedEventArgs e)
        {
            AddProjectCostWindow win = new AddProjectCostWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            //
            //User log out
            //
            MessageBoxResult result = MessageBox.Show("Viltu skrá þig út?", "Útskráning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
                App.Current.Properties["CloseWindow"] = "Close";
            }

        }

        private void btnfillByDate_Click(object sender, RoutedEventArgs e)
        {
            if (dpFromDate.SelectedDate <= dpToDate.SelectedDate)
            {
                //
                //Select daterange by messagetimestamp
                //
                DateTime from = (DateTime)dpFromDate.SelectedDate;
                DateTime to = (DateTime)dpToDate.SelectedDate.Value.AddDays(1);
                ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
                ProjectMaster2016.projectmasterDataSetTableAdapters.project_costsTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_costsTableAdapter();

                if (App.Current.Properties["thisProjectCost"] == null)
                { 
                    projectmasterDataSetprojectTableAdapter.FillByDate(projectmasterDataSet.project_costs, from, to);
                }
                else 
                {
                    projectmasterDataSetprojectTableAdapter.FillBythisProjectDate(projectmasterDataSet.project_costs, from, to, pid);
                }
                string fromlbl = dpFromDate.SelectedDate.Value.ToLongDateString();

                string tolbl = dpToDate.SelectedDate.Value.ToLongDateString();

                lbldateRange.Content = fromlbl + " - " + tolbl;
            }
            else
            {
                MessageBox.Show("Fylla verður rétt í dagsetningar");
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

using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
       

        public interface ISuggestionProvider
        {
            IEnumerable GetSuggestions(string filter);
        }

        public ProjectWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
        }
            
        private void UpdateWindow()
        {
            //Check if user has Logged out
            if((string)App.Current.Properties["CloseWindow"] == "Close")
            {
                this.Close();
            }
            string role = (string)App.Current.Properties["Role"];

            if (role == "poweruser")
            {
                btnRemoveProject.Visibility = Visibility.Collapsed;
                btnAddProject.Visibility = Visibility.Collapsed;
                btnEditProject.Visibility = Visibility.Collapsed;
                menu_EditProject.Visibility = Visibility.Collapsed;
                menu_RemoveProject.Visibility = Visibility.Collapsed;
                sep.Visibility = Visibility.Collapsed;
            }
            
            
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table project. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            projectmasterDataSetprojectTableAdapter.FillWithEmployeeName(projectmasterDataSet.project);
            System.Windows.Data.CollectionViewSource projectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectViewSource")));
            projectViewSource.View.MoveCurrentToFirst();
            
            //Username in the upper right corner
            lblName.Content = App.Current.Properties["User"];

            //Default daterange
            lbldateRange.Content = "Allt";

            //ensure add, edit and remove are enabled for admin
            if (role == "admin")
            {
                btnRemoveProject.Visibility = Visibility.Visible;
                btnAddProject.Visibility = Visibility.Visible;
                btnEditProject.Visibility = Visibility.Visible;
                menu_EditProject.Visibility = Visibility.Visible;
                menu_RemoveProject.Visibility = Visibility.Visible;
                sep.Visibility = Visibility.Visible;
            }

        }

        private void menu_EditProject_Click(object sender, RoutedEventArgs e)
        {
            //Send current project to edit window
            App.Current.Properties["project"] = projectDataGrid.SelectedItem;
            EditProjectWindow win = new EditProjectWindow();
            win.ShowDialog();
            App.Current.Properties["project"] = null;
            UpdateWindow();

        }




        private void btnRemoveProject_Click(object sender, RoutedEventArgs e)
        {
            DeleteProject();

        }

        //Delete function used by minus button and context menu
        private void DeleteProject()
        {
            int pid = (int)projectDataGrid.SelectedValue;
            MessageBoxResult result = MessageBox.Show("Ertu viss um að þú viljir eyða verkefni", "Eyða verkefni", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            { 
                try
                {
                    projectmasterDataSetTableAdapters.projectTableAdapter pta = new projectmasterDataSetTableAdapters.projectTableAdapter();
                    pta.DeleteProject(pid);
                    UpdateWindow();

                }
                catch
                {
                    MessageBox.Show("Ekki hægt að eyða verkefni", "Framkvæmd mistókst");
                }
            }
        }

        private void btnAddProject_Click(object sender, RoutedEventArgs e)
        {
            AddProjectWindow win = new AddProjectWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void btnEditProject_Click(object sender, RoutedEventArgs e)
        {
            //Send current project to edit window
            App.Current.Properties["project"] = projectDataGrid.SelectedItem;
            EditProjectWindow win = new EditProjectWindow();
            win.ShowDialog();
            App.Current.Properties["project"] = null;
            UpdateWindow();
        }

        private void menu_RemoveProject_Click(object sender, RoutedEventArgs e)
        {
            DeleteProject();
        }

        private void menu_ProjectCost_Click(object sender, RoutedEventArgs e)
        {
            //Select costs related to this/selected project in projectCosts window
            App.Current.Properties["thisProjectCost"] = projectDataGrid.SelectedItem;
            ProjectCostsWindow win = new ProjectCostsWindow();
            win.ShowDialog();
            App.Current.Properties["thisProjectCost"] = null;
            UpdateWindow();
        }

        private void menu_ProjectMessages_Click(object sender, RoutedEventArgs e)
        {
            //View messages related to this/selected project in projectMessages window
            App.Current.Properties["thisProjectMessage"] = projectDataGrid.SelectedItem;
            ProjectMessagesWindow win = new ProjectMessagesWindow();
            win.ShowDialog();
            App.Current.Properties["thisProjectMessage"] = null;
            UpdateWindow();
        }

        private void menu_ProjectHours_Click(object sender, RoutedEventArgs e)
        {
            //View hours related to this/selected project in projectHours window
            App.Current.Properties["thisProjectHours"] = projectDataGrid.SelectedItem;
            ProjectHoursWindow win = new ProjectHoursWindow();
            win.ShowDialog();
            App.Current.Properties["thisProjectHours"] = null;
            UpdateWindow();

        }

        private void menu_relateEntries_Click(object sender, RoutedEventArgs e)
        {
            //view hours, costs and messages in relatedEntries window
            App.Current.Properties["project"] = projectDataGrid.SelectedItem;
            RelatedEntriesWindow win = new RelatedEntriesWindow();
            win.ShowDialog();
            App.Current.Properties["project"] = null;
            UpdateWindow();

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            //Log out
            MessageBoxResult result = MessageBox.Show("Viltu skrá þig út?", "Útskráning", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                this.Close();
                App.Current.Properties["CloseWindow"] = "Close";
            }
        }

        private void btnfillByDate_Click(object sender, RoutedEventArgs e)
        {
            //view results by date range
            if(dpFromDate.SelectedDate <= dpToDate.SelectedDate)
            { 
                ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
                ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            
                projectmasterDataSetprojectTableAdapter.FillByDate(projectmasterDataSet.project, dpFromDate.SelectedDate, dpToDate.SelectedDate.Value.AddDays(1));

                string from = dpFromDate.SelectedDate.Value.ToLongDateString();

                string to = dpToDate.SelectedDate.Value.ToLongDateString();

                lbldateRange.Content = from + " - " + to;
            }
            else
            {
                MessageBox.Show("Fylla verður rétt í dagsetningar");
            }

        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            //clear selected dates (all results)
            UpdateWindow();
            dpToDate.SelectedDate = null;
            dpFromDate.SelectedDate = null;
        }




    }
}


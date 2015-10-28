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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectMaster2016
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public static int UserId;
        
        ToolTip myprojectstooltip= new ToolTip { Content = "Verkefni sem þú hefur stofnað eða hefur umsjón með, getur stofnað, breytt eða eytt" };
        ToolTip otherprojectstooltip = new ToolTip { Content = "Verkefni sem aðrir starfsmenn hafa bætt þér í. Þú getur einungis bætt við færslum, en ekki eytt eða breytt" };
        SolidColorBrush color = new SolidColorBrush(Color.FromArgb(0xFF, 0xC5, 0xE9, 0xF6));

        public UserWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(UserWindow_Loaded);
            

        }

        private void UserWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.FindResource("Storyboard1") as Storyboard;
            Storyboard.SetTarget(sb, this.grid1);
            sb.Begin();
  
            spLeft.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xC5, 0xE9, 0xF7));

            if ((string)App.Current.Properties["CloseWindow"] == "Close")
            {
                this.Close();
            }
        }

        private void editEmployee_Click(object sender, RoutedEventArgs e)
        {
            EditEmployeeWindow win = new EditEmployeeWindow();
            win.ShowDialog();
            UpdateWindow(sender, e);
        }

        private void addProject_Click(object sender, RoutedEventArgs e)
        {
            //disable employee selection in addProjectWindow 
            App.Current.Properties["MyProject"] = "y";
            AddProjectWindow win = new AddProjectWindow();
            win.ShowDialog();
            App.Current.Properties["MyProject"] = null;
            UpdateWindow(sender, e);
        }

        private void menu_projectCosts_Click(object sender, RoutedEventArgs e)
        {
            ProjectCostsWindow win = new ProjectCostsWindow();
            win.ShowDialog();
            UpdateWindow(sender, e);
        }

        private void menu_projectHours_Click(object sender, RoutedEventArgs e)
        {
            ProjectHoursWindow win = new ProjectHoursWindow();
            win.ShowDialog();
            UpdateWindow(sender, e);
        }

        private void menu_projectMessages_Click(object sender, RoutedEventArgs e)
        {
            ProjectMessagesWindow win = new ProjectMessagesWindow();
            win.ShowDialog();
            UpdateWindow(sender, e);
        }

        private void menu_projectsList_Click(object sender, RoutedEventArgs e)
        {
            ProjectWindow win = new ProjectWindow();
            win.ShowDialog();
            UpdateWindow(sender, e);
            
        }

        private void menu_Employee_List_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow win = new EmployeeWindow();
            win.ShowDialog();
            UpdateWindow(sender, e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow(sender, e);
           
        }

        private void UpdateWindow(object sender, RoutedEventArgs e)
        {

            UserId = (int)App.Current.Properties["UserId"];
            string role = (string)App.Current.Properties["Role"];
            //
            //disable admin menu and restrict employee menu for role="user" 
            //
            if (role == "user" )
            {
                admin.Visibility = Visibility.Collapsed;
                admin1.Visibility = Visibility.Collapsed;
                editEmployee.Visibility = Visibility.Collapsed;
            }
            //
            //restrict admin- and employee-menu for role="poweruser" 
            //
            if ( role == "poweruser")
            {
                admin.Visibility = Visibility.Collapsed;
                admin2.Header = "Öll verkefni";
                editEmployee.Visibility = Visibility.Collapsed;
            }

            //
            //fill startup screen with unfinished "myprojects"
            //
            MPUnfinished();

            //
            //project statistics on left side of window
            //
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            lblMPUnfinished.Content = (int)projectmasterDataSetprojectTableAdapter.MPUnfinishedCount(UserId);
            lblMPFinished.Content = (int)projectmasterDataSetprojectTableAdapter.MPFinishedCount(UserId);
            lblMPTotal.Content = (int)projectmasterDataSetprojectTableAdapter.MPCount(UserId);
            lblRPFinished.Content = (int)projectmasterDataSetprojectTableAdapter.RPFinishedCount(UserId);
            lblRPUnfinished.Content = (int)projectmasterDataSetprojectTableAdapter.RPUnfinishedCount(UserId);
            lblRPTotal.Content = (int)projectmasterDataSetprojectTableAdapter.RPTotal(UserId);
            //
            //display name of logged in employee, upper right corner
            //
            lblName.Content = App.Current.Properties["User"];

            string temp = (string)App.Current.Properties["CloseWindow"];
            if (temp == "Close")
            {
                this.Close();
            }
      

            UserWindow_Loaded(sender, e);
        }

        //
        //All "my projects"
        //
        private void btnMPAll_Click(object sender, RoutedEventArgs e)
        {
            MPAll(sender, e);
            
            
            
        }

        //
        //All "my projects"
        //
        private void MPAll(object sender, RoutedEventArgs e)
        {
           
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            try
            { 
                projectmasterDataSetprojectTableAdapter.FillProjectsByEmployeeId(projectmasterDataSet.project, UserId);
            }
            catch { }
            
            
            btnMyProjects.Background = color;
            btnMPUnfinished.Background = Brushes.Transparent;
            btnMPAll.Background = color;
            btnMPFininshed.Background = Brushes.Transparent;
            btnRelateProjects.Background = Brushes.Transparent;
            btnRPAll.Background = Brushes.Transparent;
            btnRPFininshed.Background = Brushes.Transparent;
            btnRPUnfinished.Background = Brushes.Transparent;

            
            
        }



        private void btnMPUnfinished_Click(object sender, RoutedEventArgs e)
        {

            MPUnfinished();
            
        }

        //
        //Unfinished "my projects"
        //
        private void MPUnfinished()
        {
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            projectmasterDataSetprojectTableAdapter.FillMPByUnfinished(projectmasterDataSet.project, UserId);



            btnMyProjects.Background = color;
            btnMPUnfinished.Background = color;
            btnMPAll.Background = Brushes.Transparent;
            btnMPFininshed.Background = Brushes.Transparent;
            btnRelateProjects.Background = Brushes.Transparent;
            btnRPAll.Background = Brushes.Transparent;
            btnRPFininshed.Background = Brushes.Transparent;
            btnRPUnfinished.Background = Brushes.Transparent;

        }

        //
        //Finished "my projects"
        //
        private void btnMPFininshed_Click_1(object sender, RoutedEventArgs e)
        {
            
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            projectmasterDataSetprojectTableAdapter.FillMPByFinished(projectmasterDataSet.project, UserId);

            btnMyProjects.Background = color;
            btnMPUnfinished.Background = Brushes.Transparent;
            btnMPAll.Background = Brushes.Transparent;
            btnMPFininshed.Background = color;
            btnRelateProjects.Background = Brushes.Transparent;
            btnRPAll.Background = Brushes.Transparent;
            btnRPFininshed.Background = Brushes.Transparent;
            btnRPUnfinished.Background = Brushes.Transparent;
           
            
        }

        private void btnMyProjects_Click(object sender, RoutedEventArgs e)
        {
            
            MPUnfinished();

        }

        private void btnRelateProjects_Click(object sender, RoutedEventArgs e)
        {
            RPUnfinished();
        }

        //
        //All "related projects" ie. projects that other employees have added current user to
        //
        private void RPAll(object sender, RoutedEventArgs e)
        {

            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            projectmasterDataSetprojectTableAdapter.FillRPByEid(projectmasterDataSet.project, UserId);

          

            btnMyProjects.Background = Brushes.Transparent;
            btnMPUnfinished.Background = Brushes.Transparent;
            btnMPAll.Background = Brushes.Transparent;
            btnMPFininshed.Background = Brushes.Transparent;
            btnRelateProjects.Background = color;
            btnRPAll.Background  = color;
            btnRPFininshed.Background = Brushes.Transparent;
            btnRPUnfinished.Background = Brushes.Transparent;
            
        }

        private void btnRPAll_Click(object sender, RoutedEventArgs e)
        {
            RPAll(sender, e);
        }

        private void btnRPUnfinished_Click(object sender, RoutedEventArgs e)
        {


            RPUnfinished();
            
        }

        //
        //Unfinished "related projects" ie. projects that other employees have added current user to
        //
        private void RPUnfinished()
        {
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            projectmasterDataSetprojectTableAdapter.FillRPByEidUnfinished(projectmasterDataSet.project, UserId);

            btnMyProjects.Background = Brushes.Transparent;
            btnMPUnfinished.Background = Brushes.Transparent;
            btnMPAll.Background = Brushes.Transparent;
            btnMPFininshed.Background = Brushes.Transparent;
            btnRelateProjects.Background = color;
            btnRPAll.Background = Brushes.Transparent;
            btnRPFininshed.Background = Brushes.Transparent;
            btnRPUnfinished.Background = color;
        }

        //
        //Finished "related projects" ie. projects that other employees have added current user to
        //
        private void btnRPFininshed_Click(object sender, RoutedEventArgs e)
        {

            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            projectmasterDataSetprojectTableAdapter.FillRPByEidFinished(projectmasterDataSet.project, UserId);

            btnMyProjects.Background = Brushes.Transparent;
            btnMPUnfinished.Background = Brushes.Transparent;
            btnMPAll.Background = Brushes.Transparent;
            btnMPFininshed.Background = Brushes.Transparent;
            btnRelateProjects.Background = color;
            btnRPAll.Background = Brushes.Transparent;
            btnRPFininshed.Background = color;
            btnRPUnfinished.Background = Brushes.Transparent;
            
        }

        private void btnMyProjects_MouseEnter(object sender, MouseEventArgs e)
        {
            myprojectstooltip.IsOpen = true;
        }

        private void btnMyProjects_MouseLeave(object sender, MouseEventArgs e)
        {
            myprojectstooltip.IsOpen = false;
        }

        private void btnRelateProjects_MouseEnter(object sender, MouseEventArgs e)
        {
            otherprojectstooltip.IsOpen = true;
        }

        private void btnRelateProjects_MouseLeave(object sender, MouseEventArgs e)
        {
            otherprojectstooltip.IsOpen = false;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            //
            //Set property to "close", parent windows will also get closed 
            //
            App.Current.Properties["CloseWindow"] = "Close";
            UpdateWindow(sender , e);
        }

        private void projectDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //
            //move selected project to details window
            //
            App.Current.Properties["thisProject"] = projectDataGrid.SelectedItem;
            ProjectDetailsWindow win = new ProjectDetailsWindow();
            win.ShowDialog();
            App.Current.Properties["thisProject"] = null;
            UpdateWindow(sender, e);

        }

        private void addEmployee_click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow win = new AddEmployeeWindow();
            win.ShowDialog();
            UpdateWindow(sender, e);
        }


    }
}
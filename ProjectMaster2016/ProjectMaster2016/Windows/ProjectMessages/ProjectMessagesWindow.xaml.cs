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
    /// Interaction logic for ProjectMessagesWindow.xaml
    /// </summary>
    public partial class ProjectMessagesWindow : Window
    {
        private static int pid;
        private static int eid;

        public ProjectMessagesWindow()
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

                btnAddMessage.Visibility = Visibility.Collapsed;
                ctxMenu.Visibility = Visibility.Collapsed;
            }


            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table project_messages. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.project_messagesTableAdapter pma = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_messagesTableAdapter();
            
            if (App.Current.Properties["thisProjectMessage"] == null)
            { 
                //
                //Fill all messages for all projects. For access through admin menu: add, edit and remove enabled (admin role) -> add,edit and remove disabled (poweruser role)
                //
                try { 
                        pma.FillByPID(projectmasterDataSet.project_messages);
                        System.Windows.Data.CollectionViewSource project_messagesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("project_messagesViewSource")));
                        project_messagesViewSource.View.MoveCurrentToFirst();
                    }
                catch { }
            }
            else
            {
                //
                //Fill with messages related to a particular project
                //
                try 
                { 
                    DataRowView drv = (DataRowView)App.Current.Properties["thisProjectMessage"];
                    pid = (int)drv["pid"];
                    pma.FillProjectMsgByPId(projectmasterDataSet.project_messages, pid);
                }
                catch { }
            }

            //
            //disable edit and delete if user is not owner/creator of project
            //
            eid = (int)App.Current.Properties["UserId"];
            projectmasterDataSetTableAdapters.projectTableAdapter pta = new projectmasterDataSetTableAdapters.projectTableAdapter();
            try 
            { 
                int isOwner = (int)pta.GetProjectOwner(pid);
                if(isOwner != eid)
                {
                    ctxMenu.Visibility = Visibility.Collapsed;
                }

                if (role == "poweruser" && isOwner != eid)
                {
                    btnAddMessage.Visibility = Visibility.Collapsed;
                    ctxMenu.Visibility = Visibility.Collapsed;
                }
            }
            catch { }

            //ensure add, edit and remove are enabled for admin
            if (role == "admin")
            {
                btnAddMessage.Visibility = Visibility.Visible;
                ctxMenu.Visibility = Visibility.Visible;
            }

            //ensure add is enable for poweruser
            if (role == "poweruser" && App.Current.Properties["thisProject"] != null)
            {
                btnAddMessage.Visibility = Visibility.Visible;
            }
        }

        private void menu_EditProjectMessage_Click(object sender, RoutedEventArgs e)
        {
            //
            //Edit message. Userrights -> project owner/creator and admin
            //
            App.Current.Properties["projectMessage"] = project_messagesDataGrid.SelectedItem;
            EditProjectMessageWindow win = new EditProjectMessageWindow();
            win.ShowDialog();
            UpdateWindow();
        }

        private void menu_RemoveProjectMessage_Click(object sender, RoutedEventArgs e)
        {
            //
            //Remove message.  Userrights -> project owner/creator and admin
            //
            DataRowView drv = (DataRowView)project_messagesDataGrid.SelectedItem;
            string description = (string)drv["projectmessage"];
            int pmid = (int)project_messagesDataGrid.SelectedValue;
            MessageBoxResult dlg = MessageBox.Show("Ertu viss um að þú viljir eyða færslu nr. "+ pmid , "Eyða færslu?", MessageBoxButton.YesNo);

            if (dlg == MessageBoxResult.Yes)
            {
                try
                {
                    projectmasterDataSetTableAdapters.project_messagesTableAdapter pmta = new projectmasterDataSetTableAdapters.project_messagesTableAdapter();
                    pmta.DeleteMessage(pmid);
                    MessageBox.Show("Færslu nr. " + pmid + " hefur verið eytt." );
                    UpdateWindow();

                }
                catch (Exception)
                { 
                    MessageBox.Show("Ekki hægt að eyða færslu nr." + pmid , "Framkvæmd mistókst");
                }
            }
            

        }

        private void btnAddProjectMessage_Click(object sender, RoutedEventArgs e)
        {
            AddProjectMessageWindow win = new AddProjectMessageWindow();
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
            //
            //Select daterange by messagetimestamp
            //
            if (dpFromDate.SelectedDate <= dpToDate.SelectedDate)
            {
                DateTime from = (DateTime)dpFromDate.SelectedDate;
                DateTime to = (DateTime)dpToDate.SelectedDate.Value.AddDays(1);

                ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
                ProjectMaster2016.projectmasterDataSetTableAdapters.project_messagesTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_messagesTableAdapter();
                if(App.Current.Properties["thisProjectMessage"] == null)
                    try
                    {                
                        projectmasterDataSetprojectTableAdapter.FillByPIDDate(projectmasterDataSet.project_messages, from, to);
                    }
                    catch 
                    {
 
                    }
                else
                {
                    projectmasterDataSetprojectTableAdapter.FillBythisPIDDate(projectmasterDataSet.project_messages, from, to, pid);
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

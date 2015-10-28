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
    /// Interaction logic for EditProjectWindow.xaml
    /// </summary>
    public partial class EditProjectWindow : Window
    {
        //setting variables to be accessed between functions
        private bool isFinished;
        private bool isFinishedChanged;

        ToolTip tooltip = new ToolTip { Content = "Ýttu til að breyta stöðu" };
        

        public EditProjectWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
            
        }

        private void UpdateWindow()
        {
            //The project from another window
            DataRowView drv = (DataRowView)App.Current.Properties["project"];
            //project id
            int pid = (int)drv["pid"];
            //employee id (owner of project)
            int empId = Convert.ToInt32(drv["employee_eid"]);

            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table project. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter projectmasterDataSetprojectTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.projectTableAdapter();
            //projectmasterDataSetprojectTableAdapter.Fill(projectmasterDataSet.project);
            try
            { 
                //get project
                projectmasterDataSetprojectTableAdapter.FillByProjectId(projectmasterDataSet.project, pid);
                System.Windows.Data.CollectionViewSource projectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectViewSource")));
                projectViewSource.View.MoveCurrentToFirst();
            }
            catch { }

            //get name of employee(owner of project)
            projectmasterDataSetTableAdapters.employeeTableAdapter eta = new projectmasterDataSetTableAdapters.employeeTableAdapter();
            eta.Fill(projectmasterDataSet.employee);
            string s = (string)eta.GetEmployeeName(empId);
            cbEmployee.Text = s;

            // Load data into the table employee. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            
            isFinished = (bool)drv["projectisfinished"];
            //check if status has changed when updating
            isFinishedChanged = isFinished;

            //set colors and text for project status
            if (isFinished == true)
            {
                lblIsFinished.Content = "Já";
                lblIsFinished.Background = Brushes.LightGreen;

            }
            else if (isFinished == false)
            {
                lblIsFinished.Content = "Nei";
                lblIsFinished.Background = Brushes.PaleVioletRed;
            }

            // Load data into the table project_employees. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.project_employeesTableAdapter peta = new ProjectMaster2016.projectmasterDataSetTableAdapters.project_employeesTableAdapter();
            peta.FillByProjectEmployeeName(projectmasterDataSet.project_employees, pid);
            System.Windows.Data.CollectionViewSource project_employeesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("project_employeesViewSource")));
            project_employeesViewSource.View.MoveCurrentToFirst();

            
            
        }

 
       

        private void lblFininshed_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //change display  when clicked
            if ((string)lblIsFinished.Content == "Já")
            {
                lblIsFinished.Content = "Nei";
                isFinished = false;
                lblIsFinished.Background = Brushes.PaleVioletRed;
            }
            else
            {
                lblIsFinished.Content = "Já";
                isFinished = true;
                lblIsFinished.Background = Brushes.LightGreen;

            }
        }

        private void lblIsFinished_MouseEnter(object sender, MouseEventArgs e)
        {

            tooltip.IsOpen = true;

        }

        private void lblIsFinished_MouseLeave(object sender, MouseEventArgs e)
        {
            tooltip.IsOpen = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Viltu vista breytingar?", "Breyta verkefni", MessageBoxButton.YesNo);
            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    DataRowView drv = (DataRowView)App.Current.Properties["project"];
                    string description = txtPDescription.Text;
                    DateTime pdate = (DateTime)drv["pdate"];
                    int eid = (int)drv["employee_eid"];
                    string pname = txtprojectName.Text;
                    int pid = (int)drv["pid"];

                    //update project
                    projectmasterDataSetTableAdapters.projectTableAdapter pta = new projectmasterDataSetTableAdapters.projectTableAdapter();
                    pta.UpdateProjectById(description, pdate, eid, isFinished, pname, pid);

                    //log int projectmessagestable: the change in project state(finsished/unfinished)
                    if(isFinished != isFinishedChanged && isFinished == true)
                    {
                        projectmasterDataSetTableAdapters.project_messagesTableAdapter pma = new projectmasterDataSetTableAdapters.project_messagesTableAdapter();
                        pma.Insert(pid, eid, "*** Staða verkefnis fært í lokið ***", DateTime.Now, null, null);
                    }
                    if (isFinished != isFinishedChanged && isFinished == false)
                    {
                        projectmasterDataSetTableAdapters.project_messagesTableAdapter pma = new projectmasterDataSetTableAdapters.project_messagesTableAdapter();
                        pma.Insert(pid, eid, "*** Verkefni enduropnað ***", DateTime.Now, null, null);
                    }
                    //update current properties also
                    drv["projectisfinished"] = isFinished;

                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ekki hægt að vista breytingar");
            }



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

        private void btnAddProjectEmployee_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)App.Current.Properties["project"];
            int pid = (int)drv["pid"];
            AddProjectEmployeeWindow win = new AddProjectEmployeeWindow();
            win.ShowDialog();
            UpdateWindow();
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public EditEmployeeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            UpdateWindow();
            
        }

        private void UpdateWindow()
        {
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            // Load data into the table employee. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter projectmasterDataSetemployeeTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.employeeTableAdapter();
            projectmasterDataSetemployeeTableAdapter.Fill(projectmasterDataSet.employee);
            System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            employeeViewSource.View.MoveCurrentToFirst();
            // Load data into the table zipcodes. You can modify this code as needed.
            ProjectMaster2016.projectmasterDataSetTableAdapters.zipcodesTableAdapter projectmasterDataSetzipcodesTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.zipcodesTableAdapter();
            projectmasterDataSetzipcodesTableAdapter.Fill(projectmasterDataSet.zipcodes);
            System.Windows.Data.CollectionViewSource zipcodesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("zipcodesViewSource")));
            zipcodesViewSource.View.MoveCurrentToFirst();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ertu viss?", "Viltu hætta?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void lbEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lblZip.Content != null)
            {
                int zip = (int)lblZip.Content;
                zipComboBox.Text = zip.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int eid = (int)lbEmployees.SelectedValue;
                projectmasterDataSetTableAdapters.employeeTableAdapter eta = new projectmasterDataSetTableAdapters.employeeTableAdapter();
                eta.UpdateEmployee(nameTextBox.Text, emailTextBox.Text, homeaddressTextBox.Text, (int)zipComboBox.SelectedValue, phoneTextBox.Text, professionTextBox.Text, eid);
                UpdateWindow();
                lbEmployees.SelectedValue = eid;
                MessageBox.Show("Breytingar hafa verið vistaðar");
            }
            catch
            {
                MessageBox.Show("Úbbs. Eitthvað fór úrskeiðis.");
            }
        }

        private void btnChangeImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                int eid = (int)lbEmployees.SelectedValue;
                byte[] img = File.ReadAllBytes(dlg.FileName);
                projectmasterDataSetTableAdapters.employeeTableAdapter ita = new projectmasterDataSetTableAdapters.employeeTableAdapter();
                ita.UpdateImg(img, (int)lbEmployees.SelectedValue);
                UpdateWindow();
                lbEmployees.SelectedValue = eid;
            }
        }
    }
}

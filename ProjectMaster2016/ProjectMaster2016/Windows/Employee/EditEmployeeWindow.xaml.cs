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
            // Load data into the table userroles. You can modify this code as needed.	
            ProjectMaster2016.projectmasterDataSetTableAdapters.userrolesTableAdapter projectmasterDataSetuserrolesTableAdapter = new ProjectMaster2016.projectmasterDataSetTableAdapters.userrolesTableAdapter();
            projectmasterDataSetuserrolesTableAdapter.Fill(projectmasterDataSet.userroles);
            System.Windows.Data.CollectionViewSource userrolesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userrolesViewSource")));
            userrolesViewSource.View.MoveCurrentToFirst();

            // Setting the value of the hidden userrole id label for the first display	
            int urid = (int)lblurid.Content;
            userroleComboBox.SelectedValue = urid;
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
            // Changing the value of the zip combobox based on the value of the hidden zip label that has binding to the employee table zip value	
            if (lblZip.Content != null)
            {
                int zip = (int)lblZip.Content;
                zipComboBox.Text = zip.ToString();
            }
            // Changing the value of the userrole combobox based on the value of the hidden userrole id label that has binding to the employee table userrole id value	
            if (lblurid.Content != null)
            {
                int urid = (int)lblurid.Content;
                userroleComboBox.SelectedValue = urid;
            }

            //Collapsing the temporary image containter that I use for changing the user images and Displaying the normal image container that gets the image from the DB	
            imgImageTemp.Visibility = Visibility.Collapsed;
            imgImage.Visibility = Visibility.Visible;
            //Resetting the image that is saved in app current properties, in case a picture has been uploaded but not been saved	
            App.Current.Properties["image"] = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Updating the employee table values (except the image column)	
                int eid = (int)lbEmployees.SelectedValue;
                projectmasterDataSetTableAdapters.employeeTableAdapter eta = new projectmasterDataSetTableAdapters.employeeTableAdapter();
                eta.UpdateEmployee(nameTextBox.Text, emailTextBox.Text, homeaddressTextBox.Text, (int)zipComboBox.SelectedValue, phoneTextBox.Text, professionTextBox.Text, usernameTextBox.Text, passwordTextBox.Text, (int)userroleComboBox.SelectedValue, eid);
                projectmasterDataSetTableAdapters.employeeTableAdapter ita = new projectmasterDataSetTableAdapters.employeeTableAdapter();

                //Updating the image column in the employee table, in case there is an image saved in app current properties	
                if (App.Current.Properties["image"] != null)
                {
                    ita.UpdateImg((byte[])App.Current.Properties["image"], (int)lbEmployees.SelectedValue);
                }
                //Collapsing temporary image container and showing normal image container	
                imgImageTemp.Visibility = Visibility.Collapsed;
                imgImage.Visibility = Visibility.Visible;
                UpdateWindow();

                //Setting selected value so the employee listbox stays at the edited employee after saving.	
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

            //If image chosen, read image, then store it in a MemoryStream and put it in a temporary image container, and hide the main img container.	
            if (dlg.ShowDialog() == true)
            {
                byte[] imgarray = File.ReadAllBytes(dlg.FileName);
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = new System.IO.MemoryStream(imgarray);
                img.EndInit();
                imgImageTemp.Source = img;
                imgImageTemp.Visibility = Visibility.Visible;
                imgImage.Visibility = Visibility.Collapsed;

                //Save temporary image in app current prop, so it could be saved	
                App.Current.Properties["image"] = imgarray;
            }
        }
    }
}
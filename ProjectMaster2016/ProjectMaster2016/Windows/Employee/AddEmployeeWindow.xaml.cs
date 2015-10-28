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
    /// Interaction logic for AddEmployeeWindow.xaml	
    /// </summary>	
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
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

            try
            {
                //Display default image	
                byte[] imgarray = File.ReadAllBytes("../../images/user.png");
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = new System.IO.MemoryStream(imgarray);
                img.EndInit();
                imgImage.Source = img;

                //Save imagearray, because later it is inserted into the DB as App.Current.Properties	
                App.Current.Properties["image"] = imgarray;
            }
            catch (Exception)
            {
                
               
            }
 
        }



        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ertu viss?", "Viltu hætta?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //Insert collected data into the database	
                projectmasterDataSetTableAdapters.employeeTableAdapter eta = new projectmasterDataSetTableAdapters.employeeTableAdapter();
                eta.Insert(nameTextBox.Text, emailTextBox.Text, homeaddressTextBox.Text, (int)zipComboBox.SelectedValue, phoneTextBox.Text, (byte[])App.Current.Properties["image"], professionTextBox.Text, null, null, passwordTextBox.Text, usernameTextBox.Text, (int)userroleComboBox.SelectedValue, DateTime.Now);
                MessageBox.Show("Breytingar hafa verið vistaðar");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Úbbs. Eitthvað fór úrskeiðis.");
            }

        }

        private void btnChangeImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //If a file has been chosen, set the selected file as the userimage	
            if (dlg.ShowDialog() == true)
            {
                byte[] imgarray = File.ReadAllBytes(dlg.FileName);
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = new System.IO.MemoryStream(imgarray);
                img.EndInit();
                imgImage.Source = img;

                //Save imagearray, because later it is inserted into the DB as App.Current.Properties	
                App.Current.Properties["image"] = imgarray;
            }
        }
    }
}
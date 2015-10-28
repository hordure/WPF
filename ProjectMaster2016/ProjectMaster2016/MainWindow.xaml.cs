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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectMaster2016
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string role;
        private static string username;
        private static string password;
        private static int eid;

        public MainWindow()
        {
            InitializeComponent();
            ToolTipService.ShowDurationProperty.OverrideMetadata(typeof(DependencyObject), new FrameworkPropertyMetadata(Int32.MaxValue));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow(); 
        }

        private void UpdateWindow()
        {
            txtUsername.Text = "1";
            PasswordBox.Password = "1";

           if((string)App.Current.Properties["CloseWindow"] == "Close")
           {
               LogOut();
               App.Current.Properties["CloseWindow"] = null;
               //lblUserName.Content = "";
           }

            if(username != null)
            { 
                ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
                //Load data into the table userroles. You can modify this code as needed.
                ProjectMaster2016.projectmasterDataSetTableAdapters.userrolesTableAdapter uta = new ProjectMaster2016.projectmasterDataSetTableAdapters.userrolesTableAdapter();
                uta.FillByUserAndPassword(projectmasterDataSet.userroles, username, password);
                System.Windows.Data.CollectionViewSource userrolesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userrolesViewSource")));
                userrolesViewSource.View.MoveCurrentToFirst();
                App.Current.Properties["User"] = lblUserName.Content;
            }

            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            MainWin.WindowState = WindowState.Minimized;
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn();  
        }

        private void SignIn()
        {
            username = txtUsername.Text;
            password = PasswordBox.Password;
            ProjectMaster2016.projectmasterDataSet projectmasterDataSet = ((ProjectMaster2016.projectmasterDataSet)(this.FindResource("projectmasterDataSet")));
            projectmasterDataSetTableAdapters.userrolesTableAdapter uta = new projectmasterDataSetTableAdapters.userrolesTableAdapter();
            role = (string)uta.GetRoleByUsername(username, password);
            

            if (role != null)
            {
                
                txtUsername.Text = "";
                PasswordBox.Password = "";
                App.Current.Properties["Role"] = role;
                eid = (int)uta.GetEidByUserAndPassw(username, password);
                App.Current.Properties["UserId"] = eid;
                App.Current.Properties["User"] = lblUserName.Content;
                
                UpdateWindow();

                UserWindow win = new UserWindow();
                win.ShowDialog();
                UpdateWindow();
            }
            else
            {
                MessageBox.Show("Notandanafn og/eða lykilorð vitlaust slegið inn");
                txtUsername.Text = "";
                PasswordBox.Password = "";
            }

        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txtUsername.Text != "")
            {
                SignIn();
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LogOut();
        }

        public void LogOut()
        {
            password = "";
            username = "";
            txtUsername.Text = "";
            PasswordBox.Password = "";
            App.Current.Properties["Role"] = null;
            App.Current.Properties["User"] = null;
            App.Current.Properties["UserId"] = null;
            
            ProjectMaster2016.projectmasterDataSetTableAdapters.userrolesTableAdapter uta = new ProjectMaster2016.projectmasterDataSetTableAdapters.userrolesTableAdapter();
            uta.Dispose();
            //UpdateWindow();
        }



    }
}

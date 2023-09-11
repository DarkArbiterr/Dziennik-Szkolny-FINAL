using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.ServiceProcess;
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
using System.ComponentModel;
using MySql.Data.MySqlClient;
using BackendLibrary.Models;
using System.Data;
using System.Collections.ObjectModel;
using Dapper;
using System.Windows.Threading;

namespace DziennikSzkolny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ServiceController us;
        public string[] stringArray;
        public MainWindow()
        {
            us = new ServiceController(Properties.Settings.Default.nameService);
            InitializeComponent();
        }
        
        public static StudentModel loggedStudent = new BackendLibrary.Models.StudentModel();
        public static ParentModel loggedParent = new BackendLibrary.Models.ParentModel();
        public static TeacherModel loggedTeacher = new BackendLibrary.Models.TeacherModel();

        public void login()
        {
            string login, password;
            loggedParent.IdParent = -1;
            loggedTeacher.IdTeacher = -1;
            loggedStudent.IdStudent = -1;
            if (BackendLibrary.DataAccess.StudentData.GetStudent(Dispatcher.Invoke(
                () => login = txt_username.Text), Dispatcher.Invoke(() => password = txt_password.Password)).IdStudent != -1)
            {
                loggedStudent = BackendLibrary.DataAccess.StudentData.GetStudent(Dispatcher.Invoke(
                    () => login = txt_username.Text), Dispatcher.Invoke(() => password = txt_password.Password));
                stringArray = new string[2];
                stringArray[0] = loggedStudent.Username;
                stringArray[1] = "przedmiot";
                us.Start(stringArray);
                Task.Delay(500).ContinueWith(t => us.ExecuteCommand(200));
            }
            else
            {
                if (BackendLibrary.DataAccess.ParentData.GetParent(Dispatcher.Invoke(
                    () => login = txt_username.Text), Dispatcher.Invoke(() => password = txt_password.Password)).IdParent != -1)
                {
                    loggedParent = BackendLibrary.DataAccess.ParentData.GetParent(Dispatcher.Invoke(
                        () => login = txt_username.Text), Dispatcher.Invoke(() => password = txt_password.Password));
                    loggedStudent = BackendLibrary.DataAccess.StudentData.GetStudentByParentId(loggedParent.IdParent);
                    stringArray = new string[2];
                    stringArray[0] = loggedParent.Username;
                    stringArray[1] = "przedmiot";
                    us.Start(stringArray);
                    Task.Delay(500).ContinueWith(t => us.ExecuteCommand(200));

                }
                else
                {
                    if (BackendLibrary.DataAccess.TeacherData.GetTeacher(Dispatcher.Invoke(
                        () => login = txt_username.Text), Dispatcher.Invoke(() => password = txt_password.Password)).IdTeacher != -1)
                    {
                        loggedTeacher = BackendLibrary.DataAccess.TeacherData.GetTeacher(Dispatcher.Invoke(
                            () => login = txt_username.Text), Dispatcher.Invoke(() => password = txt_password.Password));
                        stringArray = new string[2];
                        stringArray[0] = loggedTeacher.Username;
                        stringArray[1] = BackendLibrary.DataAccess.SubjectData.GetSubjectById(loggedTeacher.Subject_idSubject).Name;
                        us.Start(stringArray);
                        Task.Delay(500).ContinueWith(t => us.ExecuteCommand(200));

                    }
                    else
                    {
                        MessageBox.Show("Zła nazwa użytkownika lub hasło!");
                    }
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                System.Windows.Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_WorkComplete;

            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            login();
        }

        private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                if (loggedParent.IdParent != -1 || loggedTeacher.IdTeacher != -1 || loggedStudent.IdStudent != -1)
                {
                    appWindow obj_appWindow = new appWindow();
                    Dispatcher.Invoke(new Action(() => { this.Visibility = Visibility.Hidden; }));
                    Dispatcher.Invoke(new Action(() => { obj_appWindow.Show(); }));
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

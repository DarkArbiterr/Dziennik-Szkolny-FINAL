using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using BackendLibrary.Models;
using System.Data;
using System.Collections.ObjectModel;
using Dapper;

namespace DziennikSzkolny
{
    /// <summary>
    /// Interaction logic for Presence.xaml
    /// </summary>
    public partial class Presence : Page
    {
        ObservableCollection<PresenceModel> PresenceList = new ObservableCollection<PresenceModel>();   
        public Presence()
        {
            InitializeComponent();

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
            SelectPresence();
        }

        private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                System.Windows.MessageBox.Show(e.Error.Message);
            }
            else
            {
                ShowPresence();
            }
        }

        private void SelectPresence()
        {
            PresenceList = BackendLibrary.DataAccess.PresenceData.GetAllStudentPresence(MainWindow.loggedStudent.IdStudent);
        }

        private void ShowPresence()
        {
            foreach (var presence in PresenceList)
            {
                TimeSpan hr = TimeSpan.FromHours(presence.Hour);
                TextBlock newPresence = new TextBlock();
                TextBlock newPresence1 = new TextBlock();
                TextBlock newPresence2 = new TextBlock();
                TextBlock newPresence3 = new TextBlock();
                Border newBorder = new Border();
                StackPanel newStack = new StackPanel();
                newStack.Orientation = Orientation.Horizontal;
                newBorder.BorderThickness = new Thickness(1);
                newBorder.BorderBrush = Brushes.Black;

                newPresence.Width = 200;
                newPresence.FontSize = 18;
                newPresence.HorizontalAlignment = HorizontalAlignment.Center;
                newPresence.VerticalAlignment = VerticalAlignment.Center;
                newPresence.Text = "            NIEOBECNY";
                newStack.Children.Add(newPresence);

                newPresence1.Width = 200;
                newPresence1.FontSize = 18;
                newPresence1.HorizontalAlignment = HorizontalAlignment.Center;
                newPresence1.VerticalAlignment = VerticalAlignment.Center;
                newPresence1.Text = presence.Date.Substring(0,10) + "        " + hr.ToString("hh':'mm");
                newStack.Children.Add(newPresence1);

                newPresence2.Width = 200;
                newPresence2.FontSize = 18;
                newPresence2.HorizontalAlignment = HorizontalAlignment.Center;
                newPresence2.VerticalAlignment = VerticalAlignment.Center;
                newPresence2.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(presence.Subject_idSubject).Name;
                newStack.Children.Add(newPresence2);

                newPresence3.Width = 200;
                newPresence3.FontSize = 18;
                newPresence3.HorizontalAlignment = HorizontalAlignment.Center;
                newPresence3.VerticalAlignment = VerticalAlignment.Center;
                newPresence3.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(presence.Subject_idSubject).Name +
                    " " + BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(presence.Subject_idSubject).Surname;
                newStack.Children.Add(newPresence3);

                newBorder.Child = newStack;
                pres.Children.Add(newBorder);
            }
        }
    }
}

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
    /// Interaction logic for AddPresence.xaml
    /// </summary>
    public partial class AddPresence : Page
    {
        private string[] addClass = { "1A", "2A", "3A" };
        private int[] addHour = { 8, 9, 10, 11, 12, 13, 14, 15 };
        private string date, clas;
        private int hour;

        public ObservableCollection<StudentModel> StudentList = new ObservableCollection<StudentModel>();
        public ObservableCollection<string> DaysList { get; set; }

        private void addDays()
        {
            DaysList = new ObservableCollection<string>();
            DateTime now;

            now = DateTime.Now;

            DateTime dateTime = new DateTime(now.Year, 1, 1);

            while (dateTime.Year < now.Year + 1)
            {
                if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday ||
                    dateTime.Month == 7 || dateTime.Month == 8)
                {
                    dateTime = dateTime.AddDays(1);
                }
                else
                {
                    DaysList.Add(dateTime.ToString("yyyy-MM-dd"));
                    dateTime = dateTime.AddDays(1);
                }

            }
            daty.ItemsSource = DaysList;
        }

        private void BindData()
        {
            uczniowie.ItemsSource = null;
            uczniowie.ItemsSource = StudentList;
        }

        private void loadStudents()
        {
            StudentList = new ObservableCollection<StudentModel>();
            StudentList = BackendLibrary.DataAccess.StudentData.GetAllClassStudents(clas);
            Dispatcher.Invoke(new Action(() => BindData()));
            Dispatcher.Invoke(new Action(() => this.DataContext = this));
        }

        private void klasy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clas = klasy.SelectedItem.ToString();
            loadStudents();
        }

        private void daty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            date = daty.SelectedItem.ToString();
        }

        private void godziny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hour = Int32.Parse(godziny.SelectedItem.ToString());
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            insertPresence();
        }

        private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                System.Windows.MessageBox.Show(e.Error.Message);
            }
        }

        private void insertPresence()
        {
            int j = 0;
            var dataStudents = from s in StudentList
                               where s.Check == true
                               select s.IdStudent;

            foreach (var s in dataStudents)
            {
                if (BackendLibrary.DataAccess.PresenceData.CheckPresence(s, date, hour))
                {
                    MessageBox.Show("Student o indeksie: " + s + " ma już wpisaną nieobecność z tego dnia!");
                }
                else
                {
                    j = 1;
                    BackendLibrary.DataAccess.PresenceData.InsertPresence(new PresenceModel("NIE", date, hour,
                        MainWindow.loggedTeacher.IdTeacher,
                        s, MainWindow.loggedTeacher.Subject_idSubject));
                }
            }
            if (j == 1)
            {
                MessageBox.Show("Dodano nieobecności z dnia: " + date + " do systemu!");
                MainWindow.us.ExecuteCommand(207);
            }

            Dispatcher.Invoke(new Action(() => klasy.SelectedIndex = 0));
            Dispatcher.Invoke(() => clas = klasy.SelectedItem.ToString());

            Dispatcher.Invoke(new Action(() => godziny.SelectedIndex = 0));
            Dispatcher.Invoke(() => hour = Int32.Parse(godziny.SelectedItem.ToString()));

            Dispatcher.Invoke(new Action(() => daty.SelectedIndex = 0));
            Dispatcher.Invoke(() => date = daty.SelectedItem.ToString());

            loadStudents();
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.MainFrame.Navigate(new Justify());
        }

        public AddPresence()
        {
            InitializeComponent();

            addDays();


            klasy.ItemsSource = addClass;
            klasy.SelectedIndex = 0;
            clas = klasy.SelectedItem.ToString();

            godziny.ItemsSource = addHour;
            godziny.SelectedIndex = 0;
            hour = Int32.Parse(godziny.SelectedItem.ToString());


            daty.SelectedIndex = 0;
            date = daty.SelectedItem.ToString();

            loadStudents();
        }
    }
}

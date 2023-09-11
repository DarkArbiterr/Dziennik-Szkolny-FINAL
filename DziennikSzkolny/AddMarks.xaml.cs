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
    /// Interaction logic for AddMarks.xaml
    /// </summary>
    public partial class AddMarks : Page
    {
        private string clas, clas2;
        private string newMarkStudentId;
        public string newMarkValue;
        public string setMarkValue;
        public string setMarkStudentId;
        public ObservableCollection<string> students = new ObservableCollection<string>();
        public ObservableCollection<string> students2 = new ObservableCollection<string>();

        private string[] addMarks = { "1", "1+", "2", "2+", "3", "3+", "4", "4+", "5", "5+", "6" };
        private string[] addClass = { "1A", "2A", "3A" };

        public ObservableCollection<StudentModel> addStudents = new ObservableCollection<StudentModel>();
        public ObservableCollection<StudentModel> addStudents2 = new ObservableCollection<StudentModel>();
        public ObservableCollection<MarkModel> MarkList = new ObservableCollection<MarkModel>();

        private void loadMarks()
        {
            MarkList = BackendLibrary.DataAccess.MarkData.GetAllForTeacher(MainWindow.loggedTeacher.IdTeacher, int.Parse(newMarkStudentId));
            Dispatcher.Invoke(new Action(() => BindData3()));
            Dispatcher.Invoke(new Action(() => this.DataContext = this));
        }

        private void dataStudents(int x)
        {
            if (x == 1)
            {
                addStudents = new ObservableCollection<StudentModel>();
                addStudents = BackendLibrary.DataAccess.StudentData.GetAllClassStudents(clas);
                BindData();
                this.DataContext = this;
            }
            else
            {
                addStudents2 = new ObservableCollection<StudentModel>();
                addStudents2 = BackendLibrary.DataAccess.StudentData.GetAllClassStudents(clas2);
                BindData2();
                this.DataContext = this;
            }
        }

        private void BindData()
        {
            students = new ObservableCollection<string>();
            foreach (var student in addStudents)
            {
                students.Add(student.Text);
            }
            try
            {
                uczniowie.ItemsSource = students;
            }
            catch
            {
            }

            uczniowie.SelectedIndex = 0;

        }

        private void BindData2()
        {
            students2 = new ObservableCollection<string>();
            foreach (var student in addStudents2)
            {
                students2.Add(student.Text);
            }
            try
            {
                uczniowie2.ItemsSource = students2;
            }
            catch
            {
            }

            uczniowie2.SelectedIndex = 0;
        }

        private void BindData3()
        {
            oceny_u.ItemsSource = null;
            oceny_u.ItemsSource = MarkList;
        }

        public AddMarks()
        {
            InitializeComponent();

            oceny.ItemsSource = addMarks;
            oceny.SelectedIndex = 0;
            setMarkValue = "1";

            oceny2.ItemsSource = addMarks;
            oceny2.SelectedIndex = 0;
            newMarkValue = oceny2.SelectedItem.ToString();

            klasy.ItemsSource = addClass;
            klasy.SelectedIndex = 0;
            clas = klasy.SelectedItem.ToString();

            klasy2.ItemsSource = addClass;
            klasy2.SelectedIndex = 0;
            clas2 = klasy.SelectedItem.ToString();

            dataStudents(1);
            dataStudents(2);

            var firstSpace = uczniowie.SelectedItem.ToString().IndexOf(" ");
            var firstString = uczniowie.SelectedItem.ToString().Substring(0, firstSpace);

            setMarkStudentId = firstString;

            var firstSpace2 = uczniowie2.SelectedItem.ToString().IndexOf(" ");
            var firstString2 = uczniowie2.SelectedItem.ToString().Substring(0, firstSpace);

            newMarkStudentId = firstString;

            loadMarks();
        }

        private void klasy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clas = klasy.SelectedItem.ToString();
            
            dataStudents(1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWorkInsert;
            bgWorker.RunWorkerCompleted += bgWorker_WorkComplete;

            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        private void uczniowie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var firstSpace = uczniowie.SelectedItem.ToString().IndexOf(" ");
            var firstString = uczniowie.SelectedItem.ToString().Substring(0, firstSpace);

            setMarkStudentId = firstString;
        }

        private void klasy2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clas2 = klasy2.SelectedItem.ToString();
            
            dataStudents(2);

            loadMarks();
        }

        private void uczniowie2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var firstSpace = uczniowie2.SelectedItem.ToString().IndexOf(" ");
            var firstString = uczniowie2.SelectedItem.ToString().Substring(0, firstSpace);

            newMarkStudentId = firstString;

            loadMarks();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void oceny2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            newMarkValue = oceny2.SelectedItem.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWorkDelete;
            bgWorker.RunWorkerCompleted += bgWorker_WorkComplete;

            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWorkUpdate;
            bgWorker.RunWorkerCompleted += bgWorker_WorkComplete;

            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        private void oceny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setMarkValue = oceny.SelectedItem.ToString();
        }

        private void insert()
        {
            string o;
            BackendLibrary.DataAccess.MarkData.InsertMark(new MarkModel(setMarkValue, DateTime.Today.ToString("yyyy-MM-dd"),
                Dispatcher.Invoke(() => o = opis.Text), MainWindow.loggedTeacher.IdTeacher, int.Parse(setMarkStudentId),
                MainWindow.loggedTeacher.Subject_idSubject));
            MessageBox.Show("Pomyślnie dodano ocenę do systemu!");
            MainWindow.us.ExecuteCommand(204);
        }

        private void delete()
        {
            var deleteMark = from d in MarkList
                             where d.Check == true
                             select d.IdMark;

            foreach (var mark in deleteMark)
            {
                BackendLibrary.DataAccess.MarkData.DeleteMark(mark);
            }
            MessageBox.Show("Pomyślnie usunięto ocenę z systemu!");
            MainWindow.us.ExecuteCommand(206);

            loadMarks();
        }

        private void update()
        {
            int i = 0;
            var updateMark = from d in MarkList
                             where d.Check == true
                             select d;

            foreach (var mark in updateMark)
            {
                i = 1;
                BackendLibrary.DataAccess.MarkData.UpdateMark(new MarkModel(mark.IdMark, newMarkValue, DateTime.Today.ToString("yyyy-MM-dd"),
                    mark.Description, mark.Teacher_idTeacher, mark.Student_idStudent, mark.Subject_idSubject));
            }
            if (i == 1)
                MessageBox.Show("Pomyślnie zaktualizowano ocenę w systemie!");
            else
                MessageBox.Show("Zaznacz ocenę do zmiany!");
            MainWindow.us.ExecuteCommand(205);

            loadMarks();
        }

        private void bgWorker_DoWorkInsert(object sender, DoWorkEventArgs e)
        {
            insert();
        }

        private void bgWorker_DoWorkUpdate(object sender, DoWorkEventArgs e)
        {
            update();
        }

        private void bgWorker_DoWorkDelete(object sender, DoWorkEventArgs e)
        {
            delete();
        }

        private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                System.Windows.MessageBox.Show(e.Error.Message);
            }
        }
    }
}

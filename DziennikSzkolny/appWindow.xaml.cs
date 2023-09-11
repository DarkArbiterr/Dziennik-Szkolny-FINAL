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
using System.Windows.Shapes;

namespace DziennikSzkolny
{
    /// <summary>
    /// Interaction logic for appWindow.xaml
    /// </summary>
    public partial class appWindow : Window
    {
        public appWindow()
        {
            InitializeComponent();
            
            if (MainWindow.loggedStudent.IdStudent != -1)
            {
                name.Text = MainWindow.loggedStudent.Name + " " + MainWindow.loggedStudent.Surname;
                perm.Text = "Uczeń";
            }
            if (MainWindow.loggedTeacher.IdTeacher != -1)
            {
                name.Text = MainWindow.loggedTeacher.Name + " " + MainWindow.loggedTeacher.Surname;
                perm.Text = "Nauczyciel";
            }
            if (MainWindow.loggedParent.IdParent != -1)
            {
                name.Text = MainWindow.loggedParent.Name + " " + MainWindow.loggedParent.Surname;
                perm.Text = "Rodzic";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj_appWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            obj_appWindow.Show();
            MainWindow.loggedParent.IdParent = -1;
            MainWindow.loggedTeacher.IdTeacher = -1;
            MainWindow.loggedStudent.IdStudent = -1;
            MainWindow.us.ExecuteCommand(209);
            MainWindow.us.Stop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Schedule();
            MainWindow.us.ExecuteCommand(201);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MainWindow.loggedParent.IdParent != -1 || MainWindow.loggedStudent.IdStudent != -1)
            {
                MainFrame.Content = new Marks();
                MainWindow.us.ExecuteCommand(202);
            }
            else
            {
                MainFrame.Content = new AddMarks();
                MainWindow.us.ExecuteCommand(202);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MainWindow.loggedParent.IdParent != -1 || MainWindow.loggedStudent.IdStudent != -1)
            {
                MainFrame.Content = new Presence();
                MainWindow.us.ExecuteCommand(203);
            }
            else
            {
                App.ParentWindowRef = this;
                this.MainFrame.Navigate(new AddPresence());
                MainWindow.us.ExecuteCommand(203);

            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

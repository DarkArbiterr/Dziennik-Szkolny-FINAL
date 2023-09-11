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
    /// Interaction logic for Marks.xaml
    /// </summary>
    public partial class Marks : Page
    {
        public Marks()
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

        Random color = new Random();
        ObservableCollection<MarkModel> MarksList = new ObservableCollection<MarkModel>();
        TeacherModel SubjectTeacher = new TeacherModel();

        private void SelectMarks()
        {
            MarksList = BackendLibrary.DataAccess.MarkData.GetAllForStudent(MainWindow.loggedStudent.IdStudent);
        }

        private void ShowMarks()
        {
            foreach(var marks in MarksList)
            {
                SubjectTeacher = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(marks.Subject_idSubject);

                if (marks.Subject_idSubject == "MT1" || marks.Subject_idSubject == "MT2")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    mt.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0,10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    mt.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "JP1" || marks.Subject_idSubject == "JP2")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    jp.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    jp.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "JA1" || marks.Subject_idSubject == "JA2")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    ja.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    ja.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "JN1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    jn.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    jn.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "BL1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    bl.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    bl.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "CH1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    ch.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    ch.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "FZ1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    fz.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    fz.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "PS1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    pl.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    pl.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "RL1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    rl.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    rl.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "MZ1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    mz.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    mz.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "WF1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    wf.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    wf.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "HS1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    hs.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    hs.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "WS1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    ws.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    ws.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "IN1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    im.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    im.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "TC1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    tc.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    tc.Children.Add(newMark);
                }

                if (marks.Subject_idSubject == "GF1")
                {
                    TextBlock newMark1 = new TextBlock();
                    newMark1.Text = " ";
                    gf.Children.Add(newMark1);
                    TextBlock newMark = new TextBlock();
                    newMark.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(color.Next(100, 210)), Convert.ToByte(color.Next(120, 230)), Convert.ToByte(color.Next(140, 255))));
                    newMark.FontSize = 18;
                    newMark.FontWeight = FontWeights.Bold;
                    newMark.HorizontalAlignment = HorizontalAlignment.Center;
                    newMark.VerticalAlignment = VerticalAlignment.Center;
                    newMark.ToolTip = marks.Date.Substring(0, 10) + " " + SubjectTeacher.Name + " " + SubjectTeacher.Surname + " " + marks.Description;
                    newMark.Text = " " + marks.Value + " ";
                    gf.Children.Add(newMark);
                }
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SelectMarks();
        }

        private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                ShowMarks();
            }
        }

    }
}

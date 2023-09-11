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
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Page
    {
        ObservableCollection<ScheduleModel> mySchedule = new ObservableCollection<ScheduleModel>();
        private string[] addClass = { "1A", "2A", "3A" };
        private string clas;

        private void Select_Schedule()
        {
            mySchedule = new ObservableCollection<ScheduleModel>();
            mySchedule = BackendLibrary.DataAccess.ScheduleData.GetAllSchedule(clas);
        }

        private void Show_Schedule()
        {
            foreach (var my in mySchedule)
            {
                if (my.Day == "Poniedziałek")
                {
                    if (my.Hour == 8)
                    {
                        p8_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        p8_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        p8_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        p8.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    
                    if (my.Hour == 9)
                    {
                        p9_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        p9_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        p9_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        p9.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 10)
                    {
                        p10_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        p10_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        p10_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        p10.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 11)
                    {
                        p11_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        p11_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        p11_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        p11.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 12)
                    {
                        p12_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        p12_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        p12_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        p12.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 13)
                    {
                        p13_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        p13_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        p13_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        p13.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 14)
                    {
                        p14_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        p14_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        p14_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        p14.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 15)
                    {
                        p15_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        p15_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        p15_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        p15.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                }
                if (my.Day == "Wtorek")
                {
                    if (my.Hour == 8)
                    {
                        w8_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        w8_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        w8_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        w8.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 9)
                    {
                        w9_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        w9_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        w9_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        w9.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 10)
                    {
                        w10_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        w10_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        w10_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        w10.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 11)
                    {
                        w11_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        w11_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        w11_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        w11.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 12)
                    {
                        w12_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        w12_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        w12_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        w12.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 13)
                    {
                        w13_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        w13_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        w13_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        w13.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 14)
                    {
                        w14_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        w14_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        w14_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        w14.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 15)
                    {
                        w15_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        w15_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        w15_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        w15.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                }
                if (my.Day == "Środa")
                {
                    if (my.Hour == 8)
                    {
                        s8_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        s8_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        s8_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        s8.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 9)
                    {
                        s9_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        s9_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        s9_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        s9.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 10)
                    {
                        s10_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        s10_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        s10_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        s10.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 11)
                    {
                        s11_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        s11_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        s11_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        s11.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 12)
                    {
                        s12_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        s12_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        s12_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        s12.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 13)
                    {
                        s13_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        s13_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        s13_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        s13.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 14)
                    {
                        s14_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        s14_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        s14_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        s14.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 15)
                    {
                        s15_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        s15_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        s15_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        s15.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                }
                if (my.Day == "Czwartek")
                {
                    if (my.Hour == 8)
                    {
                        c8_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        c8_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        c8_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        c8.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 9)
                    {
                        c9_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        c9_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        c9_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        c9.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 10)
                    {
                        c10_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        c10_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        c10_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        c10.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 11)
                    {
                        c11_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        c11_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        c11_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        c11.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 12)
                    {
                        c12_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        c12_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        c12_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        c12.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 13)
                    {
                        c13_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        c13_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        c13_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        c13.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 14)
                    {
                        c14_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        c14_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        c14_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        c14.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 15)
                    {
                        c15_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        c15_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        c15_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        c15.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                }
                if (my.Day == "Piątek")
                {
                    if (my.Hour == 8)
                    {
                        pt8_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        pt8_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        pt8_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        pt8.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 9)
                    {
                        pt9_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        pt9_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        pt9_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        pt9.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 10)
                    {
                        pt10_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        pt10_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        pt10_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        pt10.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 11)
                    {
                        pt11_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        pt11_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        pt11_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        pt11.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 12)
                    {
                        pt12_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        pt12_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        pt12_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        pt12.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 13)
                    {
                        pt13_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        pt13_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        pt13_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        pt13.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 14)
                    {
                        pt14_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        pt14_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        pt14_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        pt14.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                    if (my.Hour == 15)
                    {
                        pt15_n.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Name;
                        pt15_t.Text = BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Name + " " +
                            BackendLibrary.DataAccess.TeacherData.GetTeacherBySubjectId(my.Subject_idSubject).Surname;
                        pt15_c.Text = BackendLibrary.DataAccess.SubjectData.GetSubjectById(my.Subject_idSubject).Classroom;
                        pt15.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    }
                }
            }
        }

        private void clearSchedule()
        {

            p8_n.Text = null;
            p8_t.Text = null;
            p8_c.Text = null;
            p8.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            p9_n.Text = null;
            p9_t.Text = null;
            p9_c.Text = null;
            p9.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            p10_n.Text = null;
            p10_t.Text = null;
            p10_c.Text = null;
            p10.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            p11_n.Text = null;
            p11_t.Text = null;
            p11_c.Text = null;
            p11.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            p12_n.Text = null;
            p12_t.Text = null;
            p12_c.Text = null;
            p12.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            p13_n.Text = null;
            p13_t.Text = null;
            p13_c.Text = null;
            p13.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            p14_n.Text = null;
            p14_t.Text = null;
            p14_c.Text = null;
            p14.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            p15_n.Text = null;
            p15_t.Text = null;
            p15_c.Text = null;
            p15.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            w8_n.Text = null;
            w8_t.Text = null;
            w8_c.Text = null;
            w8.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            w9_n.Text = null;
            w9_t.Text = null;
            w9_c.Text = null;
            w9.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            w10_n.Text = null;
            w10_t.Text = null;
            w10_c.Text = null;
            w10.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            w11_n.Text = null;
            w11_t.Text = null;
            w11_c.Text = null;
            w11.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            w12_n.Text = null;
            w12_t.Text = null;
            w12_c.Text = null;
            w12.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            w13_n.Text = null;
            w13_t.Text = null;
            w13_c.Text = null;
            w13.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            w14_n.Text = null;
            w14_t.Text = null;
            w14_c.Text = null;
            w14.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            w15_n.Text = null;
            w15_t.Text = null;
            w15_c.Text = null;
            w15.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            s8_n.Text = null;
            s8_t.Text = null;
            s8_c.Text = null;
            s8.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            s9_n.Text = null;
            s9_t.Text = null;
            s9_c.Text = null;
            s9.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            s10_n.Text = null;
            s10_t.Text = null;
            s10_c.Text = null;
            s10.Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238));

            s11_n.Text = null;
            s11_t.Text = null;
            s11_c.Text = null;
            s11.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            s12_n.Text = null;
            s12_t.Text = null;
            s12_c.Text = null;
            s12.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            s13_n.Text = null;
            s13_t.Text = null;
            s13_c.Text = null;
            s13.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            s14_n.Text = null;
            s14_t.Text = null;
            s14_c.Text = null;
            s14.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            s15_n.Text = null;
            s15_t.Text = null;
            s15_c.Text = null;
            s15.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            c8_n.Text = null;
            c8_t.Text = null;
            c8_c.Text = null;
            c8.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            c9_n.Text = null;
            c9_t.Text = null;
            c9_c.Text = null;
            c9.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            c10_n.Text = null;
            c10_t.Text = null;
            c10_c.Text = null;
            c10.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            c11_n.Text = null;
            c11_t.Text = null;
            c11_c.Text = null;
            c11.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            c12_n.Text = null;
            c12_t.Text = null;
            c12_c.Text = null;
            c12.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            c13_n.Text = null;
            c13_t.Text = null;
            c13_c.Text = null;
            c13.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            c14_n.Text = null;
            c14_t.Text = null;
            c14_c.Text = null;
            c14.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            c15_n.Text = null;
            c15_t.Text = null;
            c15_c.Text = null;
            c15.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            pt8_n.Text = null;
            pt8_t.Text = null;
            pt8_c.Text = null;
            pt8.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            pt9_n.Text = null;
            pt9_t.Text = null;
            pt9_c.Text = null;
            pt9.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            pt10_n.Text = null;
            pt10_t.Text = null;
            pt10_c.Text = null;
            pt10.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            pt11_n.Text = null;
            pt11_t.Text = null;
            pt11_c.Text = null;
            pt11.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            pt12_n.Text = null;
            pt12_t.Text = null;
            pt12_c.Text = null;
            pt12.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            pt13_n.Text = null;
            pt13_t.Text = null;
            pt13_c.Text = null;
            pt13.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            pt14_n.Text = null;
            pt14_t.Text = null;
            pt14_c.Text = null;
            pt14.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            pt15_n.Text = null;
            pt15_t.Text = null;
            pt15_c.Text = null;
            pt15.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        }
        public Schedule()
        {
            InitializeComponent();

            klasy.ItemsSource = addClass;
            if (MainWindow.loggedTeacher.IdTeacher != -1)
            {
                klasy.SelectedIndex = 0;
                clas = klasy.SelectedItem.ToString();
            }
            else
            {
                if (MainWindow.loggedStudent.IdStudent != -1)
                    clas = MainWindow.loggedStudent.Clas;
                else
                    clas = BackendLibrary.DataAccess.StudentData.GetStudentByParentId(MainWindow.loggedParent.IdParent).Clas;
                klasy.SelectedItem = clas;
            }

            Select_Schedule();
            Show_Schedule();
        }

        private void klasy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clas = klasy.SelectedItem.ToString();
            clearSchedule();
            Select_Schedule();
            Show_Schedule();
        }
    }
}

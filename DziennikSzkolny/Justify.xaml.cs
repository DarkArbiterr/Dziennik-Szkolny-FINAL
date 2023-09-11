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
    /// Interaction logic for Justify.xaml
    /// </summary>
    public partial class Justify : Page
    {
        public int i = 0;
        public ObservableCollection<PresenceModel> PresenceList = new ObservableCollection<PresenceModel>();

        private void BindData()
        {
            nieob.ItemsSource = null;
            nieob.ItemsSource = PresenceList;
        }

        private void loadPresence()
        {
            PresenceList = new ObservableCollection<PresenceModel>();
            PresenceList = BackendLibrary.DataAccess.PresenceData.GetAllSubjectPresence(MainWindow.loggedTeacher.Subject_idSubject);
            Dispatcher.Invoke(new Action(() => BindData()));
            Dispatcher.Invoke(new Action(() => this.DataContext = this));
        }

        public Justify()
        {
            InitializeComponent();
            loadPresence();
        }

        private void uspr()
        {
            var dataPresence = from s in PresenceList
                               where s.Check == true
                               select s.IdPresence;

            foreach (var s in dataPresence)
            {
                BackendLibrary.DataAccess.PresenceData.DeletePresence(s);
                i++;
            }
            if (i > 0)
            {
                MessageBox.Show("Usprawiedliwianie przebiegło pomyślnie!");
                MainWindow.us.ExecuteCommand(208);
                i = 0;
            }
            loadPresence();
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
            uspr();
        }

        private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                System.Windows.MessageBox.Show(e.Error.Message);
            }
            else
            {
            }
        }
    }
}

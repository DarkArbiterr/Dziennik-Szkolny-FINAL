using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DziennikWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public static string username, subject;
        public Service1()
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            username = args[0];
            subject = args[1];
            ServiceLibrary.ServiceStart();
            EventLog.WriteEntry("Usługa wystartowała!");
        }

        protected override void OnStop()
        {
            ServiceLibrary.ServiceStop();
            EventLog.WriteEntry("Usługa została wyłączona!");
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);

            if (command == 200)
            {
                ServiceLibrary.Login(username);
                EventLog.WriteEntry("Użytkownik " + username + " zalogował się w aplikacji");
            }
            
            if(command == 201)
            {
                ServiceLibrary.MoveToSchedule(username);
                EventLog.WriteEntry("Użytkownik " + username + " wszedł do zakładki 'plan zajęć'");
            }

            if(command == 202)
            {
                EventLog.WriteEntry("Użytkownik " + username + " wszedł do zakładki 'oceny'");
                ServiceLibrary.MoveToMarks(username);
            }

            if (command == 203)
            {
                ServiceLibrary.MoveToPresence(username);
                EventLog.WriteEntry("Użytkownik " + username + " wszedł do zakładki 'nieobecności'");
            }

            if (command == 204)
            {
                ServiceLibrary.MarkAdd(username, subject);
                EventLog.WriteEntry("Użytkownik " + username + " wystawił ocenę z przedmiotu " + subject);
            }

            if (command == 205)
            {
                ServiceLibrary.MarkChange(username, subject);
                EventLog.WriteEntry("Użytkownik " + username + " zmienił ocenę z przedmiotu " + subject);
            }

            if (command == 206)
            {
                ServiceLibrary.MarkDelete(username, subject);
                EventLog.WriteEntry("Użytkownik " + username + " usunął ocenę z przedmiotu " + subject);
            }

            if (command == 207)
            {
                ServiceLibrary.PresenceAdd(username, subject);
                EventLog.WriteEntry("Użytkownik " + username + " wstawił nieobecność z przedmiotu " + subject);
            }

            if (command == 208)
            {
                ServiceLibrary.PresenceDelete(username, subject);
                EventLog.WriteEntry("Użytkownik " + username + " usunął nieobecność z przedmiotu " + subject);
            }

            if (command == 209)
            {
                ServiceLibrary.Logout(username);
                EventLog.WriteEntry("Użytkownik " + username + " wylogował się z aplikacji");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace DziennikWindowsService
{
    public static class ServiceLibrary
    {
        public static void WriteToFile(string message)
        {
            StreamWriter sw;
            string path = AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.pathLog;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.nameLog + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                using(sw = File.CreateText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using(sw = File.AppendText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
        }

        public static void ServiceStart()
        {
            WriteToFile(DateTime.Now + "     Usługa wystartowała!");

        }

        public static void ServiceStop()
        {
            WriteToFile(DateTime.Now + "     Usługa została wyłączona!");
        }

        public static void Login(string username)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " zalogował się w aplikacji");
        }

        public static void MoveToSchedule(string username)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " wszedł do zakładki 'plan zajęć'");
        }

        public static void MoveToMarks(string username)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " wszedł do zakładki 'oceny'");
        }

        public static void MoveToPresence(string username)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " wszedł do zakładki 'nieobecności'");
        }

        public static void MarkAdd(string username, string subject)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " wystawił ocenę z przedmiotu " + subject);
        }

        public static void MarkChange(string username, string subject)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " zmienił ocenę z przedmiotu " + subject);
        }

        public static void MarkDelete(string username, string subject)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " usunął ocenę z przedmiotu " + subject);
        }

        public static void PresenceAdd(string username, string subject)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " wstawił nieobecność z przedmiotu " + subject);
        }

        public static void PresenceDelete(string username, string subject)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " usunął nieobecność z przedmiotu " + subject);
        }

        public static void Logout(string username)
        {
            ServiceLibrary.WriteToFile(DateTime.Now + "     Użytkownik " + username + " wylogował się z aplikacji");
        }
    }
}

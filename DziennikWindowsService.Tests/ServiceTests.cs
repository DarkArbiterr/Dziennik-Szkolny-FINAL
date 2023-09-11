using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xunit;
using XUnitPriorityOrderer;
using System.Text;
using System.IO;
using System.Linq;

namespace DziennikWindowsService.Tests.Tests
{
    [Order(1)]
    public class ServiceTests : BackendLibrary.Tests.Tests.BaseTestClass
    {
        [Fact, Order(1)]
        public async void WriteToFileTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.WriteToFile("przykładowa wiadomosc");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            //Assert.True(lastLine == "przykładowa wiadomosc");
            Assert.Equal("przykładowa wiadomosc", lastLine);
            
        }

        [Fact, Order(2)]
        public async void ServiceStartTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.ServiceStart();
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(3)]
        public async void ServiceStopTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.ServiceStop();
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(4)]
        public async void LoginTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.Login("nazwa uzytkownika");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(5)]
        public async void MoveToScheduleTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.MoveToSchedule("nazwa uzytkownika");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(6)]
        public async void MoveToMarksTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.MoveToMarks("nazwa uzytkownika");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(7)]
        public async void MoveToPresenceTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.MoveToPresence("nazwa uzytkownika");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(8)]
        public async void MarkAddTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.MarkAdd("nazwa uzytkownika", "przedmiot");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(9)]
        public async void MarkChangeTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.MarkChange("nazwa uzytkownika", "przedmiot");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(10)]
        public async void MarkDeleteTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.MarkDelete("nazwa uzytkownika", "przedmiot");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(11)]
        public async void PresenceAddTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.PresenceAdd("nazwa uzytkownika", "przedmiot");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(12)]
        public async void PresenceDeleteTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.PresenceDelete("nazwa uzytkownika", "przedmiot");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(13)]
        public async void LogoutTest()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            ServiceLibrary.Logout("nazwa uzytkownika");
            var lastLine = await Task.Run(() => File.ReadLines(filepath).Last());

            Assert.IsType<string>(lastLine);
        }

        [Fact, Order(100)]
        public async void ClearFileAfterTests()
        {
            string filepath = await Task.Run(() => AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt");
            File.Delete(filepath);

            Assert.True(!File.Exists(filepath));
        }

    }
}

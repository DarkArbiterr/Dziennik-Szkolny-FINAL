using System;
using BackendLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xunit;
using XUnitPriorityOrderer;
using System.Text;


namespace BackendLibrary.Tests.Tests
{
    [Order(5)]
    public class PresenceDataTests : BaseTestClass
    {
        [Fact, Order(2)]
        public async void GetAllStudentPresenceShouldReturnList()
        {
            int id = await Task.Run(() => DataAccess.StudentData.GetMaxId());
            var output = await Task.Run(() => DataAccess.PresenceData.GetAllStudentPresence(id));

            Assert.IsType<ObservableCollection<PresenceModel>>(output);
        }

        [Fact, Order(3)]
        public async void GetAllSubjectPresenceShouldReturnList()
        {
            string id = await Task.Run(() => DataAccess.SubjectData.GetMaxId());
            var output = await Task.Run(() => DataAccess.PresenceData.GetAllSubjectPresence(id));

            Assert.IsType<ObservableCollection<PresenceModel>>(output);
        }

        [Fact, Order(5)]
        public async void InsertPresenceTest()
        {
            int student_id = await Task.Run(() => DataAccess.StudentData.GetMaxId());
            int teacher_id = await Task.Run(() => DataAccess.TeacherData.GetMaxId());
            var teacher = await Task.Run(() => DataAccess.TeacherData.GetTeacherByTeacherId(teacher_id));
            PresenceModel newPresence = new PresenceModel("NIE", DateTime.Today.ToString("yyyy-MM-dd"), 8, teacher_id, student_id, teacher.Subject_idSubject);

            await Task.Run(() => DataAccess.PresenceData.InsertPresence(newPresence));
        }

        [Fact, Order(4)]
        public async void CheckPresence()
        {
            int id = await Task.Run(() => DataAccess.StudentData.GetMaxId());
            var output = await Task.Run(() => DataAccess.PresenceData.CheckPresence(id, "3000-01-01", 8));

            Assert.True(output == false);
        }

        [Fact, Order(1)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => DataAccess.PresenceData.GetMaxId());

            Assert.IsType<Int32>(id);
        }
    }
}

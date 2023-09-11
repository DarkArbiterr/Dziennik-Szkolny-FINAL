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
    [Order(4)]
    public class TeacherDataTests : BaseTestClass
    {
        [Fact, Order(2)]
        public async void GetTeacherTest()
        {
            var output = await Task.Run(() => DataAccess.TeacherData.GetTeacher("nieistniejacy login", "nieistniejace haslo"));

            Assert.True(output.IdTeacher == -1);
        }

        [Fact, Order(4)]
        public async void GetTeacherBySubjectTest()
        {
            string id = await Task.Run(() => DataAccess.SubjectData.GetMaxId());
            var output = await Task.Run(() => DataAccess.TeacherData.GetTeacherBySubjectId(id));

            Assert.True(output.Subject_idSubject == id);
        }

        [Fact, Order(3)]
        public async void GetTeacherByTeacherIdTest()
        {
            int id = await Task.Run(() => DataAccess.TeacherData.GetMaxId());
            var output = await Task.Run(() => DataAccess.TeacherData.GetTeacherByTeacherId(id));

            Assert.True(output.IdTeacher == id);
        }

        [Fact, Order(1)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => DataAccess.TeacherData.GetMaxId());

            Assert.IsType<Int32>(id);
        }


    }
}

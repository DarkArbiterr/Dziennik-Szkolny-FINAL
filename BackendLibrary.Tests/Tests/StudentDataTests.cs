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
    [Order(3)]
    public class StudentDataTests : BaseTestClass
    {
        [Fact, Order(4)]
        public async void GetAllClassStudentsShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.StudentData.GetAllClassStudents("3A"));

            Assert.IsType<ObservableCollection<StudentModel>>(output);
        }

        [Fact, Order(1)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => DataAccess.StudentData.GetMaxId());

            Assert.IsType<Int32>(id);
        }

        [Fact, Order(2)]
        public async void GetStudentTest()
        {
            var output = await Task.Run(() => DataAccess.StudentData.GetStudent("nieistniejacy login", "nieistniejace haslo"));

            Assert.True(output.IdStudent == -1);
        }

        [Fact, Order(3)]
        public async void GetStudentByParentIdTest()
        {
            int id = await Task.Run(() => DataAccess.ParentData.GetMaxId());
            int studentId = await Task.Run(() => DataAccess.StudentData.GetMaxId());
            var output = await Task.Run(() => DataAccess.StudentData.GetStudentByParentId(id));

            Assert.True(output.IdStudent == studentId);
        }
    }
}

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
    [Order(7)]
    public class MarkDataTests : BaseTestClass
    {
        [Fact, Order(2)]
        public async void GetAllForStudentsShouldReturnList()
        {
            int id = await Task.Run(() => DataAccess.StudentData.GetMaxId());
            var output = await Task.Run(() => DataAccess.MarkData.GetAllForStudent(id));

            Assert.IsType<ObservableCollection<MarkModel>>(output);
        }

        [Fact, Order(3)]
        public async void GetAllForTeacherShouldReturnList()
        {
            int idTeacher = await Task.Run(() => DataAccess.TeacherData.GetMaxId());
            int idStudent = await Task.Run(() => DataAccess.StudentData.GetMaxId());
            var output = await Task.Run(() => DataAccess.MarkData.GetAllForTeacher(idTeacher, idStudent));

            Assert.IsType<ObservableCollection<MarkModel>>(output);
        }

        [Fact, Order(1)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => DataAccess.MarkData.GetMaxId());

            Assert.IsType<Int32>(id);
        }

        [Fact, Order(4)]
        public async void InsertMarkTest()
        {
            int student_id = await Task.Run(() => DataAccess.StudentData.GetMaxId());
            int teacher_id = await Task.Run(() => DataAccess.TeacherData.GetMaxId());
            var teacher = await Task.Run(() => DataAccess.TeacherData.GetTeacherByTeacherId(teacher_id));
            MarkModel newMark = new MarkModel("5+", DateTime.Today.ToString("yyyy-MM-dd"), "nowa ocena", teacher_id, student_id, teacher.Subject_idSubject);

            await Task.Run(() => DataAccess.MarkData.InsertMark(newMark));
        }

        [Fact, Order(5)]
        public async void UpdateMarkTest()
        {
            int student_id = await Task.Run(() => DataAccess.StudentData.GetMaxId());
            int teacher_id = await Task.Run(() => DataAccess.TeacherData.GetMaxId());
            int mark_id = await Task.Run(() => DataAccess.MarkData.GetMaxId());
            var teacher = await Task.Run(() => DataAccess.TeacherData.GetTeacherByTeacherId(teacher_id));
            MarkModel updatedMark = new MarkModel(mark_id, "4+", DateTime.Today.ToString("yyyy-MM-dd"), "zaaktualizowana ocena", teacher_id, student_id, teacher.Subject_idSubject);

            await Task.Run(() => DataAccess.MarkData.UpdateMark(updatedMark));
        }


    }
}

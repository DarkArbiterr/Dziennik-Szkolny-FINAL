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
    [Order(1)]
    public class SubjectDataTests : BaseTestClass
    {
        [Fact, Order(2)]
        public async void GetSubjectByIdTest()
        {
            string id = await Task.Run(() => DataAccess.SubjectData.GetMaxId());
            var output = await Task.Run(() => DataAccess.SubjectData.GetSubjectById(id));

            Assert.True(output.IdSubject == id);
        }

        [Fact, Order(1)]
        public async void GetMaxIdShouldReturnString()
        {
            string id = await Task.Run(() => DataAccess.SubjectData.GetMaxId());

            Assert.IsType<String>(id);
        }
    }

}

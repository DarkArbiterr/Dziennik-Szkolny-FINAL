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
    [Order (6)]
    public class ParentDataTests : BaseTestClass
    {
        [Fact, Order(1)]
        public async void GetParentTest()
        {
            var output = await Task.Run(() => DataAccess.ParentData.GetParent("nieistniejacy login", "nieistniejace haslo"));

            Assert.True(output.IdParent == -1);
        }

        [Fact, Order(2)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => DataAccess.ParentData.GetMaxId());

            Assert.IsType<Int32>(id);
        }
    }
}

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
    [Order(100)]
    public class CleaningAfterTests : BaseTestClass
    {
        [Fact, Order(100)]
        public async void DeleteMarkTest()
        {
            int id = await Task.Run(() => DataAccess.MarkData.GetMaxId());
            int rowsAffected = await Task.Run(() => DataAccess.MarkData.DeleteMark(id));

            Assert.True(rowsAffected >= 1);
        }

        [Fact, Order(101)]
        public async void DeletePresenceTest()
        {
            int id = await Task.Run(() => DataAccess.PresenceData.GetMaxId());
            int rowsAffected = await Task.Run(() => DataAccess.PresenceData.DeletePresence(id));

            Assert.True(rowsAffected >= 1);
        }
    }
}

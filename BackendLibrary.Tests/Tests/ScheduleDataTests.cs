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
    [Order (2)]
    public class ScheduleDataTests : BaseTestClass
    {
        [Fact, Order(1)]
        public async void GetAllScheduleShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.ScheduleData.GetAllSchedule("3A"));

            Assert.IsType<ObservableCollection<ScheduleModel>>(output);
        }
    }
}

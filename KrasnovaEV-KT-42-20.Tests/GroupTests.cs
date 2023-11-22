using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrasnovaEV_KT_42_20.Models;

namespace KrasnovaEV_KT_42_20.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT4220_True()
        {
            //arrange
            var testGroup = new Group
            {
                GroupName = "KT-42-20"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.True(result);
        }
    }
}

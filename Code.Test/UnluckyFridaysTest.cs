using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Code.Test
{
    /* 
     * Friday, 13th is known as unlucky day.
     * Given a year return number of unlucky fridays in it.
     */

    public class UnluckyCounter
    {
        public int GetUnluckyFridays(int year) {
            var ci = new CultureInfo("en-US");
            var calendar = ci.DateTimeFormat.Calendar;
            int monthsTotal = calendar.GetMonthsInYear(year);
            var day13ths = new int[monthsTotal].Select((i, index) => calendar.GetDayOfWeek(new DateTime(year, index+1, 13))).Where(x => x == DayOfWeek.Friday).Count();
            return day13ths;
        }
    }
    [TestFixture]
    public class UnluckyFridaysTest
    {
        [TestCase(2009, 3)]
        [TestCase(2010, 1)]
        [TestCase(2011, 1)]
        [TestCase(2012, 3)]
        [TestCase(2013, 2)]
        [TestCase(2014, 1)]
        [TestCase(2015, 3)]
        public void UnluckyFridays_Test(int year, int expected)
        {
            // Act
            var res = new UnluckyCounter().GetUnluckyFridays(year);
            // Assert
            Assert.AreEqual(expected, res);
        }
    }
}

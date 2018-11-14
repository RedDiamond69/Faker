using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesGenerators.BaseTypes
{
    public class DateTimeValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public DateTimeValueGenerator()
        {
            GenerateType = typeof(DateTime);
            _random = new Random();
        }

        public object Generate()
        {
            int year = _random.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year + 1);
            int month = _random.Next(1, 12);
            int day = _random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            int hour = _random.Next(0, 24);
            int minute = _random.Next(0, 60);
            int second = _random.Next(0, 60);
            int millisecond = _random.Next(0, 1000);
            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }
    }
}

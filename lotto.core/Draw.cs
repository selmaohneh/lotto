using System;
using System.Collections.Generic;

namespace lotto.core
{
    public class Draw
    {
        public string Name { get; }
        public IEnumerable<int> Numbers { get; }
        public IEnumerable<int> SpecialNumbers { get; }
        public DateTime CurrentDate { get; }
        public DateTime NextDate { get; }

        public Draw(string name, IEnumerable<int> numbers, IEnumerable<int> specialNumbers, DateTime currentDate, DateTime nextDate)
        {
            Name = name;
            Numbers = numbers;
            SpecialNumbers = specialNumbers;
            CurrentDate = currentDate;
            NextDate = nextDate;
        }
    }
}

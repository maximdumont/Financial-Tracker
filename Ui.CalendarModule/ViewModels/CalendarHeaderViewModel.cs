using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Service.Data.Contexts;
using Service.Data.Repositories.DayOfWeekRepository;
using UI.CalendarModule.ViewModels.BaseTypes;

namespace UI.CalendarModule.ViewModels
{
    public class CalendarHeaderViewModel : BindableBase, ICalendardHeaderViewModel
    {
        public CalendarHeaderViewModel(IDayOfWeekRepository dayOfWeekRepository)
        {
            DaysInWeek = dayOfWeekRepository.GetDaysOfWeekInCurrentLocal();
            DaysInWeekCount = DaysInWeek.Count();
        }

        public IEnumerable<string> DaysInWeek { get; private set; }
        public int DaysInWeekCount { get; private set; }
    }
}
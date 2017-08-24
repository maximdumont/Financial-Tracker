using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Service.Data.Repositories.DayOfWeekRepository;
using UI.CalendarModule.ViewModels.BaseTypes;

namespace UI.CalendarModule.ViewModels
{
    public class CalendarDaysHeaderViewModel : BindableBase, ICalendarDaysHeaderViewModel
    {
        public CalendarDaysHeaderViewModel(IDayOfWeekRepository dayOfWeekRepository)
        {
            DaysInWeek = dayOfWeekRepository.GetDaysOfWeekInCurrentLocal();
            DaysInWeekCount = DaysInWeek.Count();
        }

        public IEnumerable<string> DaysInWeek { get; }
        public int DaysInWeekCount { get; }
    }
}
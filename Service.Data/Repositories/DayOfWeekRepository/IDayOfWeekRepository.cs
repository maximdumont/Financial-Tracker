using System.Collections.Generic;

namespace Service.Data.Repositories.DayOfWeekRepository
{
    public interface IDayOfWeekRepository
    {
        IEnumerable<string> GetDaysOfWeekInCurrentLocal();
        int GetDaysInWeek();
    }
}
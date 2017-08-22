using System;
using System.Collections.Generic;
using System.Linq;
using Service.Data.Contexts;

namespace Service.Data.Repositories.DayOfWeekRepository
{
    public class DayOfWeekRepository : BaseRepository<DayOfWeekRepository>, IDayOfWeekRepository
    {
        public DayOfWeekRepository() : base(new DbFinContext("FinTrack.Db.Dev"))
        {
        }

        public IEnumerable<string> GetDaysOfWeekInCurrentLocal()
        {
            return from DayOfWeek dayOfWeek in
                Enum.GetValues(typeof(DayOfWeek))
                select dayOfWeek.ToString();
        }

        public int GetDaysInWeek()
        {
            return GetDaysOfWeekInCurrentLocal().Count();
        }
    }
}
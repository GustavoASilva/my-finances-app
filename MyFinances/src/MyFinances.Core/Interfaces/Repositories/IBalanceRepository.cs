using MyFinances.Core.Aggregates.ScheduleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Interfaces.Repositories
{
    public interface IBalanceRepository : IRepository<Schedule>
    {
    }
}

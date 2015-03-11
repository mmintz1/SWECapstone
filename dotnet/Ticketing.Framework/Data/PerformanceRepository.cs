using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Framework.Data
{
    public class PerformanceRepository : UnconvertedGenericRepository<DBModels.Performance>
    {
        public PerformanceRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}

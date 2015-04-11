using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Framework.Data
{
    public class OrderRepository : UnconvertedGenericRepository<DBModels.Order>
    {
        public OrderRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.Models.Common;

namespace Ticketing.Framework.Transformers
{
    public class CategoryTransformer
    {
        public Category Transform(DBModels.EventType eventType)
        {
            var model = new Category
            {
                Name = eventType.Type,
                CategoryId = eventType.EventTypeId
            };

            return model;
        }

        public List<Category> Transform(IEnumerable<DBModels.EventType> eventType)
        {
            var model = new List<Category>();
            foreach (var type in eventType)
            {
                model.Add(Transform(type));
            }

            return model;
        }
    }
}

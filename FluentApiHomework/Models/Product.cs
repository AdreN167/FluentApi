using System;
using System.Collections.Generic;

namespace FluentApiHomework.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public ICollection<DishProduct> DishProducts { get; set; }
    }
}

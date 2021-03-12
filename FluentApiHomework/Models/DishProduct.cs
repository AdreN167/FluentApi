using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiHomework.Models
{
    public class DishProduct : Entity
    {
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Dish Dish { get; set; }
        public Guid DishId { get; set; }
    }
}

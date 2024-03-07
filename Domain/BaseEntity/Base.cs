using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseEntity
{
    public abstract class Base<T>
    {
        [Key]
        public T Id { get; set; }
        public bool IsRemove { get; set; } = false;
        public DateTime InsertTime { get; set; } = DateTime.Now;
    }
    public abstract class Base : Base<int>
    {

    }
}

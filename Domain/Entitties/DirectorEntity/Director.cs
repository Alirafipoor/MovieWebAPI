using Domain.BaseEntity;
using Domain.Entitties.MovieEnttiy;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitties.DirectorEntity
{
    public class Director:Base
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        public int Award { get; set; }
        public Gender Gender { get; set; }
        public bool IsMarried { get; set; }
        public string Description { get; set; }
        public ICollection<MyMovie> Movies { get; set; }
    }
}

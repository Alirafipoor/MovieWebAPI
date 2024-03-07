using Domain.BaseEntity;
using Domain.Entitties.MovieEnttiy;
using Domain.Enum;

namespace Domain.Entitties.ActorEntities
{
    public class Actor:Base
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

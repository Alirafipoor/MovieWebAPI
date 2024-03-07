using Domain.BaseEntity;
using Domain.Entitties.MovieEnttiy;

namespace Domain.Entitties.GenreEntity
{
    public class Genre:Base
    {
        public string Name { get; set; }
        public ICollection<MyMovie> Movies { get; set; }
    }
}

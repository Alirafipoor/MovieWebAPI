using Domain.BaseEntity;

namespace Domain.Entitties.UserEntity
{
    public class User:Base
    {
        public List<int>? Recommand { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<UserToken> UserToken { get; set; }
    }
}

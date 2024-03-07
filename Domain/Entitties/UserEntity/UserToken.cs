using Domain.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entitties.UserEntity
{
    public class UserToken:Base
    {
      
        public string TokenHash { get; set; }
        public DateTime TokenExp { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExp { get; set; }

        
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

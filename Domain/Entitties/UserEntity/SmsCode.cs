using Domain.BaseEntity;

namespace Domain.Entitties.UserEntity
{
    public class SmsCode
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public bool IsUse { get; set; }=false;
        public int RequestCount { get; set; }
        public DateTime InsertTime { get; set; }
    }
}

namespace ServisTakip.Core.Entities.Concrete
{
    public class GroupClaim : BaseEntity
    {
        public long GroupId { get; set; }
        public long OperationClaimId { get; set; }
    }
}

﻿namespace ServisTakip.Core.Entities.Concrete
{
    public class User : BaseEntity
    {
        public long CompanyId { get; set; }
        public byte[] Avatar { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte Gender { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string RefreshToken { get; set; }
        public bool Status { get; set; }
        public DateTime? LastLogin { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}

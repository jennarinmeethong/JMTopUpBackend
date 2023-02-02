using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMTopUpBackend.Application
{
    public class UserProfile : IKey<Guid>, IDisabled, IUserAuditable
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public short RoleId { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDisabled { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; } = null!;
    }
}

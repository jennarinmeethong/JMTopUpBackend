using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMTopUpBackend.Domain
{
    public interface IUserAuditable
    {
        Guid CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        Guid? LastModifiedBy { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}

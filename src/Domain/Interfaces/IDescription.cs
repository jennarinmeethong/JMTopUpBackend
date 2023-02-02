using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMTopUpBackend.Domain
{
    public interface IDescription
    {
        string DescriptionTH { get; set; }
        string DescriptionEN { get; set; }
    }
}

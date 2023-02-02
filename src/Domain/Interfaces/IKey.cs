using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMTopUpBackend.Domain
{
    public interface IKey<TKey>
    {
        TKey Id { get; set; }
    }
}

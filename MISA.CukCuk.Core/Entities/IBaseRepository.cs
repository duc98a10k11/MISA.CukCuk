using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    public interface IBaseRepository<MISAEntity>
    {
        public MISAEntity GetAll();

    }
}

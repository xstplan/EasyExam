using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XST.Service.Repository;

namespace XST.Service
{
   public class BaseService<T> : BaseRepository<T> where T : class, new()
    {
    }
}

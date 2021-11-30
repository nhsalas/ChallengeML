using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IBitacoraRepository
    {
        void Add(Bitacora bitacora);
        Task<bool> InsertLog(Bitacora bitacora);

        Task<IEnumerable<Bitacora>> GetAllLogs();
        IEnumerable<Bitacora> GetAll();
    }
}
